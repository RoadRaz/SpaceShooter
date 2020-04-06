using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //the initial health of the enemy
    public float health;
    //the amount  of damage down to player when collide
    public float power;
    //movement speed of enemy
    public float moveSpeed;

    public float delay;
    public float firerate;
    public GameObject enemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        // For interval shooting
        InvokeRepeating("Shoot", Random.Range(delay, delay+2), Random.Range(firerate, firerate+5));
    }

    // Update is called once per frame
    void Update()
    {
        //slowly moving down
        transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);

        if (health <= 0)
        {
            //when health is below 0, destory this enemy
            Destroy(this.gameObject);
        }

        // Destroy enemy when out of scene
        if (transform.position.y < -6.0f)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //when bullet hit enemy
        if(collision.gameObject.tag == "Bullet")
        {
            //hurt enemy with power of bullet
            health -= collision.gameObject.GetComponent<Bullet>().power;
            //destory the bullet
            Destroy(collision.gameObject);
        }
        //when enemy hit player
        else if(collision.gameObject.tag == "Player")
        {
            //hurt player by it's damage taken
            collision.gameObject.GetComponent<PlayerControl>().TakeDamage(power);
            //destory this enemy
            Destroy(this.gameObject);
        }
    }

    void Shoot()
    {
        Instantiate(enemyBullet, transform.position + new Vector3(0, -0.8f, 0), new Quaternion(0, 0, 0, 0));
    }
}
