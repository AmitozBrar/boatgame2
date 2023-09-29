using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatcontroller2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform orientation;
    Rigidbody rb;
    public float playerSpeed = 2.0f;
    //private CharacterController controller;
    
    public float sensX;
    public float sensY;
    float xRotation;
    float yRotation;

    public GameObject cannonball;

    public GameObject particle;
    public Transform Barrel;
    Collider hitbox;

    private float lastShot;
    public float cooldown;
    Vector3 moveDirection;

    public float force;
    private float x;
    private float y;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        x=0;
        y=0;
        hitbox = GetComponent<Collider>();

        Debug.Log("Trigger On : " + hitbox.isTrigger);
    }

    void Update()
    {
        MyInput();
    }
    private void MyInput(){
         if(Input.GetKey(KeyCode.W)){
            y =1;
        }
        if(Input.GetKey(KeyCode.S)){
            y =-1;
        }
         if(Input.GetKey(KeyCode.D)){
            x=1;
        }
         if(Input.GetKey(KeyCode.A)){
            x =-1;
        }
        if(Input.GetKeyUp(KeyCode.A)|| Input.GetKeyUp(KeyCode.D)){
            x=0;
        }
        if(Input.GetKeyUp(KeyCode.W)|| Input.GetKeyUp(KeyCode.S)){
            y=0;
        }
    }


    private void MovePlayer(){
        
        float mouseX = x * Time.deltaTime *sensX;
        float mouseY = y * Time.deltaTime *sensY;
        
        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation,0 );
        moveDirection = orientation.forward * y + orientation.right * 0;
 
        rb.AddForce(moveDirection.normalized * playerSpeed * 10f, ForceMode.Force);
    }
    // Update is called once per frame
    public void shoot(){
        
        if(Time.time - lastShot < cooldown){
        }
        else{
            //Debug.Log("not ready");
            lastShot = Time.time;
            GameObject bullet = Instantiate(cannonball, Barrel.position, Barrel.rotation);
            bullet.GetComponent<Rigidbody>().velocity = Barrel.forward * force ;
            Instantiate(particle, Barrel.position ,Quaternion.identity);
        }
        
        
    }
    
    void FixedUpdate()
    {
       MovePlayer();

       if(Input.GetKey(KeyCode.R)){//if(trigger){
        shoot();
       }
       
    }
}
