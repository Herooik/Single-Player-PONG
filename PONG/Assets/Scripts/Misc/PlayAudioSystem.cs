using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioSystem : MonoBehaviour
{
    [SerializeField] private AudioClip audio;
    
    public void PlayAudio()
    {
        AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position);
    }
}
