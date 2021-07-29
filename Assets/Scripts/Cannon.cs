using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannonBall;
    public GameObject GameManager;
    public Transform firePointLeft;
    public Transform firePointRight;
    public AudioClip impact;
    private AudioSource audioSource;
    public float fireRate = 1F;
    private float nextFire = 5.0F;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // if game is not started, then do nothing
        if (GameManager.GetComponent<GameManager>().isGameStart == true && GameManager.GetComponent<GameManager>().isGameOver == false)
        {

            FireBall();

        }

    }
    //shoots a ball from the cannon at the specified fireRate.
    void FireBall()
    {

        if (Time.time > nextFire)
        {
            float randomInterval = Random.Range(1.0f, 2.5f); //.5 to 2.5 seconds for a random interval
            int direction = Random.Range(0, 2); //0 for left, 1 for right
            nextFire = Time.time + randomInterval; //set the next fire time

            if (direction == 0)
            {
                Instantiate(cannonBall, firePointLeft.position, firePointLeft.rotation);
            }
            else
            {
                Instantiate(cannonBall, firePointRight.position, firePointRight.rotation);
            }
            
            audioSource.PlayOneShot(impact);

        }
    }
}
