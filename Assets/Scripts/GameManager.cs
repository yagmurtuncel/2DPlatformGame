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

   

    #region Yeniden Oyna Tu�u
    public void RestartGame()
    {
        Player.score = PlayerPrefs.GetInt("yeniScore");
        isRestart = true;
        Player.health = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion

    #region Continue Tu�u
    public void ContinueGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
        Player.isStart = true;
        Player.score = PlayerPrefs.GetInt("yeniScore");
        
    }
    #endregion

    #region Save Tu�u
    public void SaveGame()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Player.score = PlayerPrefs.GetInt("yeniScore");
    }
    #endregion

    #region Back Tu�u
    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    #endregion

    #region ��k�� Tu�u
    public void QuitGame ()
    {
        
        Application.Quit();
    }
    #endregion
}
