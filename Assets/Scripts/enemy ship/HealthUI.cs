using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private GameObject healthbar;

    [SerializeField]
    private GameObject DestroyEffect;

    [SerializeField]
    private GameObject HitEffect;

    private Vector3 HealthScale;

    private float health = 100f;

    private DropCollactable dropcol;

    private void Awake()
    {
        dropcol = GetComponent<DropCollactable>();
    }
    public void TakeDamage(float damageAmount , float damageResistance)
    {
        damageAmount -= damageResistance;

        health -= damageAmount;

        if(health <= 0)
        {
            health = 0;
            Instantiate(DestroyEffect , transform.position , Quaternion.identity);

            SoundManager.Instance.playDestroySound();

            if (gameObject.CompareTag("enemy"))
            {
               UiControl.Instance.SetInfo(2);
               ShipSpawner.Instance.checknewspawn(gameObject);

            }
            else if(gameObject.CompareTag("meteor"))
              UiControl.Instance.SetInfo(3);

            dropcol.CheckForDrop();
            Destroy(gameObject);
        }

        else
        {
            Instantiate(HitEffect, transform.position, Quaternion.identity);
            SoundManager.Instance.playDamageSound();
        }
        SetHealthBar();
    }

    public void SetHealthBar()
    {
        if (!healthbar)
            return;
        HealthScale = healthbar.transform.localScale;
        HealthScale.x = health/100f;
        healthbar.transform.localScale = HealthScale;
    }
}
