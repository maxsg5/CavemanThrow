using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private GameObject GameManager;
    public float speed = 15f;
    //bool firstShotTaken = false; // used to prevent multiple firings of the same ball
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");

    }

    // Update is called once per frame
    void Update()
    {


        transform.position += Vector3.up * speed * Time.deltaTime;

        if (transform.position.y > 20)
        {
            Destroy(this.gameObject);
        }



    }
}
