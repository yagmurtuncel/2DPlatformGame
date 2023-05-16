using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    [SerializeField] float movementDistance;
    [SerializeField] float speed;
    
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    public static bool isStart = false;
    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }
    void Update()
    {
        if (movingLeft)
        {
            if(transform.position.x >= leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, 
                    transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = false;
                transform.Rotate(0f,180f,0f);
            }
        }
        else
        {
            if (transform.position.x <= rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime,
                    transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = true;
                transform.Rotate(0f, 180f, 0f);
            }
        }
    }
}
