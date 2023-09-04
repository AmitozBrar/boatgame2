using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionTest : MonoBehaviour
{
    public MeshDestroy death;
    public float health = 3;

    public GameObject particle;

        public Transform hitLocation;
    private void Awake()
    {
        death = GetComponent<MeshDestroy>();
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "bullet"){
            print("ENTER");
            health -= 1;

            if(health == 0){
                death.DestroyMesh();
            }
            Instantiate(particle, hitLocation.position,Quaternion.identity);
            
        }
    }
    void OnTriggerStay(Collider other){
        if(other.gameObject.tag == "bullet"){
            print("STAY");
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "bullet"){
            print("EXIT");
        }
    }
}
