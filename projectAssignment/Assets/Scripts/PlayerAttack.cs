using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public float rotspeed = 10;

    InputAction mouse;
    InputAction shoot_action;
    InputAction split_action;

    public Camera cam;
    public GameObject mainTarget;
    int timer = 0;


    float Cooldown_Timer = 0;
    public float Cooldown = 0.2f;


    public GameObject[] LeftHand;
    public GameObject[] RightHand;
    public GameObject[] fireOrder;

    int nextshot;



    private void Start()
    {
        mouse = GetComponent<PlayerInput>().actions.FindAction("mousePos");
        mouse.Enable();
        shoot_action = GetComponent<PlayerInput>().actions.FindAction("shoot");
        shoot_action.Enable();

        split_action = GetComponent<PlayerInput>().actions.FindAction("splitAim");
        split_action.Enable();


        nextshot = 0;
    }
    private void Update()
    {
        timer++;
        Cooldown_Timer += Time.deltaTime;

        if (timer >= 5)
        {
            timer = 0;


            Vector2 mousepos = mouse.ReadValue<Vector2>();
            RotateRight(mousepos);
            RotateLeft(mousepos);
        }

        if (Cooldown_Timer >= Cooldown)
        {
            if (shoot_action.ReadValue<float>() == 1)
            {
                fireOrder[nextshot].GetComponent<bulletspawner>().shoot();
                Cooldown_Timer = 0;

                nextshot++;
                if (nextshot >= 4)
                {
                    nextshot = 0;
                }
            }
        }

    }




    void RotateRight(Vector2 target)
    {
        Vector2 mousepos = mouse.ReadValue<Vector2>();


        Ray ray = cam.ScreenPointToRay(mousepos);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);

        int layer_mask = 1 << LayerMask.NameToLayer("Raycast");

        if (Physics.Raycast(ray, out RaycastHit hit, 1000, layer_mask))
        {
            mainTarget.transform.position = hit.point;

            //direction to target
            Vector3 lookat = hit.point - transform.position;
            lookat.y = 0;
            lookat.Normalize();


            for (int h = 0; h < RightHand.Length; h++)
            {
                float angle = Vector3.SignedAngle(RightHand[h].transform.forward, Vector3.Lerp(RightHand[h].transform.forward, lookat, rotspeed * 5 * Time.deltaTime), Vector3.up);
                RightHand[h].transform.RotateAround(transform.position, Vector3.up, angle);
            }
        }
    }


    void RotateLeft(Vector2 target)
    {
        Vector2 mousepos = mouse.ReadValue<Vector2>();


        Ray ray = cam.ScreenPointToRay(mousepos);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);

        int layer_mask = 1 << LayerMask.NameToLayer("Raycast");

        if (Physics.Raycast(ray, out RaycastHit hit, 1000, layer_mask))
        {
            mainTarget.transform.position = hit.point;

            //direction to target
            Vector3 lookat = hit.point - transform.position;
            lookat.y = 0;
            lookat.Normalize();


            for (int h = 0; h < LeftHand.Length; h++)
            {
                float angle = Vector3.SignedAngle(LeftHand[h].transform.forward, Vector3.Lerp(LeftHand[h].transform.forward, lookat, rotspeed * 5 * Time.deltaTime), Vector3.up);
                LeftHand[h].transform.RotateAround(transform.position, Vector3.up, angle);
            }
        }
    }
}
