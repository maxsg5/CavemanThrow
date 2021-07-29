using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 15F;
    public Transform firePoint;
    public GameObject rock;
    public GameObject GameManager;
    private AudioSource audioSource;
    public GameObject pauseMenu;
    public float fireRate = 0.2F;
    private float nextFire = 0.0F;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //dont do anything until the game has started or if the game is paused or the game is over.
        if (GameManager.GetComponent<GameManager>().isGameStart == true && GameManager.GetComponent<GameManager>().isGameOver == false || GameManager.GetComponent<GameManager>().startCountDown == true)
        {
            //check if player is within bounds before next move.
            PlayerBoundary();
            //get the input
            float horizontal = Input.GetAxis("Horizontal");
            transform.position += new Vector3(horizontal * speed * Time.deltaTime, 0, 0);

            //fire the rock
            if ( Input.GetButtonDown("Fire1") && Time.time > nextFire)
            {
                //play the animation and audio
                anim.Play("PlayerThrow");
                audioSource.PlayOneShot(audioSource.clip);
                //restrict fire rate
                nextFire = Time.time + fireRate; 
                GameObject.Instantiate(rock, firePoint.position, Quaternion.identity);
            }

        }

    }

    void PlayerBoundary()
    {
        //check if player is within bounds.
        float xMovementClamp = Mathf.Clamp(transform.position.x, -7, 7);
        transform.position = new Vector3(xMovementClamp, transform.position.y, transform.position.z);
    }
}
