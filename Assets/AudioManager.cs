using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip sinkClip;
    public AudioClip itemClip;
    public AudioClip phoneClip;
    public AudioClip doorClip;
    public void SearchTheAudio(string audio)
    {
        switch (audio)
        {
            case "sink":
                sound.PlayOneShot(sinkClip, 0.5f);
                break;
            case "pickitem":
                sound.PlayOneShot(itemClip, 0.5f);
                break;
            case "phone":
                sound.PlayOneShot(phoneClip, 0.5f);
                break;
        }
    }
}
