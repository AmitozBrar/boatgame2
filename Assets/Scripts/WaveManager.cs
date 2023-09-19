using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    // Start is called before the first frame update
    public float amplitude = 1f;
    public float length = 2f;
    public float speed = 1f;
    public float offset = 0f;

    public float k = 0f;
    public float f = 0f;


    // Update is called once per frame
    private void Awake()
    {
        if(instance == null){
            instance =  this;
        }
        else if(instance != this){
            Debug.Log("instance exists destroying object");
            Destroy(this);
        }

    }

    private void Update(){
        offset += Time.deltaTime * speed;
        
        

    }

    public float GetWaveHeight(float _x){
       /* k = 2 * Mathf.PI * length;
        f = k * (_x - offset);
        Vector3 tangent = new Vector3(1, k * amplitude * Mathf.Cos(f),0).normalized;
        Vector3 normal = new Vector3(-tangent.y, tangent.x, 0);

        return normal.y;*/

        return amplitude * Mathf.Sin(_x/ length + offset);
    }
}
