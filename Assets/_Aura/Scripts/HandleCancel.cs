using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCancel : MonoBehaviour
{
    [SerializeField] GameObject[] ballsInPlay;
  public void HandleCancelAction()
    {
        if (StateManager.Instance.currentState != GameStates.SHOOTING) return;
        StateManager.Instance.currentState = GameStates.CANCELLING;
        FindObjectOfType<BallCounter>().DestroyAllBallsInScene();
    }
}
