using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCollactable : MonoBehaviour
{
    [SerializeField]
    private GameObject[] collactables;

    public void CheckForDrop()
    {
        if(Random.Range(0,2) > 0)
        {
            Instantiate(collactables[Random.Range(0 , collactables.Length)] , 
                transform.position , Quaternion.identity);
        }
    }
}
