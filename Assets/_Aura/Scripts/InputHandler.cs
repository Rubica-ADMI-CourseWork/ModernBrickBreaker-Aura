using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Handles all touch input
/// </summary>
public class InputHandler : MonoBehaviour
{
    #region Singleton Setup
    private static InputHandler instance;
    public static InputHandler Instance
    {
        get
        {
            return instance;
        }
    } 
    #endregion


    [SerializeField] float lineRendererPreferredWidth = 0.1f;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform ballSpawnPosition;
    [SerializeField] float ballSpawnSpacingTime = 0.1f;

    Vector3 currentStartTouchPos;
    Vector3 currentEndTouchPos;
    Vector3 dragTouchPos;
    Vector3 shootDirection;

    LineRenderer lineRenderer;

    bool fingerIsOnScreen = true;

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
    private void Start()
    {
        ballSpawnPosition = GameObject.FindGameObjectWithTag("BallSpawnPosition").transform;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }
    private void Update()
    {
        if (StateManager.Instance.currentState != GameStates.AIMING || EventSystem.current.IsPointerOverGameObject()) return;

        if (Input.GetMouseButtonDown(0) )
        {
                currentStartTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentStartTouchPos.z = 0;
                lineRenderer.enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            dragTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragTouchPos.z = 0;
            Debug.Log(dragTouchPos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            currentEndTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentEndTouchPos.z = 0;

            StateManager.Instance.currentState = GameStates.SHOOTING;
            CalculateShootDirection(currentEndTouchPos);
        }

        SetUpLineRenderer();
    }

    private void SetUpLineRenderer()
    {
        lineRenderer.startWidth = lineRendererPreferredWidth;
        lineRenderer.endWidth = lineRendererPreferredWidth;
        ReAlignLineRenderer(ballSpawnPosition);
        lineRenderer.SetPosition(1, dragTouchPos);
    }
    public void DisableLineRenderer()
    {
        lineRenderer.enabled = false;
    }
    private void CalculateShootDirection(Vector3 currentEndTouchPos)
    {
        shootDirection = currentEndTouchPos - currentStartTouchPos;
        shootDirection.z = 0;
        shootDirection = shootDirection.normalized;
        Debug.Log("shoot direction: " + shootDirection);
        //once you have shoot direction, fire balls.
        ReAlignLineRenderer(ballSpawnPosition);
        StartCoroutine(ShootBall(shootDirection));
    }
    private void ReAlignLineRenderer(Transform ballSpawnPosition)
    {
        lineRenderer.SetPosition(0, ballSpawnPosition.position);
    }
    private IEnumerator ShootBall(Vector3 shootDirection)
    {
        GameObject spawnedBall;

        for (int i = 0; i < GameManager.Instance.NoOfBallsToSpawnEachRound; i++)
        {
            spawnedBall = Instantiate(ballPrefab, ballSpawnPosition.position, Quaternion.identity);
            var spawnedBallRb = spawnedBall.GetComponent<Rigidbody2D>();
            spawnedBallRb.AddForce(shootDirection * 10f, ForceMode2D.Impulse);
            yield return new WaitForSeconds(ballSpawnSpacingTime);
        }
        FindObjectOfType<BallCounter>().NoOfBallsInScene = GameManager.Instance.NoOfBallsToSpawnEachRound;


    }
}
