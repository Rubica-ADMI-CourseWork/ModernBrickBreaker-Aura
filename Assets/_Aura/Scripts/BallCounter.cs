using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCounter : MonoBehaviour
{
    [SerializeField] int noOfBallsInScene;
    public int NoOfBallsInScene
    {
        get { return noOfBallsInScene; }
        set
        {
            noOfBallsInScene = value;
            if(noOfBallsInScene <= 0)
            {
                StateManager.Instance.currentState = GameStates.AIMING;
                GameManager.Instance.NoOFTurnsToPlay--;
            }
        }
    }

    private void Start()
    {
        NoOfBallsInScene = GameManager.Instance.NoOfBallsToSpawnEachRound;
    }

    public void DestroyAllBallsInScene()
    {
        var ballsInScene = GameObject.FindGameObjectsWithTag("Ball");
        foreach (var ball in ballsInScene)
        {
            Destroy(ball);        
        }
        NoOfBallsInScene = 0;
        StateManager.Instance.currentState = GameStates.AIMING;
        
    }
}
