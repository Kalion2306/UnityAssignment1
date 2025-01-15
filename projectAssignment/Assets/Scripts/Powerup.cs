using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    PlayerAttack guns;
    float powertime = 10;

    private void Start()
    {
        guns = GetComponent<PlayerAttack>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "PowerUp")
        {
            powertime = 10;
            if (guns.activeGuns < 4)
            {
                guns.activeGuns++;
                guns.Cooldown = 0.4f / guns.activeGuns;
            }
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        powertime -= Time.deltaTime;

        if (powertime < 0)
        {
            guns.activeGuns = 2;
            guns.Cooldown = 0.2f;
        }
    }
}
