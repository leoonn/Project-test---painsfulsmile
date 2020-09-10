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
    public void ChangeSpriteSnailDead()
    {
        if (gameObject.tag == "Sail")
        {
            originalsAssets.sprite = newAssets[3];
        }

    }
    public void ChangeSpriteHullDamage()
    {
        if (gameObject.tag == "Hull")
        {
            originalsAssets.sprite = newAssets[2];
        }

    }
    public void ChangeSpriteHullAlmost()
    {
        if (gameObject.tag == "Hull")
        {
            originalsAssets.sprite = newAssets[1];
        }

    }
    public void ChangeSpriteHullDead()
    {
        if (gameObject.tag == "Hull")
        {
            originalsAssets.sprite = newAssets[0];
        }

    }

}
