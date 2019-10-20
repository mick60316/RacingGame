using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
public class ObstacleManager : MonoBehaviour
{

    public GameObject[] Obstacle=new GameObject [6];
    private Vector3 []ObstaclePos;
    public float[] ObstacleSpeed = new float[6];
    // Start is called before the first frame update
    void Start()
    {
        ObstacleSpeed[0] = 0.1f;
        int ChildCount = transform.childCount;
        ObstaclePos = new Vector3[ChildCount];
        for (int childN = 0; childN < ChildCount; childN++)
        {
            ObstaclePos[childN]= transform.GetChild(childN).transform.position;
            Destroy(transform.GetChild(childN).gameObject);
        }

        
        for (int childN = 0; childN < ObstaclePos.Length; childN++)
        {

            int ObstacleIndex = Random.Range(0, Obstacle.Length);
            GameObject newObstacle = GameObject.Instantiate(Obstacle[ObstacleIndex]);
            newObstacle.GetComponent<Obstacle>().setObstacleType(ObstacleIndex);
            newObstacle.transform.position = ObstaclePos[childN];
            newObstacle.transform.parent = transform;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
