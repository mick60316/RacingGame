using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackManager : MonoBehaviour
{

    public GameObject []PrefabTrack;
    public ScoreShow scoreShow;
    GameObject NewTrack;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void CreateTrack(Vector3 pos,Quaternion rotation)
    {
        Random random = new Random();
        scoreShow.AddOneTrack();
        int TrackIndex = Random.Range(0, PrefabTrack.Length); 
        NewTrack = GameObject.Instantiate(PrefabTrack[TrackIndex]);
        NewTrack.transform.position = pos;
        NewTrack.transform.rotation = rotation;
        NewTrack.name = "Track";
        NewTrack.transform.parent = transform;
    }

}
