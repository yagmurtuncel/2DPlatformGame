using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGround : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    [SerializeField] Rigidbody2D rb;
    public float jumpSpeed = 8f;
    [SerializeField] bool yerdeMiyiz = true;
    [SerializeField] Animator anim;
    
    void Update()
    {
        if(!Player.isStart)
        {
            return;
        }
        RaycastHit2D carpiyorMu = Physics2D.Raycast(transform.position, Vector2.down, 0.25f, layer);

        if (carpiyorMu.collider != null)
        {
            yerdeMiyiz = true;
            anim.SetBool("zipliyorMu", false);
        }
        else
        {
            yerdeMiyiz = false;
            anim.SetBool("zipliyorMu", true);
        }
        if (yerdeMiyiz == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }
}
