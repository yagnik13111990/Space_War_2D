using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CollactableTypes // outside the --class-- so that we can access outside this --script--
{
    Rocket,
    Blaster1,
    Blaster2,
    Health,
    Misile
}
public class Collactable : MonoBehaviour
{

    [SerializeField]
    private float movespeed = 5f;

    private Vector3 tempPos;

    [HideInInspector]
    public float healthValue;

    public CollactableTypes type;

    private float minHealth = 30f, maxHealth = 50f;

    private void Start()
    {
        healthValue = Random.Range(minHealth, maxHealth);
    }
    private void Update()
    {
        tempPos = transform.position;
        tempPos.y -= movespeed * Time.deltaTime;
        transform.position = tempPos;
    }
}
