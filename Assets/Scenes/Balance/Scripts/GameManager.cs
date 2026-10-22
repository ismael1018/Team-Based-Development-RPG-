using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Rigidbody2D platformBody;
    public TMP_Text timerText;
    public TMP_Text resultText;
    public float timeLimit = 10f;
    public float maxTilt = 30f;
    private float timeLeft;
    private bool gameEnded = false;

    void Start()
    {
        timeLeft = timeLimit;

        if (resultText != null)
        resultText.text = "";

        if (timerText != null)
        timerText.text = "Time: " + Mathf.Ceil(timeLeft).ToString();
    }

    void Update()
    {
        if (gameEnded) return;

        timeLeft -= Time.deltaTime;
        timeLeft = Mathf.Max(0f, timeLeft);

        if (timerText != null)
        timerText.text = "Time: " + Mathf.Ceil(timeLeft).ToString();

        if (platformBody != null)
        {
            float angle = Mathf.DeltaAngle(0f, platformBody.rotation);

            if (Mathf.Abs(angle) >= maxTilt)
            {
                EndGame(false);
                return;
            }
        }

        if (timeLeft <= 0f)
        EndGame(true);
    }

    public void EndGame(bool won)
    {
        if (gameEnded) return;
        gameEnded = true;

        if (resultText != null)
        resultText.text = won ? "YOU WIN!" : "YOU LOSE!";

        Debug.Log(won ? "Minigame won!" : "Minigame lost!");

        if (GameFlowManager.Instance != null)
        GameFlowManager.Instance.FinishMinigame(won);
    }

    public bool IsGameEnded()
    {
        return gameEnded;
    }
}