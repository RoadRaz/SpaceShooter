using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //movement speed of bullet
    public float moveSpeed;
    //amount of damage the bullet will do to enemy
    public float power;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the bullet up
        transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
        //destory bullet when outside view area
        if(transform.position.y <= -6)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //hurt player by bullet damage
            other.gameObject.GetComponent<PlayerControl>().health -= this.power;
            //destory the enemy bullet
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Bullet")
        {
            // Destroy both bullets
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
