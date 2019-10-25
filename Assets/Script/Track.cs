using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{

    private TrackManager trackManager;
 
    // Start is called before the first frame update
    void Start()
    {
        //GameObject perfabs = GameObject.Instantiate(RunTrack);
        trackManager = GameObject.Find("TrackManager").GetComponent<TrackManager>();
        if (trackManager == null) Debug.Log(" Cann't find TrackManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        print(collision.collider.name); 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Car")
        {
            trackManager.CreateTrack(transform.position + new Vector3(0, 19.41f*2, 0), transform.rotation);
            print("Track Hit "+other.name);
        }
        
        

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Car") 
        {
            Destroy(this.gameObject, 30.0f);

        }


    }
}
