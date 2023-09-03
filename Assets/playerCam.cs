using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerCam : MonoBehaviour
{
    // Start is called before the first frame update
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private CharacterController controller;
    private void Awake(){
        controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxisRaw("Horizontal")* Time.deltaTime *sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y")* Time.deltaTime *sensY;
        
        yRotation += mouseX;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation,0 );

    }
}
