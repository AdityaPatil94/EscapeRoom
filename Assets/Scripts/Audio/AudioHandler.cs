using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioHandler : MonoBehaviour
{
    public static AudioHandler Instance;
    public AudioSource BGMusicAudioSource;
    public AudioSource SoundEffectAudioSource;
    public AudioClip[] Music;

    
    public bool ToggleMusic;
    public bool ToggleSound;
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
        BGMusicAudioSource.clip = Music[Random.Range(0, Music.Length)];
        BGMusicAudioSource.Play();
        Invoke("PlayNextSong", BGMusicAudioSource.clip.length);
    }

    public bool ToggleMusicSource()
    {
        ToggleMusic = !ToggleMusic;
        BGMusicAudioSource.mute = ToggleMusic;
        return ToggleMusic;
    }

    public bool ToggleSoundSource()
    {
        ToggleSound = !ToggleSound;
        SoundEffectAudioSource.mute = ToggleSound;
        return ToggleSound;
    }
         
}
