using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    [SerializeField]
    private float minX , maxX , minY , maxY ;

    [SerializeField]
    private float moveSpeed = 8f;

    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        SetTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void SetTargetPosition()
    {
        targetPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY) , 0f);
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position ,targetPosition, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position , targetPosition) < 0.1f) 
            SetTargetPosition();
    }
}
