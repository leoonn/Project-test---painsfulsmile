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

    GameOver gameOverScript;

    public GameObject[] life;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        SailScript = this.gameObject.transform.GetChild(2);
        HullScript = this.gameObject.transform.GetChild(1);
        lifePlayer = 10;
        playerScript = gameObject.GetComponent<PlayerMove>();

        playerScript.enabled = true;

        gameOverScript = GameObject.Find("GameManager").GetComponent<GameOver>();

    }

    // Update is called once per frame
    void FixedUpdate()
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
            Destroy(explo, 0.3f);
            Destroy(col.gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Chase"))
        {
            lifePlayer = 0;
        }

        if (coll.gameObject.CompareTag("Islands"))
        {
            lifePlayer = 0;
        }
        

    }
    void LifeManager()
    {
        if (lifePlayer <= 7 && lifePlayer > 4)
        {
            HullScript.GetComponent<ChangeAssets>().ChangeSpriteHullDamage();
            SailScript.GetComponent<ChangeAssets>().ChangeSpriteSailDamage();
        }
        if (lifePlayer <= 4)
        {
            HullScript.GetComponent<ChangeAssets>().ChangeSpriteHullAlmost();
        }
        if (lifePlayer <= 0)
        {
            lifePlayer = 0;
            GameObject bigExplo = Instantiate(bigExplosion, HullScript.transform.position, Quaternion.identity);
            Destroy(bigExplo, 0.35f);
            HullScript.GetComponent<ChangeAssets>().ChangeSpriteHullDead();
            SailScript.GetComponent<ChangeAssets>().ChangeSpriteSailDead();
            rb.velocity = Vector2.zero;
            playerScript.enabled = false; 
            Invoke("GameOverTime", 0.7f);
            
        }
        LifeUi();
    }
    void LifeUi()
    {
        if (lifePlayer < 10   )
        {
            life[0].SetActive(false);
        }
        if(lifePlayer < 8  )
        {
            life[1].SetActive(false);
        }
        if(lifePlayer < 6  )
        {
            life[2].SetActive(false);
        }
        if(lifePlayer < 4  )
        {
            life[3].SetActive(false);
        }
        if(lifePlayer <= 0 )
        {
            life[4].SetActive(false);
            life[3].SetActive(false);
            life[2].SetActive(false);
            life[1].SetActive(false);
            life[0].SetActive(false);
        }
    }

    void GameOverTime()
    {
        Time.timeScale = 0;
        gameOverScript.GameOverActive();
    }
}