using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public void InstaceEnemy(GameObject enemy, Transform playerTransform)
    {
        Instantiate(enemy, transform.position + transform.forward * 2, Quaternion.identity);
        enemy.GetComponent<Enemy>().playerTransform = playerTransform;
    }
}
