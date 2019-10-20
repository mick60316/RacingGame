using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{

    public GameObject[] EffectGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  


    }

    public void PlayEffectAnimation(int EffectAnimationIndex )
    {

        GameObject gameObject = GameObject.Instantiate(EffectGameObject[EffectAnimationIndex]);
        
        gameObject.transform.parent = transform;
        gameObject.transform.Translate(0, 1000, 0);
        gameObject.GetComponent<Animator>().Play("MoveOut");
        Destroy(gameObject, 1.0f);


    }

}
