using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
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
                Destroy(gameObject);
            }
        }
    }
}
