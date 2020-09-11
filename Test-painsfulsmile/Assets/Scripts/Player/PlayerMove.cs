using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed =2;
    public int speedRot = 50;

    

    public int lifePlayer;
    

    public GameObject explosion;
    public GameObject bigExplosion;
    PlayerMove playerScript;

    [HideInInspector]
    public Transform SailScript;

    [HideInInspector]
    public Transform HullScript;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        SailScript = this.gameObject.transform.GetChild(2);
        HullScript = this.gameObject.transform.GetChild(1);
        lifePlayer = 10;

        playerScript = gameObject.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotation();
        LifeManager();
    }

    void Move()
    {
        if (Input.GetButton("Move"))
        {
            //rb.velocity = (Vector2.right * speed);
            transform.Translate(new Vector3(0,-1, 0) * Time.deltaTime * speed, Space.Self);
            SailScript.GetComponent<ChangeAssets>().ChangeSpriteSnailWalk();
        }
        else
        {
            rb.velocity = Vector2.zero;
            SailScript.GetComponent<ChangeAssets>().ChangeSpriteSnailIdle();
        }
    }

    void Rotation()
    {
        if (Input.GetButton("LeftMove"))
        {
           
            
            transform.Rotate(new Vector3(0,0 , 1) * Time.deltaTime  * speedRot, Space.Self);
            SailScript.GetComponent<ChangeAssets>().ChangeSpriteSnailWalk();
        }

        if (Input.GetButton("RightMove"))
        {
            
            transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * speedRot, Space.Self);
            SailScript.GetComponent<ChangeAssets>().ChangeSpriteSnailWalk();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("BulletEnemy"))
        {

            lifePlayer--;
            GameObject explo = Instantiate(explosion, col.transform.position, Quaternion.identity);
            Destroy(explo, 0.5f);
            Destroy(col.gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Chase"))
        {
            lifePlayer = 0;
        }
    }
    void LifeManager()
    {
        if (lifePlayer == 7)
        {
            HullScript.GetComponent<ChangeAssets>().ChangeSpriteHullDamage();
        }
        if (lifePlayer == 4)
        {
            HullScript.GetComponent<ChangeAssets>().ChangeSpriteHullAlmost();
        }
        if (lifePlayer == 0)
        {

            GameObject bigExplo = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(bigExplo, 0.5f);
            HullScript.GetComponent<ChangeAssets>().ChangeSpriteHullDead();
            rb.velocity = Vector2.zero;
            playerScript.enabled = false;
        }

    }
}