using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int HealthPoint;

    private AudioSource music;
    public HealthBar healthBar;
    public GameObject gameOver;

    private void Start()
    {
        HealthPoint = MaxHealth;
        gameOver.SetActive(false);
        healthBar.SetMaxHealth(MaxHealth);
        music = GetComponent<AudioSource>();
        float menuVolume = PlayerPrefs.GetFloat("Game");
        music.volume = menuVolume;
    }

    private void LateUpdate()
    {
        music.volume = PlayerPrefs.GetFloat("Game");
    }

    void PlayerApplyDamage(int damage)
    {
        HealthPoint -= damage;
        healthBar.SetHealth(HealthPoint);
        if (HealthPoint <= 0)
        {
            gameOver.SetActive(true);
            Destroy(gameObject);
        }
    }
}
