using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InitialCutsceneHandler : MonoBehaviour
{
    [SerializeField] private List<Sprite> cutsceneSprites;
    [SerializeField] private Image cutsceneImage;

    public Button nextButton;

    private int sceneIndex;
    private Scene currentScene;

    private void Start()
    {
        sceneIndex = 0;
        cutsceneImage.sprite = cutsceneSprites[0];
        sceneIndex++;
        currentScene = SceneManager.GetActiveScene(); 
    }

    public void OnNextButtonPressed()
    {
        if (sceneIndex < cutsceneSprites.Count)
        {
            StartCoroutine(NextImage());
            nextButton.gameObject.SetActive(false);
        }
        else if (currentScene.name == Loader.Scene.InitialCutsceneScreen.ToString())
        {
            Loader.Load(Loader.Scene.SampleScene);
        }
    }

    private IEnumerator NextImage()
    {
        cutsceneImage.sprite = cutsceneSprites[sceneIndex];
        sceneIndex++;
        yield return new WaitForSeconds(1f);
        nextButton.gameObject.SetActive(true);

    }
}
