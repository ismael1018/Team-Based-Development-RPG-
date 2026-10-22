using UnityEngine;
using TMPro;

public class MazeGameManager : MonoBehaviour
{
    public float timeLeft = 10f;
    public TMP_Text timerText;
    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded) return;

        timeLeft -= Time.deltaTime;
        timeLeft = Mathf.Max(0f, timeLeft);

        if (timerText != null)
        timerText.text = Mathf.Ceil(timeLeft).ToString();

        if (timeLeft <= 0f)
        LoseGame();
    }

    public void WinGame()
    {
        if (gameEnded) return;
        gameEnded = true;

        if (GameFlowManager.Instance != null)
        GameFlowManager.Instance.FinishMinigame(true);
    }

    void LoseGame()
    {
        if (gameEnded) return;
        gameEnded = true;

        if (GameFlowManager.Instance != null)
        GameFlowManager.Instance.FinishMinigame(false);
    }
}