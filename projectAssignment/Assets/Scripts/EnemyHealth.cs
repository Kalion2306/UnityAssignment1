using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 5;
    public int points = 100;
    public GameObject pointtransfer;
    public GameObject powerup;


    private void Start()
    {
        if (pointtransfer == null)
        {
            Destroy(gameObject);
        }    
    }

    private void Update()
    {
        if (health <= 0)
        {
            pointtransfer.GetComponent<points>().score += points;
            
            int powerupchance = Random.Range(0, 4);
            Debug.Log(powerupchance);
            if (powerupchance == 0)
            {
                Debug.Log("summonpowerup");
                Instantiate(powerup,transform.position,Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}
