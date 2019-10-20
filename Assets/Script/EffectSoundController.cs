using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EffectSoundController : MonoBehaviour
{

    public AudioClip[] audio;
    private AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAudio(int index)
    {
        audioPlayer.clip = audio[index];
        audioPlayer.Play();


    }


}
