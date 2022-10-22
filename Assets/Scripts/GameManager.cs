using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject buttonsPanel;
    public GameObject creditsPanel;

    private GameManager() { }
    public static GameManager Instance { get; private set; }
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
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == Loader.Scene.TitleScreen.ToString())
        {
            AudioManager.Instance.PlayAudioClip(AudioManager.MusicClips.MusicIntro);
        }
        else if(scene.name == Loader.Scene.InitialCutsceneScreen.ToString())
        {
            AudioManager.Instance.PlayAudioClip(AudioManager.MusicClips.MusicIntro);
        }
        else if (scene.name == Loader.Scene.SampleScene.ToString())
        {
            AudioManager.Instance.PlayAudioClip(AudioManager.MusicClips.MusicFirstStage);
        }
    }



    public void OnPlayButtonPressed()
    {
        Loader.Load(Loader.Scene.InitialCutsceneScreen);
    }

    public void OnCreditsButtonPressed()
    {
        creditsPanel.SetActive(!creditsPanel.activeSelf);
        buttonsPanel.SetActive(!buttonsPanel.activeSelf);
    }
}
