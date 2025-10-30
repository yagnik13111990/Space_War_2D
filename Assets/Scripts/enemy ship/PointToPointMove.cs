using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPointMove : MonoBehaviour
{
    [SerializeField]
    private Transform[] MovementPoints;

    private int CurrentIndex;

    private Vector3 TargetPosition;

    [SerializeField]
    private bool RandomPosition;

    [SerializeField]
    private float MoveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        SetMovementPosition();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void SelectRandomPosition() {
        while (MovementPoints[CurrentIndex].position == TargetPosition)
        {
            CurrentIndex = Random.Range(0 , MovementPoints.Length);
        }
        TargetPosition = MovementPoints[CurrentIndex].position;
    }
        void SelectPointToPointPosition()
    {
        if(CurrentIndex == MovementPoints.Length)
            CurrentIndex = 0;
        TargetPosition = MovementPoints[CurrentIndex].position;
        CurrentIndex++;

    }
    void SetMovementPosition()
    {
        if (RandomPosition)
            SelectRandomPosition();
        else
            SelectPointToPointPosition();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position ,TargetPosition ,(MoveSpeed * Time.deltaTime));

        if (Vector2.Distance(transform.position, TargetPosition) < 0.1f)
            SetMovementPosition();
            
    }
}
