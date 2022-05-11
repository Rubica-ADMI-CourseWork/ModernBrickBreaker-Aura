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
            if (noOfBallsInScene <= 0)
            {
                StartCoroutine(PauseBeforeAiming());
                GameManager.Instance.NoOFTurnsToPlay--;
            }
        }
    }

    private IEnumerator PauseBeforeAiming()
    {
        yield return new WaitForSeconds(1f);
        StateManager.Instance.currentState = GameStates.AIMING;

    }

    private void Start()
    {
        NoOfBallsInScene = GameManager.Instance.NoOfBallsToSpawnEachRound;
    }

    public void DestroyAllBallsInScene()
    {
        var ballsInScene = GameObject.FindGameObjectsWithTag("Ball");
        if (ballsInScene != null)
        {
            foreach (var ball in ballsInScene)
            {
                Destroy(ball);
            }
            NoOfBallsInScene = 0;
        }


    }
}
