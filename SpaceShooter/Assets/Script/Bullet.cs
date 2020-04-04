using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        //destory bullet when outside view area
        if(transform.position.y >= 5)
        {
            Destroy(this.gameObject);
        }
    }
}
