using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform[] Gun; //player position
    public GameObject bulletprefab;
    public GameObject BulletFlipedPrefab;
    
    
    public float timeShot;
    public float startTimeShots;




    void Start()
    {
        timeShot = startTimeShots;

    }

    // Update is called once per frame
    void Update()
    {

        Shooter(); //Initializing the method 
    }
    public void Shooter() //method shoot
    {
        if (Input.GetButton("Shoot") && timeShot <= 0 ) // if true ? shoot !!
        {

            Instantiate(bulletprefab, Gun[0].position, Gun[0].rotation); //instanteate one bullet
            Instantiate(bulletprefab, Gun[1].position, Gun[1].rotation); //instanteate one bullet
            Instantiate(BulletFlipedPrefab, Gun[2].position, Gun[2].rotation); //instanteate one bullet
            Instantiate(bulletprefab, Gun[3].position, Gun[3].rotation); //instanteate one bullet
            
            
            timeShot = startTimeShots;
        }else
        {
            timeShot -= Time.deltaTime;   

        }

       
        
    }

    



}
