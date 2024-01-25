using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RespawnController : MonoBehaviour
{
    [SerializeField] private Image cooldownOverlay;
    [SerializeField] private float cooldownTime;
    [SerializeField] private TextMeshProUGUI cooldownText;
    private float cooldownTimer;

    private bool timerRunning = false;
    public UnityEvent OnCooldownEnd;
    
    public void StartCooldown()
    {
        cooldownOverlay.fillAmount = 1;
        cooldownTimer = cooldownTime;
        cooldownOverlay.gameObject.SetActive(true);
        cooldownText.gameObject.SetActive(true);
        timerRunning = true;
    }

    private void Update()
    {
        ApplyCooldown();
    }

    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer > 0.0f)
        {
            cooldownOverlay.fillAmount = cooldownTimer / cooldownTime;
            cooldownText.text = Mathf.CeilToInt(cooldownTimer).ToString();
        }
        else if (cooldownTimer < 0.0 && timerRunning)
        {
            cooldownTimer = 0;
            cooldownText.gameObject.SetActive(false);
            cooldownOverlay.gameObject.SetActive(false);
            OnCooldownEnd.Invoke();
            timerRunning = false;
        }
    }

    public void SetCooldownTime(float newCooldownTime)
    {
        cooldownTime = newCooldownTime;
    }

}