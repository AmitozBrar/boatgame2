using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    
    // Start is called before the first frame update
    public Rigidbody rigidBodyFloat;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    public float floaterCount = 1f;

    public float waterDrag = 0.99f;

    public float waterAngularDrag = 0.5f;

    // Update is called once per frame
    private void FixedUpdate()
    {

        rigidBodyFloat.AddForceAtPosition(Physics.gravity/floaterCount , transform.position,ForceMode.Acceleration);

        float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x);
        //float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x) + WaveManager.instance.transform.position.y;
        if(transform.position.y < waveHeight){
            float displacementMultiplier = Mathf.Clamp01((waveHeight-transform.position.y) / depthBeforeSubmerged)* displacementAmount;
            rigidBodyFloat.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y)* displacementMultiplier, 0f),transform.position, ForceMode.Acceleration);
            rigidBodyFloat.AddForce(displacementMultiplier * -rigidBodyFloat.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rigidBodyFloat.AddTorque(displacementMultiplier * -rigidBodyFloat.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        
        }
    }
}