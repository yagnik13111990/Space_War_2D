using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilelifetimer : MonoBehaviour
{
    [SerializeField]
    private float timer = 3f;

    private void OnEnable()
    {
        Invoke("Deactivate", timer);
    }

    private void OnDisable()
    {
        CancelInvoke("Deactivate");
    }

    void Deactivate()
    {
       if(gameObject.activeInHierarchy)
            gameObject.SetActive(false);

    }
}
