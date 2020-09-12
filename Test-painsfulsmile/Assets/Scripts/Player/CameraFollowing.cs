using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public GameObject player;

    public float smoothTimeX;
    public float smoothTimeY;

    Vector2 speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //calculate position of player on smooth 
        float positionX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref speed.x, smoothTimeX);
        float positionY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref speed.y, smoothTimeY);

        transform.position = new Vector3(positionX, positionY, transform.position.z);
    }
}
