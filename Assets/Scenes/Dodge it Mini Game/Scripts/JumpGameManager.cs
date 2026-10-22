using UnityEngine;
using TMPro;

public class JumpGameManager : MonoBehaviour
{
    public float timeLeft = 10f;
    public int hitsAllowed = 3;
    public TMP_Text timerText;
    public TMP_Text hitsText;
    private int hits = 0;
    private bool gameEnded = false;

    void Start()
    {
        if (hitsText != null)
        hitsText.text = "Hits: 0/" + hitsAllowed;
    }

    void Update()
    {
        if (gameEnded) return;

        timeLeft -= Time.deltaTime;
        timeLeft = Mathf.Max(0f, timeLeft);

        if (timerText != null)
        timerText.text = Mathf.Ceil(timeLeft).ToString();

        if (timeLeft <= 0f)
        WinGame();
    }

    public void PlayerHit()
    {
        if (gameEnded) return;

        hits++;

        if (hitsText != null)
            hitsText.text = "Hits: " + hits + "/" + hitsAllowed;

        if (hits >= hitsAllowed)
        LoseGame();
    }

    void WinGame()
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