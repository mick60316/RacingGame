using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mike;
public class Car : MonoBehaviour
{

 


    private bool IsCrash = false;
    public CarController carController;




    // Start is called before the first frame update
    void Start()
    {
     

    }

    // Update is called once per frame
    void Update()
    {
        
    }

            
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Wall" )
        {
            //trackManager.CreateTrack(transform.position + new Vector3(0, 6.7f, 0), transform.rotation);
            IsCrash = true;
            
            print("Wall Hit " + other.name);

        }
       

           

            // Destroy(other.gameObject);
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Items")
        {
            float d = Vector3.Distance(transform.position, other.transform.position);
            if (d < 0.3f)
            {
                print("Get Item");
                carController.GameToolsEvent(other.GetComponent<ItemAnimation>().ItemType);
                Destroy(other.gameObject);
            }
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Wall")
        {
            //trackManager.CreateTrack(transform.position + new Vector3(0, 6.7f, 0), transform.rotation);
            IsCrash = true;
            
            print("Wall Hit " + other.name);

        }
    }
    public bool getIsCrash() { return IsCrash; ; }
 
}
