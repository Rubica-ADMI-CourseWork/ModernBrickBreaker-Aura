using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    #region Singleton setup

    private static SceneController instance;
    public static SceneController Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance=this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void GoToSceneByIndex(int _index)
    {
        ResetScene();
        SceneManager.LoadSceneAsync(_index);
    }

    public void GoToNextScene()
    {
        ResetScene();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadCurrentSceneAndDecrementTurnsLeft()
    {
        GameManager.Instance.NoOFTurnsToPlay--;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        StateManager.Instance.currentState = GameStates.AIMING;
    }
    private static void ResetScene()
    {
        
        GameManager.Instance.ResetBallsToSpawn();
        GameManager.Instance.ResetNoOfTurns();
        StateManager.Instance.currentState = GameStates.AIMING;
    }
}
