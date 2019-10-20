using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RightUpIconManager : MonoBehaviour
{
    // Start is called before the first frame update

    List<int> IconList = new List<int>();


    public Sprite[] Icons = new Sprite[6];

    void Start()
    {

        UpdateIconList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool removeItem(int itemType)
    {
        bool haveItem = IconList.Remove(itemType);
        
        UpdateIconList();
        return haveItem;
    }
    public void addItem(int itemType)
    {
        int IsRepeat = IconList.FindIndex(x => x == itemType);
        if (IsRepeat !=-1) IconList.Remove(itemType);
        IconList.Add(itemType);

        UpdateIconList();

    }
    void UpdateIconList ()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Image>().color =new  Color32(0, 0, 0, 0);

        }

        int [] listArray = IconList.ToArray();
        for (int i =0;i<transform.childCount  && i <listArray.Length ;i++)
        {
            transform.GetChild(i).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            transform.GetChild(i).GetComponent<Image>().sprite = Icons[listArray[i]];
        }
    }
    



}
