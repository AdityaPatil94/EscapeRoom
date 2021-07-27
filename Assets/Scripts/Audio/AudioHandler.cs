using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip[] Music;

    private void Start()
    {
        PlayNextSong();
    }
    void PlayNextSong()
    {
        AudioSource.clip = Music[Random.Range(0, Music.Length)];
        AudioSource.Play();
        Invoke("PlayNextSong", AudioSource.clip.length);
    }
}
