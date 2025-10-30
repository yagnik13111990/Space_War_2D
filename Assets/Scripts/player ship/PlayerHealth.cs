using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float playerMaxhealth = 200f;

    [SerializeField]
    private GameObject distroyFX;

    [SerializeField]
    private GameObject demageFX;

    public float playerHealth;

    private Collactable collect;

    private Slider healthSlider;
    private void Awake()
    {
        healthSlider = GameObject.FindWithTag("playerHealth").GetComponent<Slider>();
        playerHealth = playerMaxhealth;
        healthSlider.minValue = 0;
        healthSlider.maxValue = playerHealth;
        healthSlider.value = playerHealth;
    }

    public void TakeDamage(float damageAm)
    {
        playerHealth -= damageAm;
        healthSlider.value = playerHealth;

        if (playerHealth <= 0)
        {
            Instantiate(distroyFX , transform.position , Quaternion.identity);

            SoundManager.Instance.playDestroySound();
            Destroy(gameObject);
            Gameovercontrol.instance.OpenGameOverPanel();
        }

        else
        {
            Instantiate(demageFX , transform.position , Quaternion.identity);

            SoundManager.Instance.playDamageSound();
        }
    }

     
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("collectable"))
        {
            collect = collision.GetComponent<Collactable>();

            if(collect.type == CollactableTypes.Health)
            {
                playerHealth += collect.healthValue;
                healthSlider.value = playerHealth;

                Destroy(collision.gameObject);
                SoundManager.Instance.playPickUpSound();
            }
        }
        if (collision.CompareTag("meteor"))
        {
            TakeDamage(Random.Range(20 , 50));

           // Instantiate(distroyFX , transform.position , Quaternion.identity);
            Destroy(collision.gameObject);

        }
    }

}
