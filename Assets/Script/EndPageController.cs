using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mike_LeaderBoardSystem;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class EndPageController : MonoBehaviour
{

    LeaderBoardSystem leaderBoardSystem;
    private GameObject []  InputUserName=new GameObject[8];
    private Text[] NameCharArray = new Text[8];
    private int SelectIndex = 0;
    private bool IsShow = false;
    private int UserScore=0;

    public GameObject InputSystem;
    public GameObject leaderBoard;
    public ScoreShow scoreShow;

    Dictionary<string, int> RecordMap;

    // Start is called before the first frame update
    void Start()
    {


        leaderBoardSystem = new LeaderBoardSystem(Application.dataPath);    
        RecordMap = leaderBoardSystem.getRecordMap();
        int childIndex = 0;
        foreach (string s in RecordMap.Keys)
        {

            print(s + " " + RecordMap[s]+" " + RecordMap.Count);
            if (childIndex < 10)
            {
                leaderBoard.transform.GetChild(childIndex).transform.GetChild(0).GetComponent<Text>().text = s;
                leaderBoard.transform.GetChild(childIndex).transform.GetChild(1).GetComponent<Text>().text = RecordMap[s].ToString();
            }
            childIndex++;
        }

        for (int charIndex = 0; charIndex < 8; charIndex++)
        {
            InputUserName[charIndex] = InputSystem.transform.GetChild(charIndex).gameObject;
            InputUserName[charIndex].transform.Translate(50 * charIndex, 0, 0);
            NameCharArray[charIndex] = InputUserName[charIndex].GetComponent<Text>();
            NameCharArray[charIndex].text = " ";

        }
        NameCharArray[0].text = "A";
  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {

            char[] charName = new char[NameCharArray.Length];
            for (int i = 0; i < NameCharArray.Length; i++)
            {
                charName[i] = NameCharArray[i].text.ToCharArray()[0];

            }
            string Name = new string(charName);
            leaderBoardSystem.SaveScore(Name, UserScore);

            Thread.Sleep(3000);
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            NameCharArray[SelectIndex].color = new Color32(255, 255, 255, 255);
            SelectIndex--;
            if (SelectIndex < 0) SelectIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

           


            NameCharArray[SelectIndex].color = new Color32(255, 255, 255, 255);
            SelectIndex++;
            if (SelectIndex > NameCharArray.Length - 1) SelectIndex = NameCharArray.Length - 1;


            string s = NameCharArray[SelectIndex].text.ToString();
            char[] charArray = s.ToCharArray();
            char firstChar = (char)(charArray[0]);
            if (firstChar == ' ') NameCharArray[SelectIndex].text = "A";

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {


            string s = NameCharArray[SelectIndex].text.ToString();
            char[] charArray = s.ToCharArray();
            char firstChar = (char)(charArray[0] + 1);
            if (firstChar > 'Z') firstChar = 'Z';


            NameCharArray[SelectIndex].text = "" + firstChar;

         
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            string s = NameCharArray[SelectIndex].text.ToString();
            char[] charArray = s.ToCharArray();
            char firstChar = (char)(charArray[0] - 1);
            if (firstChar < 'A') firstChar = 'A';
            NameCharArray[SelectIndex].text = "" + firstChar;
        }
    }


    void CharBlinkAnimation ()
    {
        if (NameCharArray[SelectIndex] == null) return;
        if (IsShow)
        {

            NameCharArray[SelectIndex].color = new Color32(0, 0, 0, 0);
        }
        else {

            NameCharArray[SelectIndex].color = new Color32(255, 255, 255, 255);

        }
        IsShow = !IsShow;
    }

    void OnEnable()
    {
// InvokeRepeating("CharBlinkAnimation", 0, 0.5f);
    }
    public void OnEnbaleOverried()
    {
        InvokeRepeating("CharBlinkAnimation", 0, 0.5f);
         UserScore = scoreShow.getScore();
       // UserScore = 99;
        InputSystem.transform.GetChild(8).GetComponent<Text>().text = UserScore.ToString();
        int Rank=findUserRank(UserScore);
       
        if (Rank< 10)
        {
            InputSystem.transform.position = leaderBoard.transform.GetChild(Rank).transform.position;
            for (int i = Rank; i < 10 - 1; i++)
            {
                leaderBoard.transform.GetChild(i).transform.position = leaderBoard.transform.GetChild(i + 1).transform.position;
            }
            leaderBoard.transform.GetChild(9).gameObject.SetActive(false);
        }
        



    }
    int findUserRank(int userScore)
    {

        int childIndex = 0;
        foreach (string s in RecordMap.Keys)
        {

            print(s + " " + RecordMap[s] + " " + RecordMap.Count);
            if (RecordMap[s] < userScore)
            {
                return childIndex;
            }
          
            childIndex++;
        }
        return childIndex;


    }
   
}
