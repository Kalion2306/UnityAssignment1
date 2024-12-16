using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerAttack : MonoBehaviour
{
    public float rotspeed = 10;

    InputAction mouse;
    InputAction shoot_action;

    public Camera cam;
    public GameObject target;
    public GameObject player;
    int timer = 0;

    float Cooldown_Timer = 0;
    public float Cooldown = 0.2f;

    private void Start()
    {
        mouse = GetComponent<PlayerInput>().actions.FindAction("mousePos");
        mouse.Enable();
        shoot_action = GetComponent<PlayerInput>().actions.FindAction("shoot");
        shoot_action.Enable();
    }
    private void Update()
    {
        timer++;
        Cooldown_Timer += Time.deltaTime;

        if (timer >= 5)
        {
            timer = 0;
            RotatePlayerRaycast();
        }

        if (Cooldown_Timer >= Cooldown)
        {
            if (shoot_action.ReadValue<float>() == 1)
            {
                print("shooting");
                shoot();
                Cooldown_Timer = 0;
            }
        }

    }


    public GameObject bullet;
    public void shoot()
    {
        GameObject bulletInstance = GameObject.Instantiate(bullet);
        bulletInstance.transform.position = transform.position;
        bulletInstance.transform.rotation = transform.rotation;
    }


    void RotatePlayerRaycast()
    {
        Vector2 mousepos = mouse.ReadValue<Vector2>();


        Ray ray = cam.ScreenPointToRay(mousepos);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);

        int layer_mask = 1 << LayerMask.NameToLayer("Raycast");

        if (Physics.Raycast(ray, out RaycastHit hit, 1000, layer_mask))
        {
            target.transform.position = hit.point;

            //direction to target
            Vector3 lookat = hit.point - transform.position;
            lookat.y = 0;
            lookat.Normalize();

            Debug.DrawRay(transform.position, transform.forward * 10, Color.yellow);
            Debug.DrawRay(transform.position, lookat * 10, Color.red);


            float angle = Vector3.SignedAngle(transform.forward, Vector3.Lerp(transform.forward, lookat, rotspeed * 5 * Time.deltaTime), Vector3.up);
            transform.RotateAround(player.transform.position, Vector3.up, angle);
        }
    }
}
