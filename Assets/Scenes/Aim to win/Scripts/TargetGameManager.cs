using UnityEngine;
using TMPro;

public class TargetGameManager : MonoBehaviour
{
    public float timeLeft = 10f;
    public int targetsNeeded = 5;
    public int dangerousHitsAllowed = 3;
    public TMP_Text timerText;
    public TMP_Text targetsText;
    public TMP_Text healthText;
    private int targetsDestroyed = 0;
    private int dangerousHits = 0;
    private bool gameEnded = false;

    void Start()
    {
        UpdateTargetsText();
        UpdateHealthText();
    }

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

    public void TargetHit(bool dangerous)
    {
        if (gameEnded) return;

        if (dangerous)
        {
            dangerousHits++;
            UpdateHealthText();

            Debug.Log("Bomb hit! Hits: " + dangerousHits);

            if (dangerousHits >= dangerousHitsAllowed)
            LoseGame();
        }
        else
        {
            targetsDestroyed++;
            UpdateTargetsText();

            Debug.Log("Normal target hit! Targets: " + targetsDestroyed);

            if (targetsDestroyed >= targetsNeeded)
            WinGame();
        }
    }

    void UpdateTargetsText()
    {
        if (targetsText != null)
        targetsText.text = "Targets: " + targetsDestroyed + "/" + targetsNeeded;
    }

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            int remaining = dangerousHitsAllowed - dangerousHits;
            healthText.text = "Hits Remaining: " + remaining;
        }
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