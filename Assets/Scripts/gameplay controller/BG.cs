using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{

    [SerializeField]
    private float speed;

    private Material bgmaterial;

    private float yAxis;
    // Start is called before the first frame update
    void Awake()
    {
        bgmaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        yAxis += speed * Time.deltaTime;

        bgmaterial.SetTextureOffset("_MainTex" , new Vector2 (0 , yAxis));
        
    }
}
