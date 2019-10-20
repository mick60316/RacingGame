using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimation : MonoBehaviour
{

    public Sprite[] ItemsImage;
    public int ItemType;
    private int CurrentIndex;
    // Start is called before the first frame update
    void Start()
    {
        int Count = ItemsImage.Length;
        InvokeRepeating("AnimationPlayer", 0, (float)(1.0f / Count));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AnimationPlayer()
    {
        GetComponent<SpriteRenderer>().sprite = ItemsImage[CurrentIndex];
        CurrentIndex++;
        CurrentIndex %= ItemsImage.Length;
    }
    
}
