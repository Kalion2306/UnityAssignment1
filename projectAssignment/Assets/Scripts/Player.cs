using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    //sets a changable speed variable
    public float speed = 2;

    //creates a rigidbody for use of movement
    Rigidbody rb;
    InputAction input;
    InputAction mouse;

    public Camera cam;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        //sets up the rigidbody and camera
        rb = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInput>().actions.FindAction("playerMovement");
        input.Enable();

        mouse = GetComponent<PlayerInput>().actions.FindAction("mousePos");
        mouse.Enable();

    }

    // Update is called once per frame
    void Update()
    {

        //sets up normalised axial movement
        Vector2 direction = input.ReadValue<Vector2>();

        rb.AddForce(direction.x * speed, 0, direction.y * speed, ForceMode.Impulse);





        RotatePlayerRaycast();
    }
    
    public void OnShoot()
    {
        transform.GetChild(1).GetComponent<bulletspawner>().shoot();
    }

    void RotatePlayerRaycast()
    {
        Vector2 mousepos = mouse.ReadValue<Vector2>();


        Ray ray = cam.ScreenPointToRay(mousepos);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);

        int layer_mask = 1 << LayerMask.NameToLayer("Raycast");

        if (Physics.Raycast(ray, out RaycastHit hit, 1000, layer_mask))
        {
            Vector3 lookat = hit.point;

            

            lookat.y = 1;
            transform.LookAt(lookat);
            target.transform.position = lookat;

        }
    }
}
