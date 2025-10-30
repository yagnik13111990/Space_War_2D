using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("projectile"))
        
            collision.gameObject.SetActive(false);

        if (collision.CompareTag("meteor") || collision.CompareTag("collectable"))
        {
            Destroy(collision.gameObject);
        }
    }
}
