using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    //references
    [SerializeField] private Rigidbody rb;

    //values
    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDir;
    public Vector3 movementVel;

    public PlayerControls playerControls;
    
    private InputAction attack;
    private InputAction fire;
    private InputAction heavyAttack;
    
    // Unity Events
    public UnityEvent basicAttackEvent;
    public UnityEvent heavyAttackEvent;
    
    public GameObject SwordHitBox;
    public GameObject HeavyAttack;
    public LayerMask enemies;
    
    // Melee
    private bool isAttacking = false;
    public float attackTime;
    public float attackDuration;
    public float attackCooldown;
    
    // Ranged
    public Transform Aim;
    public GameObject bullet;
    public float fireForce = 10;
    public float shootDuration;
    public float shootCooldown = 0.25f;
    public float shootTimer = 0.5f;    
    
    // Heavy
    private bool heavyIsAttacking = false;
    public float heavyAttackTime;
    public float heavyAttackDuration;
    public float heavyAttackCooldown;
    
    private Camera mainCam;
    
    [SerializeField] private LayerMask groundMask;

    
    // Either make 3 different Attack items, or have a list that only get's 2/3rd of modifiers...
    public Attack[] attacking;
    public float attackModifier;
    public String[] tagsToDamage;

    public ShootingSystem ShootingSystem;
    
    [SerializeField] public float moveSpeed;
    [SerializeField] public float acceleration;
    [SerializeField] public float decceleration;
    [SerializeField] public float velPower;

    private Vector3 moveDirection;
    public Animator animator;
    [SerializeField] public List<AudioSource> audioSources;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        attack = playerControls.Player.Attack;
        attack.Enable();
        attack.performed += Attack;
        
        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
        
        heavyAttack = playerControls.Player.Heavy;
        heavyAttack.Enable();
        heavyAttack.performed += Heavy;
    }

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        attackModifier = attacking[0].GetModifier();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        
        // For Cooldowns
        attackTime += Time.deltaTime;
        shootTimer += Time.deltaTime;
        heavyAttackTime += Time.deltaTime;
        
        CheckMeleeTimer();
        CheckHeavyAttackTimer();
        AnimatePlayerMovement();
    }

    private void Update()
    {
        PointTo();
    }

    private void OnDisable()
    {
        attack.Disable();
        fire.Disable();
        heavyAttack.Disable();
    }

    public void HandleInput(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<Vector3>();

        if (moveDir.magnitude > 1)
        {
            moveDir = moveDir / moveDir.magnitude;
        }
    }

    public void MovePlayer()
    {

        float targetSpeedHorizontal = moveDir.x * moveSpeed;
        float targetSpeedVertical = moveDir.z * moveSpeed;
        float speedDifX = targetSpeedHorizontal - rb.velocity.x;
        float speedDifZ = targetSpeedVertical - rb.velocity.z;
        float accelRateX = (Mathf.Abs(speedDifX) > 0.01f) ? acceleration : decceleration;
        float accelRateZ = (Mathf.Abs(speedDifZ) > 0.01f) ? acceleration : decceleration;

        float movementX = Mathf.Pow(Mathf.Abs(speedDifX) * accelRateX, velPower) * Mathf.Sign(speedDifX);
        float movementZ = Mathf.Pow(Mathf.Abs(speedDifZ) * accelRateZ, velPower) * Mathf.Sign(speedDifZ);

        movementVel.x = movementX * Vector3.right.x;
        movementVel.z = movementZ * Vector3.forward.z;


        rb.AddForce(movementVel);
    }

    void AnimatePlayerMovement()
    {
        float h = moveDir.z;
        float v = moveDir.x;
        moveDirection = new Vector3(h, 0, v);
        
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 towardCursor = mousePos - transform.position;

        if (moveDirection.magnitude > 1.0f)
        {
            moveDirection = moveDirection.normalized;
        }
        moveDirection = transform.InverseTransformDirection(moveDirection);
        
        
        if (rb.velocity.magnitude is < 0.1f and > -0.1f)
        {
            animator.SetBool("isIdle", true);
            audioSources[3].Stop();
        }
        else
        {
            animator.SetBool("isIdle", false);
            if (!audioSources[3].isPlaying)
            {
                audioSources[3].Play();
            }
        }
        
        animator.SetFloat("Vertical", moveDirection.z);
        animator.SetFloat("Horizontal", moveDirection.x);
    }
    
    private void Attack(InputAction.CallbackContext context) 
    {
        if (attackTime > attackCooldown)
        {
            basicAttackEvent.Invoke();
            attackTime = 0;
            
            attacking[0].SetModifier(attackModifier);
            attacking[1].SetModifier(attackModifier);
            
            if (!isAttacking)
            {
                SwordHitBox.SetActive(true);
                isAttacking = true;
                animator.SetTrigger("isAttacking");
                audioSources[0].Play();
            }
        }
    }

    private void Fire(InputAction.CallbackContext context)
    {
        if (shootTimer > shootCooldown)
        {
            animator.SetTrigger("isRangedAttacking");
            
            if (shootTimer > shootDuration)
            {
                shootTimer = 0;
                ShootingSystem.Attack(tagsToDamage);
                audioSources[1].Play();
            }
        }
    }

    private void Heavy(InputAction.CallbackContext context)
    {
        if (heavyAttackTime > heavyAttackCooldown)
        {
            heavyAttackEvent.Invoke();
            heavyAttackTime = 0;
            if (!heavyIsAttacking)
            {
                animator.SetTrigger("isHeavyAttacking");
                audioSources[3].Play();
                HeavyAttack.SetActive(true);
                heavyIsAttacking = true;
            }
        }
    }

    void CheckMeleeTimer()
    {
        if (isAttacking && attackTime >= attackDuration)
        {
            isAttacking = false;
            SwordHitBox.SetActive(false);
        }
    }

    void CheckHeavyAttackTimer()
    {
        if (heavyIsAttacking && heavyAttackTime >= heavyAttackDuration)
        {
            heavyAttackTime = 0;
            heavyIsAttacking = false;
            HeavyAttack.SetActive(false);
        }
    }

    public float[] getCooldown()
    {
        return new[]
        {
            attackCooldown,
            heavyAttackCooldown
        };
    }
    
    private void PointTo()
    {
        var (success, position) = GetMousePosition();

        if (success)
        {
            var direction = position - transform.position;
            direction.y = 0;

            transform.forward = direction;
        }
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            return (success: true, position: hitInfo.point);
        }
        else
        {
            return (success: false, position: Vector3.zero);
        }
    }
}

