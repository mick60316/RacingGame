using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLine : MonoBehaviour
{
    public GameObject ObstacleManager;
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

        if (other.tag == "Car")
        {
            for (int childN = 0; childN < ObstacleManager.transform.childCount; childN++)
            {
                if(ObstacleManager.transform.GetChild(childN).GetComponent<Obstacle>() != null)
                ObstacleManager.transform.GetChild(childN).GetComponent<Obstacle>().setRun(true);
            }

        }
    }
}
