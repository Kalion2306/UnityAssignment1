using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour
{
    public int health = 20;
    public GameObject losesign;
    public bool invulnerable;

    private void Start()
    {
        losesign.SetActive(false);
    }

    private void Update()
    {

        if (health <= 0)
        {
                losesign.SetActive(true);
                Time.timeScale = 0;
        }
    }

    void OnInvulnerability()
    {
        if (!invulnerable)
        {
            invulnerable = true;
        }
        else
        {
            invulnerable = false;
        }
    }
}
