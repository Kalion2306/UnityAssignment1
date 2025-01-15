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
    public GameObject altTarget;


    float Cooldown_Timer = 0;
    public float Cooldown = 0.2f;


    public GameObject[] LeftHand;
    public GameObject[] RightHand;
    public GameObject[] fireOrder;




    Vector2 splitpos;
    public int activeGuns = 2;

    int nextshot;


    //sets up inputs
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
        Cooldown_Timer += Time.deltaTime;


        Vector3 targetlock = mainTarget.transform.position - transform.position;
        Vector3 altLock = altTarget.transform.position - transform.position;

        float handcheck = Vector3.SignedAngle(altLock, targetlock, Vector3.up);


        //handcount
        if (activeGuns >= 3)
        {
            LeftHand[1].SetActive(true);
        }
        else
        {
            LeftHand[1].SetActive(false);
        }

        if (activeGuns >= 4)
        {
            RightHand[1].SetActive(true);
        }
        else
        {
            RightHand[1].SetActive(false);
        }


        //aiming


            Vector2 mousepos = mouse.ReadValue<Vector2>();


            //if not splitting set the altfire to match, stop when splitting to freeze the current position
            if (split_action.ReadValue<float>() == 0) 
            {
                splitpos = mousepos;
                altTarget.transform.position = mainTarget.transform.position;
                altTarget.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                altTarget.GetComponent<Renderer>().enabled = true;
            }

            if (handcheck < 0)
            {
                RotateSplitGuns(splitpos,RightHand);
                RotateGuns(mousepos,LeftHand);
            }
            else
            {
                RotateGuns(mousepos,RightHand);
                RotateSplitGuns(splitpos,LeftHand);
            }

            

        //players rotation
        Vector3 lookat = (targetlock.normalized + altLock.normalized).normalized;

        lookat.y = 0;

        transform.forward = Vector3.Lerp(transform.forward,lookat,0.1f);


        //shooting
        if (Cooldown_Timer >= Cooldown)
        {
            if (shoot_action.ReadValue<float>() == 1)
            {
                fireOrder[nextshot].GetComponent<bulletspawner>().shoot();
                Cooldown_Timer = 0;

                //makes the guns shoot in any sequance I want from 1 to 4
                nextshot++;
                if (nextshot >= activeGuns)
                {
                    nextshot = 0;
                }
            }
        }

    }



    //makes rotations happen smoothley
    void RotateGuns(Vector2 position,GameObject[] hand)
    {
        Vector2 mousepos = mouse.ReadValue<Vector2>();


        Ray ray = cam.ScreenPointToRay(position);

        int layer_mask = 1 << LayerMask.NameToLayer("Raycast");

        if (Physics.Raycast(ray, out RaycastHit hit, 1000, layer_mask))
        {
            mainTarget.transform.position = hit.point;

            //direction to target
            Vector3 lookat = hit.point - transform.position;
            lookat.y = 0;
            lookat.Normalize();


            for (int h = 0; h < hand.Length; h++)
            {
                float angle = Vector3.SignedAngle(hand[h].transform.forward, Vector3.Lerp(hand[h].transform.forward, lookat, rotspeed * 5 * Time.deltaTime), Vector3.up);
                hand[h].transform.RotateAround(transform.position, Vector3.up, angle);
            }
        }
    }

    //same as above function, but doesn't set the targets position to avoid instant swapping
    void RotateSplitGuns(Vector2 position, GameObject[] hand)
    {
        Vector2 mousepos = mouse.ReadValue<Vector2>();


        Ray ray = cam.ScreenPointToRay(position);

        int layer_mask = 1 << LayerMask.NameToLayer("Raycast");

        if (Physics.Raycast(ray, out RaycastHit hit, 1000, layer_mask))
        {

            //direction to target
            Vector3 lookat = hit.point - transform.position;
            lookat.y = 0;
            lookat.Normalize();


            for (int h = 0; h < hand.Length; h++)
            {
                float angle = Vector3.SignedAngle(hand[h].transform.forward, Vector3.Lerp(hand[h].transform.forward, lookat, rotspeed * 5 * Time.deltaTime), Vector3.up);
                hand[h].transform.RotateAround(transform.position, Vector3.up, angle);
            }
        }
    }
}
