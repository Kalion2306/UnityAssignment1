using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float lifetime = 2;
    public float bulletspeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,lifetime);
        GetComponent<Rigidbody>().AddForce(transform.forward * bulletspeed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("GameWorld"))
        {
            Destroy(gameObject);
        }

        if (other.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
        }

        if (other.tag.Equals("Shield"))
        {
            Destroy(gameObject);
        }
    }
}
