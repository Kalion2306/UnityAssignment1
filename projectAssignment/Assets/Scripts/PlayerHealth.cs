using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;


    private void Update()
    {
        if (health <= 0)
        {
            Debug.Log(gameObject + " is destroyed");
            if (gameObject.name.Equals("Player"))
                Time.timeScale = 0;
            else
            {
                Debug.Log("you are dead");
                Time.timeScale = 0;
            }
        }
    }
}
