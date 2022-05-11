using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BrickHolder : MonoBehaviour
{
    [SerializeField] int noOfBricksInScene;
    int NoOfBricksInScene
    {
        get => noOfBricksInScene;
        set
        {
            noOfBricksInScene = value;
            if(noOfBricksInScene <= 0)
            {
                //go to next scene
                SceneController.Instance.GoToSceneByIndex(1);
            }
        }
    }

    private void Awake()
    {
        noOfBricksInScene = GameObject.FindGameObjectsWithTag("BrickRegular").Length;
    }

    public void DecrementBrickCount(int _decrementAmount)
    {
        NoOfBricksInScene -= _decrementAmount;
    }

}
