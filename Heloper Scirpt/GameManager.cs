using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isLose;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void RestartGame()
    {
        Invoke("RestartAfterTime", 2f);
        isLose = true;
    }
    void RestartAfterTime()
    {
        UIManager.instance.OnLose();
        if (Time.timeScale == 1.0f)
            Time.timeScale = 0.0f;
    }
    public void LoadSceneGame(string names)
    {
        SceneManager.LoadScene(names);
        if (Time.timeScale != 1.0f)
            Time.timeScale = 1.0f;
    }
}
