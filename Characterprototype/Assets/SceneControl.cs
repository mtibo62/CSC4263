using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SpaceShip");
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
        SceneManager.LoadScene("Death");
    }
    public void PlayAgain()
    {
        string level = PlayerPrefs.GetString("Level");
        SceneManager.LoadScene(level);
    }
    public void StartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().name == "SpaceShip")
            SceneManager.LoadScene("GrassLevel");
        if (SceneManager.GetActiveScene().name == "GrassLevel")
            SceneManager.LoadScene("FireLevel");
        if (SceneManager.GetActiveScene().name == "FireLevel")
        {
            Cursor.visible = true;
            SceneManager.LoadScene("Victory");
        }
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
