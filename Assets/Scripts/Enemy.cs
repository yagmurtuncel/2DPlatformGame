using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    [SerializeField] Animator anim;
    public static bool isStart = false;
    public void TakeDamage (int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        anim.SetTrigger("isDead");
        Destroy(gameObject, 1f);
    }
}
