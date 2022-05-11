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
                FindObjectOfType<UIManager>().SetCancellingText(" ");
                FindObjectOfType<UIManager>().SetCanShootText(true);

                break;
            case GameStates.SHOOTING:
                //disable line renderer
                FindObjectOfType<InputHandler>().DisableLineRenderer();
                FindObjectOfType<UIManager>().SetCanShootText(false);

                //balls are in scene,disallow
                //aiming via input handler until
                //all balls are out of scene
                break;
            case GameStates.CANCELLING:
                FindObjectOfType<UIManager>().SetCancellingText("Cancelling!");
                FindObjectOfType<UIManager>().SetCanShootText(false);

                break;
            case GameStates.GAMEOVER:
                FindObjectOfType<UIManager>().SetCanShootText(false);

                break;

        }
    }

    public void HandleCancelAction()
    {
        
        SceneController.Instance.ReloadCurrentSceneAndDecrementTurnsLeft();

    }
}
