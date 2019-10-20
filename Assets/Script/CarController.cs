    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mike;
public class CarController : MonoBehaviour
{
    public CarCollider leftCollider;
    public CarCollider rightCollider;
    public CarCollider headCollider;
    public GameObject Car;
    

    public TimeShow timeShow;
    public ScoreShow scoreShow;
    public RightUpIconManager rightUpIconManager;
    public GameObject EndingPage;


    public GameObject HoodShow;
    public EffectsController effectController;
    public EffectSoundController effectAudioPlayer;
    public AudioSource BGMPlayer;


    private float CarSpeed = 0.01f;
    private float CarTrunSpeed = 0.02f;
    private int sec = 60;
    private bool IsEnd = false;
    private bool EnableControl =true;
    private bool IsAutoMode = false;
    private float LimitSpeed = 0.07f;
    private float Acceleration = 0.001f;
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            BGMPlayer.mute = !BGMPlayer.mute;

        }
        if (!headCollider.getStatus()&& IsEnd == false )
        {

            if (IsAutoMode == true || Input.GetKey(KeyCode.W) && EnableControl)
            {
                if (CarSpeed < LimitSpeed) CarSpeed += Acceleration;
            }
            else
            {
                if(EnableControl ==true)CarSpeed -= 0.001f;
             
            }

        }
        else {
            CarSpeed = 0.0f;
        }
        if (CarSpeed < 0.00f) CarSpeed = 0.0f;
        transform.Translate(0, CarSpeed, 0);
        
        if (IsEnd == false && !IsInvoking("Timer") && Car.transform.position.y >-8.5f) {
            InvokeRepeating("Timer", 0, 1.0f);
        }

        
        if (Input.GetKey(KeyCode.RightArrow) && !leftCollider.getStatus() && IsEnd == false  && EnableControl)
        {


            Car.transform.Translate(CarTrunSpeed, 0, 0);

        }
        if (Input.GetKey(KeyCode.LeftArrow) && !rightCollider.getStatus() && IsEnd == false && EnableControl)
        {

            Car.transform.Translate(-CarTrunSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow)&& EnableControl)
        {
            CarSpeed -= 0.3f;

        }

    }
    public void setSpeed(float speed)
    {

        CarSpeed = speed;
    }

    void Timer()
    {
        sec--;
        timeShow.setCurrentTime(sec);
        if (sec == 0)
        {
            TimeOut();
        }
    }
    void TimeOut()
    {
        CancelInvoke("Timer");
        IsEnd = true;
        EndingPage.SetActive(true);
        EndingPage.GetComponent<EndPageController>().OnEnbaleOverried();
    }

    public void GameToolsEvent (int ItemType)
    {

        
        switch (ItemType)
        {
            case GameTools.ITEM_CAFFEE:
                effectController.PlayEffectAnimation(1);
                EnableControl = false;
                CarSpeed = 0;
                Invoke("CaffeeReset", 3.0f);
                rightUpIconManager.addItem(ItemType);
                effectAudioPlayer.PlayAudio(0);
                break;
            case GameTools.ITEM_FAST:
                effectController.PlayEffectAnimation(2);
                LimitSpeed = 0.1f;
                CarSpeed = 0.07f;
                Acceleration = 0.003f;
                rightUpIconManager.addItem(ItemType);
                if (IsInvoking("FastReset")) CancelInvoke("FastReset");
                effectAudioPlayer.PlayAudio(1);
                Invoke("FastReset", 5.0f);
                break;
            case GameTools.ITEM_IQ:
                effectController.PlayEffectAnimation(0);
                IsAutoMode = true;
                HoodShow.SetActive(true);
                rightUpIconManager.addItem(ItemType);
                if (IsInvoking("IQReset")) CancelInvoke("IQReset");
                Invoke("IQReset", 5.0f);
                break;
            case GameTools.ITEM_LOGO:
                effectAudioPlayer.PlayAudio(2);
                scoreShow.plusScore(500);
                break;
            case GameTools.ITEM_XDS:
                rightUpIconManager.addItem(ItemType);
               
                break;
            case GameTools.ITEM_WATER:

                print("Water");

                bool haveXDS = rightUpIconManager.removeItem(GameTools.ITEM_XDS);
                if (!haveXDS)
                {
                  
                    EnableControl = false;
                    Car.transform.GetChild(0).GetComponent<Animator>().Play("RotateCar");
                    effectAudioPlayer.PlayAudio(3);
                    Invoke("CaffeeReset", 2.0f);
                }
                else {

                 
                }
                break;
            default:
                break;
        }

    }
    void CaffeeReset()
    {
        EnableControl = true;
        rightUpIconManager.removeItem(GameTools.ITEM_CAFFEE);
    }
    void FastReset()
    {
        LimitSpeed = 0.07f;
        Acceleration = 0.001f;
        if (CarSpeed > LimitSpeed) CarSpeed = 0.06f;
        rightUpIconManager.removeItem(GameTools.ITEM_FAST);
    }
    void IQReset()
    {
        IsAutoMode = false;
        HoodShow.SetActive(false);
        rightUpIconManager.removeItem(GameTools.ITEM_IQ);
    }







}
