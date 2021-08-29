using UnityEngine;

// This Reaction is used to play sounds through a given AudioSource.
// Since the AudioSource itself handles delay, this is a Reaction
// rather than an DelayedReaction.
public class AudioReaction : Reaction
{
    //public AudioHandler soundAudioSource;     // The AudioSource to play the clip.
    public AudioClip audioClip;         // The AudioClip to be played.
    public float delay;                 // How long after React is called before the clip plays.


    protected override void SpecificInit()
    {
        //soundAudioSource = FindObjectOfType<AudioHandler>();
    }

    protected override void ImmediateReaction()
    {
        Debug.Log("Audio");
        // Set the AudioSource's clip to the given one and play with the given delay.
        AudioHandler.Instance.SoundEffectAudioSource.clip = audioClip;
        AudioHandler.Instance.SoundEffectAudioSource.PlayDelayed(delay);
    }
}