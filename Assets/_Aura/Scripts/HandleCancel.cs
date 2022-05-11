using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCancel : MonoBehaviour
{
    [SerializeField] GameObject[] ballsInPlay;
  public void HandleCancelAction()
    {
        StateManager.Instance.currentState = GameStates.CANCELLING;
        FindObjectOfType<BallCounter>().DestroyAllBallsInScene();
    }
}
