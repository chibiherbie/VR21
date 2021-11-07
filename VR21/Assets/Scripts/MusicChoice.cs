using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChoice : MonoBehaviour
{
    public AudioClip[] sounds; // set the array size and fill the elements with the sounds
    public AudioSource audio;
 
    void  PlayRandom()
    { // call this function to play a random sound
        if (audio.isPlaying)
            return; // don't play a new sound while the last hasn't finished

        audio.clip = sounds[Random.Range(0, sounds.Length)];
        audio.Play();
    }

    private void Update()
    {
        PlayRandom();
    }
}
