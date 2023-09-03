using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class shooting : MonoBehaviour
{
    public GameObject cannonball;
    public Transform Barrel;

    public float force;

    private CharacterController controller;

    public bool trigger;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void OnShoot(InputAction.CallbackContext context){
        trigger = context.ReadValue<float>() > 0.5f; // ReadValue returns a float for buttons
        if (trigger)
        {
            Debug.Log("Shoot button pressed");
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if(trigger){
            GameObject bullet = Instantiate(cannonball, Barrel.position, Barrel.rotation);
            bullet.GetComponent<Rigidbody>().velocity = Barrel.forward * force * Time.deltaTime;
        }
    }
}
