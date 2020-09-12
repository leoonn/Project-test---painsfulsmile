using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLookAtPlayer : MonoBehaviour
{
    public Transform player;
    public float nearDistance = 4;
    public float Exitdistance = 6;
     float distance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);
        if (distance > nearDistance && distance < Exitdistance)
        {
            RotateForPlayer(player.position);
        }
        else 
        {
            
        }
        
    }

    void RotateForPlayer(Vector2 player)
    {
        float Dir = 90f;
        Vector2 direction = player - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // convert radians in constant
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + Dir)); //rotate object in direction of player
    }
}
