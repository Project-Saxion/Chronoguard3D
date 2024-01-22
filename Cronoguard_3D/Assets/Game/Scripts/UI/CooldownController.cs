using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class CooldownController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Image basicAttackOverlay;
    [SerializeField] private Image heavyAttackOverlay;
    
    private float[] _attackCooldowns;

    private bool basicAttackActive;

    private bool heavyAttackActive;

    private float basicAttackTimer;

    private float heavyAttackTimer;
    // Start is called before the first frame update
    public void StartBasicAttackCooldown()
    {
        basicAttackActive = true;
        basicAttackTimer = _attackCooldowns[0];
        basicAttackOverlay.gameObject.SetActive(true);
    }
    

    public void StartHeavyAttackCooldown()
    {
        heavyAttackActive = true;
        heavyAttackTimer = _attackCooldowns[1];
        heavyAttackOverlay.gameObject.SetActive(true);
    }

    private void Start()
    {
        _attackCooldowns = _playerController.getCooldown();
    }

    // Update is called once per frame
    void Update()
    {
        if (basicAttackActive)
        {
            basicAttackTimer -= Time.deltaTime;
            if (basicAttackTimer > 0.0f)
            {
                basicAttackOverlay.fillAmount = 1- (basicAttackTimer / _attackCooldowns[0]);
            }
            else
            {
                basicAttackOverlay.fillAmount = 1;
            }
        }

        if (heavyAttackActive)
        {
            heavyAttackTimer -= Time.deltaTime;
            if (heavyAttackTimer > 0.0f)
            {
                heavyAttackOverlay.fillAmount = 1 - (heavyAttackTimer / _attackCooldowns[1]);
            }
            else
            {
                heavyAttackOverlay.fillAmount = 1;
            }
        }
    }
}
