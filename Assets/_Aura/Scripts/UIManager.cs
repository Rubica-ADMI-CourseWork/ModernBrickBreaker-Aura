using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI turnsLeftText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI cancellingText;
    public GameObject canShootText;

    public GameObject gameOverPanel;
    public ScoreDataSO scoreKeeper;
    private void Start()
    {
        gameOverPanel.SetActive(false);
        cancellingText.text = "";
        canShootText.SetActive(true);
        SetScoreText(scoreKeeper.GetCurrentScore());
    }
    public void SetCancellingText(string _text)
    {
        cancellingText.text = _text;

    }
    public void SetCanShootText(bool onOff)
    {
        canShootText.SetActive(onOff);
    }
    public void SetTurnsLeft(int _turnsLeft)
    {
        turnsLeftText.text = _turnsLeft.ToString();
    }
    public void SetScoreText(int _score)
    {
        scoreText.text = _score.ToString();
    }
    public void HandleGameOverEvent()
    {
        StartCoroutine(ActivateGameOverPanel(true));
    }
    public void HandleGameStartEvent()
    {
        StartCoroutine(ActivateGameOverPanel(false));

    }
    public void HandleMoveToNextSceneEvent()
    {
        StartCoroutine(UploadScore());

    }
    private IEnumerator UploadScore()
    {
        yield return new WaitForSeconds(0.1f);
        SetScoreText(scoreKeeper.GetCurrentScore());
    }
    private IEnumerator ActivateGameOverPanel(bool onOFf)
    {
        yield return new WaitForSeconds(.01f);
        gameOverPanel.SetActive(onOFf);
    }
}
