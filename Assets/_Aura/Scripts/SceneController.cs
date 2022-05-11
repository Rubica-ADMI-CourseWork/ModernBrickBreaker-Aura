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
       
        SceneManager.LoadSceneAsync(_index);
        StartCoroutine(WaitToReset());
    }

    public void GoToGameOverScene(int _gameOverSceneIndex)
    {
      
        SceneManager.LoadScene(_gameOverSceneIndex);
        StartCoroutine(WaitForLoadGameOverScene());
    }
    private IEnumerator WaitForLoadGameOverScene()
    {
        yield return new WaitForSeconds(.1f);
        FindObjectOfType<UIManager>().HandleGameOverEvent();

    }
    public void GoToNextScene()
    {
        var nxtSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if(nxtSceneIndex == 2)
        {

        SceneManager.LoadSceneAsync(0);
        }
        else
        {
            SceneManager.LoadScene(nxtSceneIndex);
        }
        StartCoroutine(WaitToReset());
    }
    private IEnumerator WaitToReset()
    {
        Debug.Log("resetting Game Manager.");
        yield return new WaitForSeconds(.01f);
        ResetScene();
    }
    public void ReloadCurrentSceneAndDecrementTurnsLeft()
    {
        GameManager.Instance.NoOFTurnsToPlay--;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        StateManager.Instance.currentState = GameStates.AIMING;
    }
    private static void ResetScene()
    {
        FindObjectOfType<UIManager>().HandleGameStartEvent();
        GameManager.Instance.HandleRestart();
        StateManager.Instance.currentState = GameStates.AIMING;
    }
}
