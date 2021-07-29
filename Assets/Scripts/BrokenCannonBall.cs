using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenCannonBall : MonoBehaviour
{

    
     private GameObject GameManager;
     public float TimetillDeath = 2f;
    // Start is called before the first frame update
    void Start()
    {
        // find all the fragments and give them a velocity
        //     for (int i = 1; i < 9; i++)
        //     {
        //         //Fragments.Add(transform.Find("Fragment"+i.ToString()).gameObject);
        //         transform.Find("Fragment" + i.ToString()).gameObject.GetComponent<Rigidbody2D>().AddForce(currentDirection * speed, ForceMode2D.Impulse);
        //     }

        // transform.Find("Fragment").gameObject.GetComponent<Rigidbody2D>().AddForce(currentDirection * speed);
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetComponent<GameManager>().isGameStart == true && GameManager.GetComponent<GameManager>().isGameOver == false){

            TimetillDeath -= Time.deltaTime;
           
            if (TimetillDeath <= 0)
            {
                Destroy(this.gameObject);
            }
            // Check if the ball has left the screen
            if (transform.position.y < -10)
            {
                // Destroy the ball
                Destroy(this.gameObject);
            }
        }
    }

     

    //function to compare two dates
    

}
