using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerUpgrade : MonoBehaviour
{
    [SerializeField]
    private weaponUpgrade weaponUpgrade;

    private Collactable collect;


    void Destroyweapon(Collactable coll)
    {
        if(coll.type != CollactableTypes.Health)
            Destroy(coll.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("collectable"))
        {
            collect = collision.GetComponent<Collactable>();

            if (collect.type == CollactableTypes.Blaster1)
                weaponUpgrade.ActivateWeapon(0);

            if (collect.type == CollactableTypes.Blaster2)
                weaponUpgrade.ActivateWeapon(1);

            if (collect.type == CollactableTypes.Misile)
                weaponUpgrade.ActivateWeapon(2);

            if (collect.type == CollactableTypes.Rocket)
                weaponUpgrade.ActivateWeapon(3);

            SoundManager.Instance.playPickUpSound();

            Destroyweapon(collect);
        }
    }


}
