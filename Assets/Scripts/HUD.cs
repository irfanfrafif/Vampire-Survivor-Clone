using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreText;
    [SerializeField] TMP_Text HealthText;
    [SerializeField] Image healthBar;

    PlayerHealth health;

    private void Start()
    {
        health = GameManager.Instance.player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        HealthText.SetText(health.health.ToString());
        ScoreText.SetText("Score: " + GameManager.Instance.score.ToString());
        healthBar.fillAmount = health.health / health.maxHealth;
    }
}
