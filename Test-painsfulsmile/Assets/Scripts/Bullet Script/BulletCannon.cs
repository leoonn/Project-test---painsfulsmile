using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCannon : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject BulletFliped;
    public int speedBullet;
  
    Rigidbody2D BulletRb;
    public float lifeBullet = 10f;

   

    private void Awake()
    {
        BulletRb = GetComponent<Rigidbody2D>(); //get component Rigidbody
        SpeedBullet();


    }

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Islands"))
        {
            Destroy(gameObject);
        }
    }

    void SpeedBullet()
    {
        if (Bullet)
        {
            BulletRb.AddForce(BulletRb.transform.right * speedBullet); //addforce bullet
            Destroy(gameObject, lifeBullet); //Destroy bullet in time life
        }
        if (BulletFliped)
        {
            BulletRb.AddForce(BulletRb.transform.right * speedBullet); //addforce bullet
            Destroy(gameObject, lifeBullet); //Destroy bullet in time life
        }
    }

}
