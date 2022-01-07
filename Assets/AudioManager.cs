using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    public Image MusicImage;
    public Image SoundImage;
    public Sprite On, Off;


    public void ToggleMusic()
   {
        bool ToggleMusicEffect = AudioHandler.Instance.ToggleMusicSource();
        MusicImage.sprite = ToggleMusicEffect ? Off : On;
    }

    public void ToggleSound()
    {
        bool ToggleSound =  AudioHandler.Instance.ToggleSoundSource();
        SoundImage.sprite = ToggleSound ? Off : On;
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

}
