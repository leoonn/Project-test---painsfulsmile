using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAssets : MonoBehaviour
{
    public SpriteRenderer originalsAssets;
    public Sprite[] newAssets;
    void Start()
    {
        originalsAssets = gameObject.GetComponent<SpriteRenderer>();    
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSpriteSnailWalk()
    {
        if (gameObject.tag == "Sail")
        {
            originalsAssets.sprite = newAssets[0];
        }
      
       
    }
    public void ChangeSpriteSnailIdle()
    {
        if (gameObject.tag == "Sail")
        {
            originalsAssets.sprite = newAssets[2];
        }
        
    }

    public void ChangeSpriteEnemyDeath()
    {
        if (gameObject.tag == "Hull")
        {
            originalsAssets.sprite = newAssets[0];
            gameObject.tag = "Dead";
        }
        if (gameObject.tag == "Sail")
        {
            originalsAssets.sprite = newAssets[3];
            gameObject.tag = "Dead";

        }

    }
    public void ChangeSpriteEnemyShipAlmost()
    {
        if (gameObject.tag == "Hull")
        {
            originalsAssets.sprite = newAssets[2];

            if (gameObject.tag == "Sail")
            {

                originalsAssets.sprite = newAssets[1];
            }
        }

    }
    public void ChangeSpriteEnemyShipDamage()
    {
        if (gameObject.tag == "Hull")
        {
            originalsAssets.sprite = newAssets[1];
        }
        

    }
}
