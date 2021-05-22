using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioSource sound;
   public void MusicPlay()
    {
        sound.Play();
        sound.volume = 0.15f;
    }
}
