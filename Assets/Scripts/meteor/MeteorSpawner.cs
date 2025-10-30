using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] meteor;

    [SerializeField]
    private float mininterval = 6f, maxinterval = 15f;

    [SerializeField]
    private int minNum = 1, maxNum = 4;

    [SerializeField]
    private float minX, maxX;

    private Vector3 randspawnpoint;

    private int randspawnNum;

    private void Start()
    {
        Invoke("SpawnMeteor" , Random.Range(mininterval, maxinterval));
    }
    void SpawnMeteor()
    {
        randspawnNum = Random.Range(minNum, maxNum);

        for(int i=0; i < randspawnNum; i++)
        {
            randspawnpoint = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);

            Instantiate(meteor[Random.Range(0 , meteor.Length)] , randspawnpoint ,Quaternion.identity);
        }
        Invoke("SpawnMeteor", Random.Range(mininterval, maxinterval));
    }
}
