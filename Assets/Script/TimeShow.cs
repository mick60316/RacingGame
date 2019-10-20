using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeShow : MonoBehaviour
{


    public Sprite[] NumberSprite = new Sprite[10];
    private Image[] TimeNumberShow;
    private int CurrentTime = 60;
    
    
    // Start is called before the first frame update
    void Start()
    {
        int childCount = transform.childCount;
        TimeNumberShow = new Image[childCount];
        for (int i = 0; i < childCount; i++)
        {
            TimeNumberShow[i] = transform.GetChild(i).GetComponent<Image>();
        }
   

    }

    // Update is called once per frame
    void Update()
    {
        TimeNumberShow[0].sprite = NumberSprite[CurrentTime % 10];
        TimeNumberShow[1].sprite = NumberSprite[CurrentTime / 10];
        
    }
   
    public void setCurrentTime(int time)
    {
        CurrentTime = time;
    }
}
