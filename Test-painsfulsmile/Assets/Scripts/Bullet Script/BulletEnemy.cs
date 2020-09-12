using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public GameObject Bullet;
    
    public int speedBullet;
  
    //Rigidbody2D BulletRb;
    public float lifeBullet = 10f;

    private Transform player;
    private Vector2 target;
    Rigidbody2D BulletRb;
    private void Awake()
    {
        


        BulletRb = GetComponent<Rigidbody2D>(); //get component Rigidbody
        /*if (Bullet)
        {
            BulletRb.AddForce(BulletRb.transform.right * speedBullet); //addforce bullet
            Destroy(gameObject, lifeBullet); //Destroy bullet in time life
        }
        if (BulletFliped)
        {
            BulletRb.AddForce(BulletRb.transform.right * speedBullet); //addforce bullet
            Destroy(gameObject, lifeBullet); //Destroy bullet in time life
        }
       */
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        GetTheLastPosiPlayer();
    }
    
    void GetTheLastPosiPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speedBullet * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Islands"))
        { 
            Destroy(gameObject);
        }
    }

}
