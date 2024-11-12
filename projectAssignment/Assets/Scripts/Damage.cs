using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 2;
    Rigidbody rb;
    public string[] exclusionList;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.name.Equals(exclusionList))
        {
            if (other.GetComponent<Health>())
            {
                Debug.Log("dealt damage to enemy");
                other.GetComponent<Health>().health -= damage;
            }
        }
    }
}
