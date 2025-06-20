using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 5f;
    private Vector3 startPos;
    private bool movingRight = true;

    
    void Start()
    {
        startPos = transform.position;
    }

   
    void Update()
    {
        float leftBound = startPos.x - distance;
        float rightBound = startPos.x + distance;
        if (movingRight){
            transform.Translate(Vector2.right*speed*Time.deltaTime);
            if(transform.position.x >= rightBound){
                movingRight = false;
                flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left*speed*Time.deltaTime);
            if(transform.position.x <= leftBound)
            {
                movingRight = true;
            }
        }
    }
    void flip()
    {
        Vector3 scaler=transform.localScale;
        transform.localScale=scaler;
    }
}
