using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysScript : Shoot
{

    private Transform player;

    public float speedEnemy = 3;

    float waitTimePoint;
    public float startTimePoint;

    public Transform [] movepoint;
    private int RandomPoint;

    public int lifeEnemy = 3;
    public enemyType Type;

     float distance;

    public float stopDistance;
    public float retraetDistance;

    public float nearDistance = 4;
    public float Exitdistance = 6;

    [HideInInspector ]
    public Transform SailScript;

    [HideInInspector]
    public Transform HullScript;

    

     Collider2D colEnemy;
    EnemysScript enemyScript;

    public GameObject explosion;
    public GameObject bigExplosion;

    Pontuation pontuationScript;
    public GameObject[] life;
    void Start()
    {
        waitTimePoint = startTimePoint;
        Type = enemyType.patrol;
        RandomPoint = Random.Range(0, movepoint.Length);
        timeShot = startTimeShots;

        SailScript = this.gameObject.transform.GetChild(2);
        HullScript = this.gameObject.transform.GetChild(1);

        lifeEnemy = 3;

        colEnemy = gameObject.GetComponent<Collider2D>();
        enemyScript = gameObject.GetComponent<EnemysScript>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        pontuationScript = GameObject.Find("GameManager").GetComponent<Pontuation>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AIState();
        LifeManager();
    }

    void AIState()
    {
        switch (Type)
        {
            case enemyType.patrol:

                FollowMovePoint(movepoint[RandomPoint].position);

                RotateForPlayer(movepoint[RandomPoint].position);

               

                if (Vector2.Distance(transform.position, movepoint[RandomPoint].position) < 0.2f)
                {
                    if (waitTimePoint <= 0)
                    {
                        RandomPoint = Random.Range(0, movepoint.Length);
                        waitTimePoint = startTimePoint;
                    }
                    else
                    {
                        waitTimePoint -= Time.deltaTime;
                    }

                }
                distance = Vector2.Distance(transform.position, player.position);

                if (distance > nearDistance && distance < Exitdistance)
                {
                    Type = enemyType.chase;
                }

                break;
            case enemyType.chase:
                distance = Vector2.Distance(transform.position, player.position);
                /*if (distance > Exitdistance)
                {
                    Debug.Log("PATROL");
                    Type = enemyType.patrol;
                }*/
                if (gameObject.tag == "Chase")
                {
                    FollowPlayer(player.position);
                    RotateForPlayer(player.position);
                }
                else
                {
                    Type = enemyType.shooter;
                }
                break;
            case enemyType.shooter:
                distance = Vector2.Distance(transform.position, player.position);
                if (distance > Exitdistance)
                {
                    Type = enemyType.patrol;
                }
                if (gameObject.tag == "Shooter")
                {
                    if (Vector2.Distance(transform.position, player.position) > stopDistance)
                    {
                        FollowPlayer(player.position);
                        RotateForPlayer(player.position);

                    }
                    else if (Vector2.Distance(transform.position, player.position) < stopDistance && Vector2.Distance(transform.position, player.position) > retraetDistance)
                    {
                        transform.position = this.transform.position;
                        
                    }
                    else if (Vector2.Distance(transform.position, player.position) < retraetDistance)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, player.position, -speedEnemy * Time.deltaTime);
                    }

                    if (timeShot <= 0)
                    {
                        Instantiate(bulletprefab, Gun[0].position, Gun[0].rotation); 
                        Instantiate(bulletprefab, Gun[1].position, Gun[1].rotation); 
                        Instantiate(bulletprefab, Gun[2].position, Gun[2].rotation); 
                        Instantiate(bulletprefab, Gun[3].position, Gun[3].rotation); 
                        timeShot = startTimeShots;

                    }
                    else
                    {
                        timeShot -= Time.deltaTime;
                    }
                }
                else
                {
                    Type = enemyType.patrol;
                }
                break;
            case enemyType.dead:
                SailScript.GetComponent<ChangeAssets>().ChangeSpriteHullDead();
                
                colEnemy.enabled = false;
                enemyScript.enabled = false;
                Destroy(gameObject,5);
                break;

        }

    }
    void FollowPlayer(Vector2 player)
    {
        transform.position = Vector2.MoveTowards(transform.position, player, speedEnemy * Time.deltaTime);
        
    }
    void RotateForPlayer(Vector2 player)
    {
        float offset = 90f;
        Vector2 direction = player - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // convert radians in constant
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
        
    }
    void FollowMovePoint(Vector2 movepoint)
    {

        transform.position = Vector2.MoveTowards(transform.position, movepoint, speedEnemy * Time.deltaTime);
        SailScript.GetComponent<ChangeAssets>().ChangeSpriteSnailWalk();
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag ("BulletPlayer"))
        {
            lifeEnemy--;
            GameObject explo = Instantiate(explosion, col.transform.position, Quaternion.identity);
            Destroy(explo, 0.35f);
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("BulletPlayer") && lifeEnemy == 0)
        {
            pontuationScript.GetPontuation();
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Islands"))
        {
            lifeEnemy = 0;
            if (Type == enemyType.chase || Type == enemyType.shooter)
            {
                pontuationScript.GetPontuation();
                
            }
        }
    }

    void LifeManager()
    {
        if (lifeEnemy <= 2)
        {
            HullScript.GetComponent<ChangeAssets>().ChangeSpriteHullDamage();
            SailScript.GetComponent<ChangeAssets>().ChangeSpriteSailDamage();
        }
        if (lifeEnemy <= 1)
        {
            HullScript.GetComponent<ChangeAssets>().ChangeSpriteHullAlmost();
        }
        if (lifeEnemy <= 0)
        {
            lifeEnemy = 0;
            Type = enemyType.dead;
            GameObject bigExplo = Instantiate(bigExplosion, HullScript.transform.position, Quaternion.identity);
            Destroy(bigExplo, 0.3f);
            HullScript.GetComponent<ChangeAssets>().ChangeSpriteHullDead();
            SailScript.GetComponent<ChangeAssets>().ChangeSpriteSailDead();
        }
        LifeUi();
    }

    void LifeUi()
    {
        if (lifeEnemy < 3)
        {
            life[0].SetActive(false);
        }
        if (lifeEnemy < 2)
        {
            life[1].SetActive(false);
        }
        if (lifeEnemy < 1)
        {
            life[2].SetActive(false);
        }
        
        if (lifeEnemy <= 0)
        {
            
            life[2].SetActive(false);
            life[1].SetActive(false);
            life[0].SetActive(false);
        }
    }

} //gameObject.GetComponent<ChangeAssets>().ChangeSpriteSnailWalk();
