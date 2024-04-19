using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public AudioSource musicSource, sfxSource;
    void Awake() {
        Instance = this;
    }

    public static void PlayMusic(AudioClip audioClip) {
        Debug.Log(audioClip.name);
        Instance.musicSource.clip = audioClip;
        Instance.musicSource.Play();
    }

    public static void PlaySFX(AudioClip clip) {
        Instance.sfxSource.PlayOneShot(clip);
    }
}
