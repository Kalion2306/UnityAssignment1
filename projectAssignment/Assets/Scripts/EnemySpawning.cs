using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public float spawnMin = 2f;
    public float spawnMax = 5f;

    const float minMin = 0.5f;
    const float minMax = 1.5f;

    public int avalibleEnemies = 0;
    public GameObject[] enemyTable;
    int minSpawners = 1;
    int maxSpawners = 1;
    public GameObject[] spawners;
    public bool[] usingSpawner; 

    public Transform playerTransform;
    public GameObject pointtransfer;

    float timer = 0;
    float difftimer = 10f;


    // Update is called once per frame
    void Update()
    {
        //if timer reaches 0
        if (timer <= 0)
        {
            for (int i = 0; i < usingSpawner.Length; i++)
            {
                usingSpawner[i] = false;
            }
            //randomises time interval between waves
            timer = Random.Range(spawnMin, spawnMax);

            int getSpawnerCount = Random.Range(minSpawners, maxSpawners);
            bool enoughSpawners = false;
            int spawnercount = 0;
            while (!enoughSpawners)
            {

                int getSpawner = Random.Range(0, usingSpawner.Length - 1);
                if (usingSpawner[getSpawner] != true)
                {
                    usingSpawner[getSpawner] = true;
                    spawnercount++;
                }

                if (spawnercount >= getSpawnerCount)
                {
                    enoughSpawners = true;
                }
            }

            for (int i = 0; i < spawners.Length; i++)
            {
                if (usingSpawner[i] == true)
                {
                    int getEnemy = Random.Range(0, avalibleEnemies);
                    Debug.Log($"instancing {getEnemy}");
                    spawners[i].GetComponent<EnemySpawner>().InstaceEnemy(enemyTable[getEnemy], playerTransform, pointtransfer);
                }
            }

        }

        if (difftimer <= 0) 
        {
            difftimer = 10f;

            //ways to increace difficulty
            
            DiffIncreace();
        }


        //decriments time since last frame
        timer -= Time.deltaTime;
        difftimer -= Time.deltaTime;
    }


    void DiffIncreace()
    {
        while (true)
        {
            int options = Random.Range(0, 5);

            switch (options)
            {
                //decreaces the maximum spawn time
                case 0:
                    if (spawnMax > minMax)
                    {
                        spawnMax -= 0.5f;
                        Debug.Log("reduced Max Spawn cooldown");
                        return;
                    }
                    break;
                //decreaces the minimum spawn time
                case 1:
                    if (spawnMin > minMin)
                    {
                        spawnMin -= 0.5f;
                        Debug.Log("reduced Min Spawn cooldown");
                        return;
                    }
                    break;
                case 2:
                //increaces how many enemy types are avalible
                    if (avalibleEnemies < enemyTable.Length)
                    {
                        avalibleEnemies++;
                        Debug.Log("increaced avalible Enemies");
                        return;
                    }
                    break;
                //increces the maximum usable spawners
                case 3:
                    if (maxSpawners < spawners.Length)
                    {
                        maxSpawners++;
                        Debug.Log("inceaced max spawners used");
                        return;
                    }
                    break;
                //increaces the minimum spawners
                case 4:
                    if (minSpawners < maxSpawners)
                    {
                        minSpawners++;
                        Debug.Log("inceaced min spawners used");
                        return;
                    }
                    break;
                //burst setting
                case 5:
                    for (int i = 0; i < spawners.Length; i++)
                    {
                        int r = Random.Range(0,avalibleEnemies);
                        spawners[i].GetComponent<EnemySpawner>().InstaceEnemy(enemyTable[r],playerTransform,pointtransfer);
                    }
                    Debug.Log("burst");
                    break;
            }
        }
    }
}