using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootspawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] weapons;

    [SerializeField]
    private Transform[] points;

    public float shoottimethreshhold = 0.2f;

    private float shoottimer;

    private bool canshoot;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > shoottimer)
            canshoot = true;
            shooter();
    }

    public void shooter()
    {
        if (!canshoot)
            return;
        //blaster 1
        if (Input.GetKeyDown(KeyCode.H))
        {
            Instantiate(weapons[0] , points[0].position , Quaternion.identity);

            Instantiate(weapons[0], points[1].position, Quaternion.identity);

            resetshoot();
        }
        //blaster 2

        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(weapons[1], points[0].position, Quaternion.identity);

            Instantiate(weapons[1], points[1].position, Quaternion.identity);
            resetshoot();
        }

        //laser

        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(weapons[2], points[0].position, Quaternion.identity);

            Instantiate(weapons[2], points[1].position, Quaternion.identity);
            resetshoot();
        }

        //rocket 1
        if (Input.GetKeyDown(KeyCode.L))
        {
            Instantiate(weapons[3], points[2].position, Quaternion.identity);
            resetshoot();

        }
        //rocket 2
        if (Input.GetKeyDown(KeyCode.M))
        {
            Instantiate(weapons[4], points[2].position, Quaternion.identity);
            resetshoot();
        }
    }//shooter

    public void resetshoot()
    {
        canshoot = false;
        shoottimer = Time.time + shoottimethreshhold;
    }
}
