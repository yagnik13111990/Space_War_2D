using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed = 3f;

    [SerializeField]
    private GameObject boomeffect;

    public int minDamage = 5;
    public int maxDamage = 6;

    private int damagerange;

    [SerializeField]
    private AudioClip spawnaudio;

    [SerializeField]
    private AudioClip destroysound;

   

    private void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
       
        damagerange = Random.Range(minDamage, maxDamage);
    }
    private void OnEnable()
    {
        if (spawnaudio)
            AudioSource.PlayClipAtPoint(spawnaudio, new Vector3(0f, 6f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damagerange);
        }

        if (collision.CompareTag("enemy") || collision.CompareTag("meteor"))
        {
            collision.GetComponent<HealthUI>().TakeDamage(damagerange, 0f);

        }

        

    }
}
