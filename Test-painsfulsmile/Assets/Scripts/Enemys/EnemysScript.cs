using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysScript : Shoot
{

    public Transform player;
    public float speedEnemy = 5;
    float waitTimePoint;
    public float startTimePoint;

    public Transform [] movepoint;
    private int RandomPoint;

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

    public int lifeEnemy;
    void Start()
    {
        waitTimePoint = startTimePoint;
        Type = enemyType.patrol;
        RandomPoint = Random.Range(0, movepoint.Length);
        timeShot = startTimeShots;

        SailScript = this.gameObject.transform.GetChild(2);
        HullScript = this.gameObject.transform.GetChild(1);

        lifeEnemy = 5;
    }

    // Update is called once per frame
    void Update()
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
                if (distance > Exitdistance)
                {
                    Debug.Log("PATROL");
                    Type = enemyType.patrol;
                }
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

                if (distance > Exitdistance)
                {
                    Type = enemyType.patrol;
                }
                if (gameObject.tag == "Shooter")
                {
                    if (Vector2.Distance(transform.position, player.position) > stopDistance)
                    {
                        FollowPlayer(player.position);
                        //RotateForPlayer(player.position);

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
                        Instantiate(bulletprefab, Gun[0].position, Gun[0].rotation); //instanteate one bullet
                        Instantiate(bulletprefab, Gun[1].position, Gun[1].rotation); //instanteate one bullet
                        Instantiate(bulletprefab, Gun[2].position, Gun[2].rotation); //instanteate one bullet
                        Instantiate(bulletprefab, Gun[3].position, Gun[3].rotation); //instanteate one bullet
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
            
            Destroy(col.gameObject);
        }
    }

    void LifeManager()
    {
        if (lifeEnemy == 3)
        {
            HullScript.GetComponent<ChangeAssets>().ChangeSpriteHullDamage();
        }
        if (lifeEnemy == 1)
        {
            HullScript.GetComponent<ChangeAssets>().ChangeSpriteHullAlmost();
        }
        if (lifeEnemy == 0)
        {
            Type = enemyType.dead;
            HullScript.GetComponent<ChangeAssets>().ChangeSpriteHullDead();
        }

    }

} //gameObject.GetComponent<ChangeAssets>().ChangeSpriteSnailWalk();
