using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    [SerializeField] float fireSpeed;
    [SerializeField] int damage=20;
    [SerializeField] Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * fireSpeed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(enemy !=null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject, 5f);
        }
    }
}
