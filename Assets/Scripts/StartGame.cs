using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string StartLevel;

    public void LoadLevel()
    {
        SceneManager.LoadScene(StartLevel);
        Debug.Log("Começou");
    }
}
