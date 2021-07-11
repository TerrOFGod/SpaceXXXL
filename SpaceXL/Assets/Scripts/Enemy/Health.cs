using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float HealthPoint;
    Animator animator;
    private GameObject spawner;
    public AudioClip DeathClip;
    public AudioSource AudioSource;

    private void Awake()
    {
        spawner = GameObject.Find("spawners");
        animator = GetComponent<Animator>();
        float volume = PlayerPrefs.GetFloat("Game");
        AudioSource.volume = volume;
    }

    private void LateUpdate()
    {
        AudioSource.volume = PlayerPrefs.GetFloat("Game");
    }

    void ApplyDamage(float damage)
    {
        HealthPoint -= damage;
        if (HealthPoint <= 0)
        {
            animator.SetTrigger("Death");
        }
    }

    IEnumerator Death()
    {
        spawner.GetComponent<Spawner>().RemoveMob(gameObject);
        AudioSource.PlayOneShot(DeathClip);
        yield return new WaitForSeconds(DeathClip.length);
        Destroy(gameObject);
    }
}
