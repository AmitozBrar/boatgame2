using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionTest : MonoBehaviour
{
    public MeshDestroy death;

    private void Awake()
    {
        death = GetComponent<MeshDestroy>();
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "bullet"){
            print("ENTER");
            death.DestroyMesh();
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
