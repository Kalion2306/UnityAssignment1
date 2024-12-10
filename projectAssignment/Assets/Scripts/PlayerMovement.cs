using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    //sets a changable speed variable
    public float speed = 2;


    //creates a rigidbody for use of movement
    Rigidbody rb;
    InputAction input;


    // Start is called before the first frame update
    void Start()
    {
        //sets up the rigidbody and camera
        rb = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInput>().actions.FindAction("playerMovement");
        input.Enable();
    }


    // Update is called once per frame
    void Update()
    {

        //sets up normalised axial movement
        Vector2 direction = input.ReadValue<Vector2>();

        rb.AddForce(direction.x * speed, 0, direction.y * speed, ForceMode.Impulse);
    }

    private void OnDropKick()
    {
        Debug.Log("Dropkick!");
    }
    


}
