using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform pointA; // Điểm A
    [SerializeField] private Transform pointB; // Điểm B
    [SerializeField] private float speed = 2f; // Tốc độ di chuyển
    private Vector3 nextPosition;
    private Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextPosition = pointB.position;

    }

    // Update is called once per frame
    void Update()
    {   
        
        transform.position = Vector3.MoveTowards(transform.position,nextPosition,speed*Time.deltaTime);
        if (transform.position == nextPosition)
        {
            nextPosition = (nextPosition == pointA.position) ? pointB.position : pointA.position;
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = transform;
        }
    }  
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
