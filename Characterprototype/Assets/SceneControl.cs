﻿using System.Collections;
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
            SceneManager.LoadScene("IceLevel");
        if (SceneManager.GetActiveScene().name == "IceLevel")
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
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Space()
    {
        SceneManager.LoadScene("SpaceShip");
    }
    public void Grass()
    {
        SceneManager.LoadScene("GrassLevel");
    }
    public void Ice()
    {
        SceneManager.LoadScene("IceLevel");
    }
    public void Fire()
    {
        SceneManager.LoadScene("FireLevel");
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
