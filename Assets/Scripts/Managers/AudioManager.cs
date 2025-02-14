using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip appleEat;
    [SerializeField] AudioClip rockJump;
    [SerializeField] AudioClip coinUp;
    [SerializeField] AudioClip screamHero;
    [SerializeField] AudioClip woodDroped;


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

    public void PlayScreamHeroEffect(float volume)
    {
        PlaySound(screamHero, volume);
    }

    public void PlayWoodDropedEffect(float volume)
    {
        PlaySound(woodDroped, volume);
    }

    private void PlaySound(AudioClip clip, float volume)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip, volume);
        }
    }
}
