using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 600f;

    private Rigidbody2D mybody;
    // Start is called before the first frame update
    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovement();
       
    }

    public void HandleMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            mybody.AddForce(transform.up * speed);

      
        if (Input.GetKey(KeyCode.DownArrow))
            mybody.AddForce(-transform.up * speed);

        if (Input.GetKey(KeyCode.RightArrow))
            mybody.AddForce(transform.right * speed);

        if (Input.GetKey(KeyCode.LeftArrow))
            mybody.AddForce(-transform.right * speed);
    }
}
