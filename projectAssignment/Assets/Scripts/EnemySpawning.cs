using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    float timer = 0f;
    public float spawnMin = 1f;
    public float spawnMax = 5f;


    public GameObject[] enemies;
    public GameObject[] spawners;

    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(spawnMin, spawnMax);
    }

    // Update is called once per frame
    void Update()
    {

        if (timer <= 0f)
        {
            int randSpawner = Random.Range(0, spawners.Length);
            int randEnemy = Random.Range(0, enemies.Length);
            timer = Random.Range(spawnMin, spawnMax);
            spawners[randSpawner].GetComponent<EnemySpawner>().InstaceEnemy(enemies[randEnemy], playerTransform);
        }

        timer -= 1 * Time.deltaTime;
    }
}
