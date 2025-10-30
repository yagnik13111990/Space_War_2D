using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enginefire : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem[] enginefire;

    [SerializeField]
    private int emitpower = 4;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            emit(4, emitpower);
            emit(5,emitpower);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            emit(0, emitpower);
            emit(1,emitpower);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
            emit(3,emitpower);

        if (Input.GetKey(KeyCode.RightArrow))
            emit(2, emitpower);
    }

    private void emit(int index , int emitpower)
    {
        enginefire[index].Emit(emitpower);
    }
}
