using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button[] DisButton;
    public void Start()
    {
        foreach (var item in DisButton)
        {
            item.interactable = false;
            item.enabled = false;
        }
    }

    public void Play()
    {   

        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
