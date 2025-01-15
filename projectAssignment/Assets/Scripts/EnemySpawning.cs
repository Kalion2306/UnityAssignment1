using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    float timer = 0f;
    public float spawnMin = 2f;
    public float spawnMax = 5f;


    public GameObject[] enemies;
    public GameObject[] spawners;

    public Transform playerTransform;
    public GameObject pointtransfer;

    int once = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnMin = 2;
        spawnMax = 5;

        timer = Random.Range(spawnMin, spawnMax);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer <= 0f)
        {
            

            if (GetComponentInParent<GameState>().gameTimer > 50)
            {
                int randEnemy = Random.Range(0, 100);
                int randSpawner = Random.Range(0, spawners.Length);
                randEnemy = 0;

                spawnMin = 2;
                spawnMax = 5;
                spawners[randSpawner].GetComponent<EnemySpawner>().InstaceEnemy(enemies[randEnemy], playerTransform, pointtransfer);
            }

            if (GetComponentInParent<GameState>().gameTimer > 40 && GetComponentInParent<GameState>().gameTimer < 50)
            {
                int randEnemy = Random.Range(0, 100);
                int randSpawner = Random.Range(0, spawners.Length);
                
                if (randEnemy < 10)
                {
                    randEnemy = 2;
                }
                else if (randEnemy > 60)
                {
                    randEnemy = 1;
                }
                else
                {
                    randEnemy = 0;
                }

                spawnMin = 2;
                spawnMax = 4;
                spawners[randSpawner].GetComponent<EnemySpawner>().InstaceEnemy(enemies[randEnemy], playerTransform, pointtransfer);
            }

            if (GetComponentInParent<GameState>().gameTimer > 30 && GetComponentInParent<GameState>().gameTimer < 40)
            {
                int randEnemy = Random.Range(0, 100);
                int randSpawner = Random.Range(0, spawners.Length);
                if (randEnemy < 10)
                {
                    randEnemy = 3;
                }
                else if (randEnemy > 75)
                {
                    randEnemy = 2;
                }
                else if(randEnemy > 75 && randEnemy < 50)
                {
                    randEnemy = 1;
                }    
                else
                {
                    randEnemy = 0;
                }

                spawnMin = 1.5f;
                spawnMax = 3.5f;
                spawners[randSpawner].GetComponent<EnemySpawner>().InstaceEnemy(enemies[randEnemy], playerTransform, pointtransfer);
            }

            if (GetComponentInParent<GameState>().gameTimer > 20 && GetComponentInParent<GameState>().gameTimer < 30)
            {

                once++;
                if (once <= 1)
                {
                    for (int i = 0; i < spawners.Length; i++)
                    {
                        int randEnemy = Random.Range(0, 100);

                        if (randEnemy < 10)
                        {
                            randEnemy = 0;
                        }
                        else if (randEnemy > 75)
                        {
                            randEnemy = 3;
                        }
                        else if (randEnemy > 75 && randEnemy < 50)
                        {
                            randEnemy = 1;
                        }
                        else
                        {
                            randEnemy = 2;
                        }

                        spawners[i].GetComponent<EnemySpawner>().InstaceEnemy(enemies[randEnemy], playerTransform, pointtransfer);
                        spawnMin = 1.5f;
                        spawnMax = 3;
                    }
                }
                else
                {
                    int randEnemy = Random.Range(0, 100);
                    int randSpawner = Random.Range(0, spawners.Length);

                    if (randEnemy < 10)
                    {
                        randEnemy = 0;
                    }
                    else if (randEnemy > 75)
                    {
                        randEnemy = 3;
                    }
                    else if (randEnemy > 75 && randEnemy < 50)
                    {
                        randEnemy = 1;
                    }
                    else
                    {
                        randEnemy = 2;
                    }

                    spawners[randSpawner].GetComponent<EnemySpawner>().InstaceEnemy(enemies[randEnemy], playerTransform, pointtransfer);
                    spawnMin = 1.5f;
                    spawnMax = 3;
                }
            }

            if (GetComponentInParent<GameState>().gameTimer > 10 && GetComponentInParent<GameState>().gameTimer < 20)
            {
                int randEnemy = Random.Range(0, 100);
                int randSpawner = Random.Range(0, spawners.Length);

                if (randEnemy < 20)
                {
                    randEnemy = 3;
                }
                else if (randEnemy > 90)
                {
                    randEnemy = 0;
                }
                else if (randEnemy < 90 && randEnemy > 70)
                {
                    randEnemy = 1;
                }
                else
                {
                    randEnemy = 2;
                }

                spawners[randSpawner].GetComponent<EnemySpawner>().InstaceEnemy(enemies[randEnemy], playerTransform, pointtransfer);
                spawnMin = 1.5f;
                spawnMax = 2.5f;
            }

            if (GetComponentInParent<GameState>().gameTimer < 10)
            {
                int randEnemy = Random.Range(0, 100);
                int randSpawner = Random.Range(0, spawners.Length);
                
                if (randEnemy > 50)
                {
                    randEnemy = 2;
                }
                else
                {
                    randEnemy = 3;
                }

                spawners[randSpawner].GetComponent<EnemySpawner>().InstaceEnemy(enemies[randEnemy], playerTransform, pointtransfer);
                spawnMin = 1;
                spawnMax = 2;
            }

            timer = Random.Range(spawnMin, spawnMax);
        }

        timer -= 1 * Time.deltaTime;
    }
}