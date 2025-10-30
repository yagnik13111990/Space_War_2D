using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXlifeTimer : MonoBehaviour
{
    [SerializeField]
    private float timer = 3f;

    private void Update()
    {
        Destroy(gameObject , timer);
    }
}
