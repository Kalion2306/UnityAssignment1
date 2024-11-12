using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float timer = 0;
    public float spawnrate = 5;
    public GameObject enemy;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnrate)
        {
            timer = 0;
            Instantiate(enemy,transform.position + transform.forward * 2, Quaternion.identity);
            enemy.GetComponent<Enemy>().playerTransform = playerTransform;
        }
    }
}
