using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    
    private Vector2 movementInput = Vector2.zero;
    private Vector2 rotateInput = Vector2.zero;

     float HorizontalInput;
    float VerticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    // Start is called before the first frame update

    public float sensX;
    public float sensY;

 public Transform orientation;
    float xRotation;
    float yRotation;

    public bool trigger = false;
    public GameObject cannonball;
    public Transform Barrel;

    public float force;
    private void Start()
    {
       rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //controller = gameObject.GetComponent<CharacterController>();
    }

    

    public void OnMove(InputAction.CallbackContext context){
        movementInput = context.ReadValue<Vector2>();
        //Debug.Log(movementInput);
    }

    public void OnShoot(InputAction.CallbackContext context){
        trigger = context.ReadValue<float>() > 0.5f; // ReadValue returns a float for buttons
        if (trigger)
        {
            Debug.Log("Shoot button pressed");
        }
    }

    public void OnRotation(InputAction.CallbackContext context){
        rotateInput = context.ReadValue<Vector2>();
        //Debug.Log(rotateInput);
    }

    

    void Update()
    {
        
        MyInput();
        //Vector3 move = new Vector3(movementInput.x, 0,movementInput.y);
        //controller.Move(move * Time.deltaTime * playerSpeed);

        
    }
    private void MyInput(){
        HorizontalInput = 0 ; //Input.GetAxisRaw("Horizontal");
        //VerticalInput = Input.GetAxisRaw("Vertical");
        VerticalInput = movementInput.y;
    }


    private void MovePlayer(){
        float mouseX = rotateInput.x * Time.deltaTime *sensX;
        float mouseY = rotateInput.y * Time.deltaTime *sensY;
        
        
        yRotation += mouseX;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation,0 );
        moveDirection = orientation.forward * VerticalInput + orientation.right * HorizontalInput;

        rb.AddForce(moveDirection.normalized * playerSpeed * 10f, ForceMode.Force);
    }
    // Update is called once per frame

    
    void FixedUpdate()
    {
       MovePlayer();

       if(trigger){
            GameObject bullet = Instantiate(cannonball, Barrel.position, Barrel.rotation);
            bullet.GetComponent<Rigidbody>().velocity = Barrel.forward * force * Time.deltaTime;
        }
    }
}


