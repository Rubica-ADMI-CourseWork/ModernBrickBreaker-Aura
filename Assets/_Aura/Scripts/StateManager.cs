using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates
{
    SHOOTING,
    AIMING,
    CANCELLING,
    GAMEOVER,
    CHILLING
}
public class StateManager : MonoBehaviour
{
    #region Singleton Setup
    private static StateManager instance;
    public static StateManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<StateManager>();
                if (instance == null)
                {
                    instance = new GameObject().AddComponent<StateManager>();
                }
            }
           
            return instance;
        }
    } 

    #endregion


    public GameStates currentState;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        currentState = GameStates.AIMING;
        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
    }
    private void Update()
    {
        switch (currentState)
        {
            case GameStates.CHILLING:
                //DO NOTHING
                break;
            case GameStates.AIMING:
                //allow aiming via InputHandler
                break;
            case GameStates.SHOOTING:
                //disable line renderer
                FindObjectOfType<InputHandler>().DisableLineRenderer();
                //balls are in scene,disallow
                //aiming via input handler until
                //all balls are out of scene
                break;
            case GameStates.CANCELLING:
                
                break;
            case GameStates.GAMEOVER:
                SceneController.Instance.GoToSceneByIndex(2);
                break;

        }
    }

    public void HandleCancelAction()
    {
        
        SceneController.Instance.ReloadCurrentSceneAndDecrementTurnsLeft();

    }
}
