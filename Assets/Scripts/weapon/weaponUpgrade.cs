using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponUpgrade : MonoBehaviour
{
    [SerializeField]
    private projectilepool[] weapons;

    public void ActivateWeapon(int index)
    {
        weapons[index].enabled = true;
    }
}
