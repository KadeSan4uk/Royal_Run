using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip appleEat;
    [SerializeField] AudioClip rockJump;
    [SerializeField] AudioClip coinUp;

    public void PlayAppleAudioEffect(float volume)
    {
        PlaySound(appleEat, volume);
    }

    public void PlayRockJumpEffect(float volume)
    {
        PlaySound(rockJump, volume);
    }
    public void PlayCoinUpEffect(float volume)
    {
        PlaySound(coinUp, volume);
    }

    private void PlaySound(AudioClip clip, float volume)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip, volume);
        }
    }
}
