using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsticle : MonoBehaviour
{
    public int health = 50;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            health--;
            if (health < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
