using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControl : MonoBehaviour
{
    //movement speed of the player
    public float moveSpeed;
    //prefab for the bullet
    public GameObject bullet;
    //player health
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        //set start position
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //move the player based on user input
        Movement();

        //when space is hit, fire a bullet
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        }

        //open game over scene when player health below 0
        if(health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void Movement()
    {
        //get input on x and y axis
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //calculate new position
        transform.Translate(Vector3.right * moveSpeed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * moveSpeed * verticalInput * Time.deltaTime);

        //make sure player don't go beyond the screen
        if(transform.position.x >= 10.3f)
        {
            transform.position = new Vector3(10.3f, transform.position.y, transform.position.z);
        }

        if (transform.position.x <= -10.3f)
        {
            transform.position = new Vector3(-10.3f, transform.position.y, transform.position.z);
        }

        if (transform.position.y >= 4.5f)
        {
            transform.position = new Vector3(transform.position.x, 4.5f, transform.position.z);
        }

        if (transform.position.y <= -4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, transform.position.z);
        }

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

}
