using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField]
    private bool MoveOnX , MoveOnY ;

    [SerializeField]
    private float movespeed = 10f;

    [SerializeField]
    private float MoveHorizontalThreshHold = 8f;

    [SerializeField]
    private float MoveVerticalThreshHold = 6f;

    private Vector3 TempMovementHorizontal;
    private Vector3 TempMovementVertical;

    private float minX , maxX , minY , maxY ;

    private bool MoveUp = false;
    private bool Moveleft;

    // Start is called before the first frame update
    void Start()
    {
        minX = transform.position.x - MoveHorizontalThreshHold;
        maxX = transform.position.x + MoveHorizontalThreshHold;

        minY = transform.position.y ;
        maxY = transform.position.y + MoveVerticalThreshHold;

        if(Random.Range(0,2)>0)
            Moveleft = true;
    }

    // Update is called once per frame
    void Update()
    {
        HandleHorizontalMovement();
        HandleVerticalMovement();
    }

    void HandleHorizontalMovement()
    {
        if (!MoveOnX)
            return;

        if (Moveleft)
        {
            TempMovementHorizontal = transform.position;
            TempMovementHorizontal.x -= movespeed * Time.deltaTime;
            transform.position = TempMovementHorizontal;

            if(TempMovementHorizontal.x < minX)
                Moveleft = false;

        }
        else
        {
            TempMovementHorizontal = transform.position;
            TempMovementHorizontal.x += movespeed * Time.deltaTime;
            transform.position = TempMovementHorizontal;

            if (TempMovementHorizontal.x > maxX)
                Moveleft = true;
        }
    }

    void HandleVerticalMovement()
    {
        if (!MoveOnY)
            return;
        if (!MoveUp)
        {
            TempMovementVertical = transform.position;
            TempMovementVertical.y -= movespeed * Time.deltaTime;
            transform.position = TempMovementVertical;

            if (TempMovementVertical.y < minY)
                MoveUp = true;
        }
        else
        {
            TempMovementVertical = transform.position;
            TempMovementVertical.y += movespeed * Time.deltaTime;
            transform.position = TempMovementVertical;

            if (TempMovementVertical.y >maxY)
                MoveUp = false;
        }

    }
}
