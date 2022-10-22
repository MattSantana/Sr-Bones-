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
    }


    public void OnPlayButtonPressed()
    {
        Loader.Load(Loader.Scene.SampleScene);
    }

    public void OnCreditsButtonPressed()
    {
        creditsPanel.SetActive(!creditsPanel.activeSelf);
        buttonsPanel.SetActive(!buttonsPanel.activeSelf);
    }
}
