using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Movement : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    [SerializeField] float scaleX;
    [SerializeField] float scaleY;


    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    void Update()
    {
         EnemyMove();
    }

    
    private void EnemyMove()
    {
        if (movingLeft)
        {

            transform.localScale = new Vector3(scaleX, scaleY, 1f);

            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = false;
            }
        }

        
        else
        {
            transform.localScale = new Vector3(-scaleX, scaleY, 1f);

            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = true;
            }
        }
    }
}
