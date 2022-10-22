using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public enum MusicClips
    {
        MusicIntro,
        MusicFirstStage,
        MusicSecondStage
    }

    [SerializeField] private List<AudioClip> gameMusics;
    [SerializeField] private AudioSource audioSource;

    private AudioManager() { }
    public static AudioManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    public void PlayAudioClip(MusicClips music)
    {
        audioSource.clip = gameMusics[(int)music];
        audioSource.Play();
    }


}
