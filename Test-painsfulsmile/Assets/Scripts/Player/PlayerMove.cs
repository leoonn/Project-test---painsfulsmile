using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed =2;
    public int speedRot = 50;

    ChangeAssets SailScript;

    public int lifePlayer;
    ChangeAssets HullScript;

    public GameObject explosion;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        SailScript = GameObject.Find("sailSmallIdle").GetComponent<ChangeAssets>();
        HullScript = GameObject.Find("hullLargefull").GetComponent<ChangeAssets>();
        lifePlayer = 10;
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
            SailScript.ChangeSpriteSnailWalk();
        }
        else
        {
            rb.velocity = Vector2.zero;
            SailScript.ChangeSpriteSnailIdle();
        }
    }

    void Rotation()
    {
        if (Input.GetButton("LeftMove"))
        {
           
            
            transform.Rotate(new Vector3(0,0 , 1) * Time.deltaTime  * speedRot, Space.Self);
            SailScript.ChangeSpriteSnailWalk();
        }

        if (Input.GetButton("RightMove"))
        {
            
            transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * speedRot, Space.Self);
            SailScript.ChangeSpriteSnailWalk();
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
           
            HullScript.GetComponent<ChangeAssets>().ChangeSpriteHullDead();
        }

    }
}