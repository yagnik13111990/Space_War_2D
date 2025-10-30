using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilepool : MonoBehaviour
{
    [SerializeField]
    private GameObject[] projectile;

    private int index;

    [SerializeField]
    private List<GameObject> weaponpool = new List <GameObject>();

    public float shootwaittime = 0.2f;

    private float shoottimer;

    private bool isspawn;
    private bool canshoot;
    public bool isEnemy;

    //[SerializeField]
    private GameObject projectileholder;

    [SerializeField]
    private Transform spawnpoint;

    [SerializeField]
    private KeyCode keytopress;


   
    void Awake()
    {
        if (isEnemy) {
            projectileholder = GameObject.FindWithTag("enemyprojectile");
            Resettimer();
                }
        else
            projectileholder = GameObject.FindWithTag("playerprojectile");
    }

    void Update()
    
    {
        if(Time.time > shoottimer)
        {
            canshoot = true;
        }
        Handleplayershoot();
        Handleenemyshoot();
    }

    void Handleplayershoot()
    {
        if (!canshoot || isEnemy)
            return;

        if (Input.GetKeyDown(keytopress))
        {
            GetspawnfromHolderorCreatenew();
            Resettimer();
        }
    }

    void GetspawnfromHolderorCreatenew()
    {
        for(int i=0 ; i < weaponpool.Count; i++)
        {
            if (!weaponpool[i].activeInHierarchy)
            {
                weaponpool[i].transform.position = spawnpoint.transform.position;
                weaponpool[i].SetActive(true);

                isspawn = true;

                break;
            }
           else
                isspawn = false;
       
        }
        if (!isspawn)
        {
            GameObject newProjectile = Instantiate(projectile[Random.Range(index , projectile.Length)], spawnpoint.transform.position, Quaternion.identity);

            newProjectile.transform.SetParent(projectileholder.transform);

            weaponpool.Add(newProjectile);
            isspawn = true;
        }

    }

    void Resettimer()
    {
        canshoot = false;

        if (isEnemy)
            shoottimer = Time.time + Random.Range(shootwaittime, (shootwaittime + 1f));
        else
            shoottimer = Time.time + shootwaittime;

    }
    void Handleenemyshoot()
    {
        if (!isEnemy || !canshoot)
            return;

        Resettimer();
        GetspawnfromHolderorCreatenew();
    }
}
