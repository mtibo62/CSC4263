using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Marks Scene");
    }
    public void ShowHelp()
    {
        SceneManager.LoadScene("Help");
    }
    public void ShowSettings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Die()
    {
        //implement
    }
    public void StartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
