using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton Setup
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    #endregion

    [SerializeField] int turnsToPlay;
    [SerializeField] int noOfBallsToSpawnEachRound;
    [SerializeField] int noOFTurnsToPlay;
    public int NoOFTurnsToPlay
    {
        get => noOFTurnsToPlay;
        set
        {
            noOFTurnsToPlay = value;
            if(noOFTurnsToPlay <= 0)
            {
                StateManager.Instance.currentState = GameStates.GAMEOVER;
                SceneController.Instance.GoToGameOverScene(2);
            }
            FindObjectOfType<UIManager>().SetTurnsLeft(noOFTurnsToPlay);
        }
    }
    public int NoOfBallsToSpawnEachRound
    {
        get { return noOfBallsToSpawnEachRound; }
        private set { noOfBallsToSpawnEachRound = value; }
    }

    private void Awake()
    {
        if(instance!= null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
       
    }
    private void Start()
    {
        ResetNoOfTurns();
        FindObjectOfType<UIManager>().HandleGameStartEvent();
    }
    public void ResetBallsToSpawn()
    {
        NoOfBallsToSpawnEachRound = noOfBallsToSpawnEachRound;
    }
    public void ResetNoOfTurns()
    {
        NoOFTurnsToPlay = turnsToPlay;
    }
    
    public void HandleRestart()
    {
        ResetBallsToSpawn();
        ResetNoOfTurns();
    }
}
