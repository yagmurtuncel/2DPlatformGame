using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    bool kostuMu = false;
    public static int score;
    [SerializeField] Text scoreText, lastScoreText, bestScoreText;
    [SerializeField] Text restartBestScoreText;
    public static bool isStart = true;
    
    [SerializeField] AudioSource bananaSound;
    [SerializeField] AudioSource deadSound;
    [SerializeField] GameObject restartPanel;
    bool facingRight = true;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject firePrefab;
    private float shootDelay = .3f;
    private bool isShooting;

    public static int health;
    public static int maxHealth = 3;
    private Scene Level10;

    void Start()
    {
        scoreText.text = score.ToString();
        bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("Score").ToString();
        
    }

    private void Update()
    {
        if (!isStart)
        {
            return;
        }
        Shooting();
    }
    private void FixedUpdate()
    {
      if(!isStart)
        {
            return;
        }
        float h = Input.GetAxis("Horizontal");
        Mover(h);
        PlayerAnimation(h);
        PlayerTurn(h);
    }

    #region Carpisma
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Banana"))
        {
            bananaSound.Play();
            Destroy(collision.gameObject);
            score += 5;
            scoreText.text = score.ToString();
        }

        if (collision.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("yeniScore", score);
        }

        if (collision.CompareTag("WeakPoint"))
        {
                Destroy(collision.gameObject, 1f);
                score += 10;
                scoreText.text = score.ToString();
        }
     }
    #endregion
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Dead(collision);
    }

    #region Karakter Hareket Ýþlemi
    void Mover(float h)
    {
        rb.velocity = new Vector2(h * speed, rb.velocity.y);
    }
    #endregion

    #region Karakter Animasyon Ýþlemi
    void PlayerAnimation(float h)
    {
        if (h !=0)
        {
            kostuMu = true;
        }
        else
        {
            kostuMu = false;
        }
        anim.SetBool("kosuyorMu", kostuMu);
    }
    #endregion

    #region Karakter Yön Ýþlemi
    void PlayerTurn(float h)
    {
        
        if (h>0 && !facingRight)
        {
            Flip();
        }
        else if(h<0 && facingRight)
        {
            Flip();
        }
    }
    public void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    #endregion

    #region Karakter Ölme Ýþlemi
    private void Dead(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Spike"))
        {
            if (score > PlayerPrefs.GetInt("Score"))
            {
                PlayerPrefs.SetInt("Score", score);
            }
            PermaDeathController();
            
        }
    
    }
    #endregion

    #region Health
    public void PermaDeathController()
    {
        health--;

        if (health >0)
        {
            anim.SetTrigger("yaralandiMi");
        }
        else
        {
            anim.SetTrigger("olduMu");
            deadSound.Play();
            Destroy(gameObject, 1.5f);
            restartPanel.SetActive(true);
            lastScoreText.text = "Score:" + score.ToString();
            restartBestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("Score").ToString();
        }
    }
    #endregion

    #region Ateþ Etme Ýþlemi
    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isShooting) return;
            isShooting = true;
            Instantiate(firePrefab, firePoint.position, transform.rotation);
            Invoke("ResetShoot", shootDelay);
        }
    }
    void ResetShoot()
    {
        isShooting = false;
    }

    #endregion

    #region Play Tuþu
    public void PlayGame()
    {
        isStart = true;
        score = 0;
        SceneManager.LoadScene("Level1");
        health = maxHealth;
        PlayerPrefs.DeleteKey("yeniScore");
    }
    #endregion

}
