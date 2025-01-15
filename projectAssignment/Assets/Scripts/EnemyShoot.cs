using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShoot : MonoBehaviour
{
    public Transform playertransform;
    public float range;
    public float firerate;
    public GameObject bulletspawner;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (playertransform == null)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, playertransform.position);

        if (distance <= range)
        {
            if (timer <= 0)
            {
                bulletspawner.GetComponent<bulletspawner>().shoot();
                timer = firerate;
            }
            
            
        }
        timer -= Time.deltaTime;
    }
}
