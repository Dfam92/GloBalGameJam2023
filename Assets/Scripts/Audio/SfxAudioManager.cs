using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxAudioManager : MonoBehaviour
{
    public AudioSource sfxAudioSource;
    [SerializeField] AudioClip playerGoalSfx;
    [SerializeField] AudioClip playerLootSfx;
    [SerializeField] AudioClip UIConfirmSfx;
    [SerializeField] AudioClip UIDenySfx;
    [SerializeField] AudioClip UIHoverSfx;
    [SerializeField] AudioClip UIStartSfx;
    [SerializeField] private float sfxVolume;


    public void PlaySfx(AudioClip clip, float value)
    {
        if (sfxAudioSource != null)
        {
            sfxAudioSource.PlayOneShot(clip, value);
        }

    }

    public void PlayPlayerGoal()
    {
        PlaySfx(playerGoalSfx, sfxVolume - 0.6f);
    }

    public void PlayLootSound()
    {
        PlaySfx(playerLootSfx, sfxVolume - 0.6f);
    }

    public void PlayUIConfirm()
    {
        PlaySfx(UIConfirmSfx, sfxVolume - 0.6f);
    }

    public void PlayUIDeny()
    {
        PlaySfx(UIDenySfx, sfxVolume - 0.6f);
    }

    public void PlayUIHover()
    {
        PlaySfx(UIHoverSfx, sfxVolume - 0.6f);
    }

    public void PlayUIStart()
    {
        PlaySfx(UIStartSfx, sfxVolume);
    }

}