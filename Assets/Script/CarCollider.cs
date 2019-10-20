using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollider : MonoBehaviour
{
    private bool IsCrash =false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Wall" || other.tag == "obstacle")
        {
           
            IsCrash = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Wall" || other.tag =="obstacle")
        {
            //trackManager.CreateTrack(transform.position + new Vector3(0, 6.7f, 0), transform.rotation);
            IsCrash = true;

          

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Wall" || other.tag == "obstacle")
        {
            //trackManager.CreateTrack(transform.position + new Vector3(0, 6.7f, 0), transform.rotation);
            IsCrash = false;

          

        }
    }

    public bool getStatus()
    {
        return IsCrash;
    }

}
