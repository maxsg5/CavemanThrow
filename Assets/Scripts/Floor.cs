using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //collison detection
    void OnCollisionEnter2D(Collision2D other){
        
        if (other.gameObject.tag == "ball"){
            //ball hit floor
            Destroy(other.gameObject);
        }
    }
}
