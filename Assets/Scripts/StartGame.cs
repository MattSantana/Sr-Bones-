using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string StartLevel;
    public GameObject fader;
    public GameObject faderIn;
    public float transitionTime;

    void Start()
    {
        faderIn = GameObject.FindGameObjectWithTag("InTransition");
        faderIn.transform.position = new Vector3(-50, 0, 0);
        fader = GameObject.FindGameObjectWithTag("OutTransition");
        fader.LeanMoveX(-50, transitionTime);
    }

    IEnumerator PlayTransition(string sceneName)
    {
        faderIn.LeanMoveX(10 , transitionTime);
        yield return new WaitForSeconds(transitionTime + 1);
        SceneManager.LoadScene(sceneName);
        Debug.Log("Começou");

    }

    public void GotoScene(string SceneName)
    {
        StartCoroutine(PlayTransition(SceneName));
    }
}
