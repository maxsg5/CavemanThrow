using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    // Start is called before the first frame update

    //public float speed = 800f; // m/s
    private GameObject GameManager;
    private Rigidbody2D rb;
    public AudioClip hitSound;
    public GameObject audioSource;
    public GameObject brokenCannonBall;
    private GameObject brokenCannonBallLive;

    Vector3 currentDirection;
    Vector3 currentPosition;
    Vector3 previousPosition;
    float speed = 0f;
    bool firstShotTaken = false; // used to prevent multiple firings of the same ball
    void Start()
    {
        previousPosition = transform.position;
        //audioSource = GetComponent<AudioSource>();

        GameManager = GameObject.Find("GameManager");
        rb = GetComponent<Rigidbody2D>(); // Get the rigidbody component

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (GameManager.GetComponent<GameManager>().isGameStart == true && GameManager.GetComponent<GameManager>().isGameOver == false)
        {
            // if the ball has not already been fired
            if (firstShotTaken == false)
            {
                speed = Random.Range(450f, 600f); // speed of the ball

                if (transform.position.x > 0)
                {
                    rb.AddForce(new Vector2(-1, 1) * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
                }
                else
                {
                    rb.AddForce(new Vector2(1, 1) * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
                }

                firstShotTaken = true;
            }

            // Check if the ball has left the screen
            if (transform.position.y < -10)
            {
                // Destroy the ball
                Destroy(this.gameObject);
            }
            currentPosition = transform.position;
        }


    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "ball")
        {
            //ball hit floor
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "rock")
        {
            //ball hit rock
            Destroy(other.gameObject);

            //figure out the direction the cannonball was moving
            currentDirection = (currentPosition - previousPosition).normalized;


            //TODO: spawn brokencannonball with force in the direction that the ball was going

            brokenCannonBallLive = Instantiate(brokenCannonBall, transform.position, Quaternion.identity);
            foreach (Transform child in brokenCannonBallLive.transform)
            {
                float spreadSpeed = Random.Range(10f, 30f);
                //print("Foreach loop: " + child);
                child.GetComponent<Rigidbody2D>().AddForce(currentDirection * spreadSpeed, ForceMode2D.Impulse);
            }
            

            //brokenCannonBallLive.GetComponent<Rigidbody2D>().AddForce(currentDirection * 100f, ForceMode2D.Impulse);

            Destroy(this.gameObject);



            GameManager.GetComponent<GameManager>().AddScore(10);
        }
    }
}
