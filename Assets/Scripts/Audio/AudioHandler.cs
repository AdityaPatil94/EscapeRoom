using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip[] Music;
    public static AudioHandler Instance;
    private void Start()
    {
        PlayNextSong();
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void PlayNextSong()
    {
        AudioSource.clip = Music[Random.Range(0, Music.Length)];
        AudioSource.Play();
        Invoke("PlayNextSong", AudioSource.clip.length);
    }
}
