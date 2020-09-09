using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform[] Gunplayer; //player position
    public GameObject bulletprefab;
    public GameObject BulletFlipedPrefab;
    public float fireRate = 25f;
    public float countTime;




    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        Shooter(); //Initializing the method 
    }
    public void Shooter() //method shoot
    {
        if (Input.GetButton("Shoot") && countTime > fireRate) // if true ? shoot !!
        {

            Instantiate(bulletprefab, Gunplayer[0].position, Gunplayer[0].rotation); //instanteate one bullet
            Instantiate(bulletprefab, Gunplayer[1].position, Gunplayer[1].rotation); //instanteate one bullet
            Instantiate(BulletFlipedPrefab, Gunplayer[2].position, Gunplayer[2].rotation); //instanteate one bullet
            Instantiate(bulletprefab, Gunplayer[3].position, Gunplayer[3].rotation); //instanteate one bullet
            ResetTime(); //call the method 
            //fire.Play(); //play particle of bullet

        }

        countTime++;
        Debug.Log(countTime + "time");
    }

    public void ResetTime() //reset the time shoot
    {
        countTime = 0f;
    }


}
