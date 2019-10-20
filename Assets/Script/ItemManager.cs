using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    public GameObject[] Items;
    private Vector3[] ItemPos;


    // Start is called before the first frame update
    void Start()
    {
        
        ItemPos = new Vector3[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            ItemPos[i] = transform.GetChild(i).transform.position;
            Destroy(transform.GetChild(i).gameObject);
        }
        
        for (int i = 0; i < ItemPos.Length; i++)
        {
            int ItemIndex = Random.Range(0, Items.Length);
            GameObject newItems = Instantiate(Items[ItemIndex]);
            newItems.transform.position = ItemPos[i];
            newItems.transform.parent = transform;
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
