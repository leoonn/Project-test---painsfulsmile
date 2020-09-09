using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAssets : MonoBehaviour
{
    public SpriteRenderer []originalsAssets;
    public Sprite[] newAssets;
    void Start()
    {
        originalsAssets[0] = GameObject.Find("hullLargefull").GetComponent<SpriteRenderer>();
        originalsAssets[1] = GameObject.Find("sailSmallIdle").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSpriteSnailWalk()
    {
        originalsAssets[1].sprite = newAssets[3];
    }
    public void ChangeSpriteSnailIdle()
    {
        originalsAssets[1].sprite = newAssets[5];
    }
}
