using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] AudioClip introMusic;
    [SerializeField] float musicVolume;

    // Start is called before the first frame update
    void Start()
    {
        introMusicMusic();
    }

   
    public void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void introMusicMusic()
    {
        if (audioSource != null)
        {
            audioSource.DOFade(musicVolume, 5);
            PlayClip(introMusic);
        }

    }


    public void FadeOutMusic()
    {
        if (audioSource != null)
        {
            audioSource.DOFade(0, 5);
        }
    }


}
