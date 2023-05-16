using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementUp : MonoBehaviour
{
    [SerializeField] float movementDistance;
    [SerializeField] float speed;

    private bool movingUp;
    private float upEdge;
    private float downEdge;
    private void Awake()
    {
        upEdge = transform.position.y - movementDistance;
        downEdge = transform.position.y + movementDistance;
    }
    void Update()
    {
        if (movingUp)
        {
            if (transform.position.y >= upEdge)
            {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                movingUp = false;
            }
        }
        else
        {
            if (transform.position.y <= downEdge)
            {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                movingUp = true;
            }
        }
    }
}
