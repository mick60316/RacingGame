using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Obstacle : MonoBehaviour
{

    public SpriteRenderer plusScoreRender;


    private ScoreShow scoreShow;
    private float Speed = 0.001f;
    private float Acceleration = 0.0002f;
    private float CurrentSpeed = 0.0f;
    private float[] SpeedLimit = new float[6];
    private bool IsRun;
    private int Type = 0;
    private int[] Score = new int[6];
    public  Sprite [] plusScore = new Sprite[6];


    private bool IsOvertack = false;
    private GameObject mainCar;




    // Start is called before the first frame update
    void Start()
    {
        SpeedLimit[0]= 0.02f;
        SpeedLimit[1]= 0.02f;
        SpeedLimit[2]= 0.008f;
        SpeedLimit[3] = 0.008f;
        SpeedLimit[4] = 0.03f;
        SpeedLimit[5] = 0.01f;
        Score[0] = 200;
        Score[1] = 200;
        Score[2] = 100;
        Score[3] = 100;
        Score[4] = 500;
        Score[5] = 100;
        scoreShow = GameObject.Find("Score").GetComponent<ScoreShow>();
        mainCar = GameObject.Find("CarBody");
        plusScoreRender.color = new Color32(0, 0, 0, 0);

        IsRun = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Type == 4)
        {
            if (IsRun == false && transform.position.y - mainCar.transform.position.y < 1 && IsOvertack == false)
            {
                IsRun = true;
            }
        }
        else {
            if (IsRun == false && transform.position.y - mainCar.transform.position.y < 10 && IsOvertack == false)
            {
                IsRun = true;
            }
        }

   



        if (IsRun == true)
        {
           transform.Translate(0, CurrentSpeed, 0);

        }
        if (CurrentSpeed < SpeedLimit[Type])
        {
            CurrentSpeed += Acceleration;
        }
        DetectOvertack();
    }

    void DetectOvertack ()
    {
        if (!IsOvertack)
        {
            if (mainCar.transform.position.y > transform.position.y)
            {
                plusScoreRender.color = new Color32(255, 255, 255, 255);
                plusScoreRender.sprite = plusScore[Type];
                scoreShow.plusScore(Score[Type]);
                IsOvertack = true;
            }

        }
    }
  
    public void setObstacleType(int Type)
    {
        this.Type = Type;
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Wall")
        {
            //trackManager.CreateTrack(transform.position + new Vector3(0, 6.7f, 0), transform.rotation);
            IsOvertack = true;
            Speed = 0;
            Invoke("delayDisappear", 3.0f);
           // Destroy(this.gameObject, 3.0f);
            print("Wall Hit " + other.name);
            IsRun = false;

        }
        if (other.name == "BackCollider")
        {
            IsRun = false;
        }
        if (other.tag == "obstacle")
        {

            if(this.transform.position.y <other.transform.position.y)

            CurrentSpeed = 0;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "BackCollider")
        {
          
            IsRun = true;
        }
        if (other.tag == "obstacle")
        {
            if (this.transform.position.y < other.transform.position.y)
                CurrentSpeed = 0;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "Wall")
        {
            //trackManager.CreateTrack(transform.position + new Vector3(0, 6.7f, 0), transform.rotation);

            Invoke("delayDisappear", 1.5f);
            // Destroy(this.gameObject, 3.0f);
            print("Wall Hit " + other.name);
            IsRun = false;

        }
    }
    void delayDisappear ()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 0);
        transform.GetChild(0).gameObject.SetActive(false);
    }
    public void setRun(bool IsRun)
    {
        if (Type != 4 )this.IsRun = IsRun;

    }
}
