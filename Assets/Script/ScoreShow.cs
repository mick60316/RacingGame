using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreShow : MonoBehaviour
{
    public Sprite[] NumberSprite = new Sprite[10];
    private Image[] ScoreNumberShow;
    private int CurrentScore = -500;


    // Start is called before the first frame update
    void Start()
    {
        int childCount = transform.childCount;
        ScoreNumberShow = new Image[childCount];
        for (int i = 0; i < childCount; i++)
        {
            ScoreNumberShow[i] = transform.GetChild(i).GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        int Number = CurrentScore;
        for (int i = 0; i < ScoreNumberShow.Length; i++)
        {
           int index =Number %10;
           ScoreNumberShow[ScoreNumberShow.Length -1 - i].sprite = NumberSprite[index];
           Number /= 10;
        }
        

    }


    public void setScore(int Score)
    {
        CurrentScore = Score;
    }
    public void AddOneTrack()
    {

        CurrentScore += 500;

    }
    public void plusScore(int plusValue)
    {

        CurrentScore += plusValue;
    }
    public int getScore()
    {

        return CurrentScore;
    }


}
