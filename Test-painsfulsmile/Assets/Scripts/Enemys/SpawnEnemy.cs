using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] Enemys;
    public Transform[] pointsSpawn;

     float waitSpawn;
    public float startSpawn;

    private int randomSpawn;
    private int randomEnemy;

    private void Awake()
    {
        startSpawn = PlayerPrefs.GetFloat("TimeSpawn", 0);
    }
    
    void Start()
    {
        waitSpawn = startSpawn;
        randomSpawn = Random.Range(0, pointsSpawn.Length);
        randomEnemy = Random.Range(0, Enemys.Length);
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
        
    }

    void Spawn()
    {
        randomSpawn = Random.Range(0, pointsSpawn.Length);
        if (waitSpawn < 0)
        {
            randomSpawn = Random.Range(0, pointsSpawn.Length);
            randomEnemy = Random.Range(0, Enemys.Length);
            Instantiate(Enemys[randomEnemy], pointsSpawn[randomSpawn].position, Enemys[randomEnemy].transform.rotation);
            waitSpawn = startSpawn;
        }
        else
        {
            waitSpawn -= Time.deltaTime;
        }
    }
    
}
