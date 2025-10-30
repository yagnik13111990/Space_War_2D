using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;

public class ShipSpawner : MonoBehaviour
{
    public static ShipSpawner Instance;

    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private Transform[] spawnpoints;

    [SerializeField]
    private float spawnwaittime = 2f;

    private List<GameObject> enemylist = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Start()
    {
       StartCoroutine(spawnenemy(spawnwaittime));
    }
    void SpawnNewEnemy()
    {
        if (enemylist.Count > 0)
            return;

        for(int i=0; i< spawnpoints.Length; i++)
        {
            GameObject newEnemy = Instantiate(enemies[Random.Range(0, enemies.Length)] , 
                spawnpoints[i].position , Quaternion.identity);

            enemylist.Add(newEnemy);
        }
        UiControl.Instance.SetInfo(1);
    }

    IEnumerator spawnenemy(float waittime)
    {
        yield return new WaitForSeconds(waittime);

        SpawnNewEnemy();

    }

    public void checknewspawn(GameObject shipToremove)
    {
        enemylist.Remove(shipToremove);

        if(enemylist.Count == 0)
        StartCoroutine(spawnenemy(spawnwaittime));
    }
}
