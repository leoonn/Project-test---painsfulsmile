using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Rigidbody2D rb;
    public int speed =2;
    public int speedRot = 50;

    ChangeAssets AssetsScript;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        AssetsScript = gameObject.GetComponent<ChangeAssets>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotation();
    }

    void Move()
    {
        if (Input.GetButton("Move"))
        {
            //rb.velocity = (Vector2.right * speed);
            transform.Translate(new Vector3(0,-1, 0) * Time.deltaTime * speed, Space.Self);
            AssetsScript.ChangeSpriteSnailWalk();
        }
        else
        {
            rb.velocity = Vector2.zero;
            AssetsScript.ChangeSpriteSnailIdle();
        }
    }

    void Rotation()
    {
        if (Input.GetButton("LeftMove"))
        {
           
            
            transform.Rotate(new Vector3(0,0 , 1) * Time.deltaTime  * speedRot, Space.Self);
        }

        if (Input.GetButton("RightMove"))
        {
            
            transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * speedRot, Space.Self);
        }
    }
}