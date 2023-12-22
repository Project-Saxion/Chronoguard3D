using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    
    
    public GameObject Melee;
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
    public float shootCooldown = 0.25f;
    public float shootTimer = 0.5f;    
    
    // Heavy
    private bool heavyIsAttacking = false;
    public float heavyAttackTime;
    public float heavyAttackDuration;
    public float heavyAttackCooldown;

    
    // Either make 3 different Attack items, or have a list that only get's 2/3rd of modifiers...
    public Attack[] attacking;
    public float attackModifier;
    
    [SerializeField] public float moveSpeed;
    [SerializeField] public float acceleration;
    [SerializeField] public float decceleration;
    [SerializeField] public float velPower;

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
        attackModifier = attacking[0].GetModifier();
    }

    private void Update()
    {
        MovePlayer();
        
        // For Cooldowns
        attackTime += Time.deltaTime;
        shootTimer += Time.deltaTime;
        heavyAttackTime += Time.deltaTime;
        
        CheckMeleeTimer();
        CheckHeavyAttackTimer();
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
    
    private void Attack(InputAction.CallbackContext context) 
    {
        if (attackTime > attackCooldown)
        {
            attackTime = 0;
            
            attacking[0].SetModifier(attackModifier);
            attacking[1].SetModifier(attackModifier);
            // attacking[2].SetModifier(attackModifier);
            attackModifier++;
            
            Debug.Log("Updated melee modifier: " + attackModifier);
            if (!isAttacking)
            {
                Melee.SetActive(true);
                isAttacking = true;
            }
        }
    }

    private void Fire(InputAction.CallbackContext context)
    {
        if (shootTimer > shootCooldown)
        {
            shootTimer = 0;
            GameObject intBullet = Instantiate(bullet, Aim.position, Aim.rotation);
            intBullet.GetComponent<Rigidbody2D>().AddForce(-Aim.up * fireForce, ForceMode2D.Impulse);

            Destroy(intBullet, 2f);
        }
    }

    private void Heavy(InputAction.CallbackContext context)
    {
        if (heavyAttackTime > heavyAttackCooldown)
        {
            heavyAttackTime = 0;
            if (!heavyIsAttacking)
            {
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
            Melee.SetActive(false);
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
}

