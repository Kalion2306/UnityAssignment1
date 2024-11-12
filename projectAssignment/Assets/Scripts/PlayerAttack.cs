using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerAttack : MonoBehaviour
{

    public void OnShoot()
    {
        Debug.Log("shoot");
        transform.GetChild(1).GetComponent<bulletspawner>().shoot();
    }
}
