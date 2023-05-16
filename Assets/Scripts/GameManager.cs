using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static bool isRestart = false;
    public static bool isStart = true;

   

    #region Yeniden Oyna Tuþu
    public void RestartGame()
    {
        Player.score = PlayerPrefs.GetInt("yeniScore");
        isRestart = true;
        Player.health = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion

    #region Continue Tuþu
    public void ContinueGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
        Player.isStart = true;
        Player.score = PlayerPrefs.GetInt("yeniScore");
        
    }
    #endregion

    #region Save Tuþu
    public void SaveGame()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Player.score = PlayerPrefs.GetInt("yeniScore");
    }
    #endregion

    #region Back Tuþu
    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    #endregion

    #region Çýkýþ Tuþu
    public void QuitGame ()
    {
        
        Application.Quit();
    }
    #endregion
}
