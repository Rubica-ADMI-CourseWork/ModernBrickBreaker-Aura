using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleRestart : MonoBehaviour
{
   public void HandleRestartAction()
    {
        SceneController.Instance.GoToSceneByIndex(0);
    }
}
