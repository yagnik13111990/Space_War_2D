using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMeteor : MonoBehaviour
{
    [SerializeField]
    private float minspeed = 4f, maxspeed = 10f;

    [SerializeField]
    private float minrotation = 15f, maxrotation = 50f;

    [SerializeField]
    private bool moveOnX , moveOnY = true;

    private float rotationspeed ;

    private float zrotation;

    private Vector3 tempPosition;

    private float speedX , speedY ;

    // Start is called before the first frame update
    void Awake()
    {
        rotationspeed = Random.Range(minrotation, maxrotation);

        speedX = Random.Range(minspeed , maxspeed);
        speedY = speedX;

        if(Random.Range(0,2) >0)
            moveOnX = true;

        if (Random.Range(0, 2) > 0)
           speedX *= -1;

        if (Random.Range(0, 2) > 0)
            rotationspeed *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        HandleMovementOnX();
        HandleMovementOnY();
    }

    void HandleRotation()
    {
        zrotation += rotationspeed * Time.deltaTime;
       
        transform.rotation = Quaternion.AngleAxis(zrotation, Vector3.forward);
       
    }

    void HandleMovementOnX()
    {
        if (!moveOnX)
            return;

        tempPosition = transform.position;
        tempPosition.x += speedX * Time.deltaTime;
        transform.position = tempPosition;

    }

    void HandleMovementOnY()
    {
        if (!moveOnY)
            return;

        tempPosition = transform.position;
        tempPosition.y -= speedY * Time.deltaTime;
        transform.position = tempPosition;
    }
}
