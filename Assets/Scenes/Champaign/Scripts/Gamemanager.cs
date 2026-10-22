using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public float timeLimit = 10f;
    public int pressesRequired = 20;
    public TMP_Text timerText;
    public TMP_Text instructionsText;
    public TMP_Text resultText;
    public Slider progressBar;
    private float timeLeft;
    private int pressCount = 0;
    private KeyCode nextKey = KeyCode.W;
    private bool gameEnded = false;

    void Start()
    {
        timeLeft = timeLimit;

        if (resultText != null)
        resultText.text = "";

        if (instructionsText != null)
        instructionsText.text = "Alternate W and S to pop the cork!";

        UpdateProgress();
    }

    void Update()
    {
        if (gameEnded) return;

        timeLeft -= Time.deltaTime;

        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Ceil(Mathf.Max(0f, timeLeft)).ToString();
        }

        if (Input.GetKeyDown(nextKey))
        {
            pressCount++;

            nextKey = nextKey == KeyCode.W? KeyCode.S: KeyCode.W;

            UpdateProgress();

            if (pressCount >= pressesRequired)
            {
                EndGame(true);
                return;
            }
        }

        if (timeLeft <= 0f)
            EndGame(false);
    }

    void UpdateProgress()
    {
        if (progressBar != null)
        {
            progressBar.maxValue = pressesRequired;
            progressBar.value = pressCount;
        }

        if (instructionsText != null)
        {
            instructionsText.text = "Press " + nextKey + "! (" + pressCount + "/" + pressesRequired + ")";
        }
    }

    void EndGame(bool won)
    {
        if (gameEnded) return;
        gameEnded = true;

        if (resultText != null)
        {
            resultText.text = won? "CORK POPPED! YOU WIN!" : "TIME'S UP! YOU LOSE!";
        }

        Debug.Log(won? "Champagne minigame won!" : "Champagne minigame lost!");

        if (GameFlowManager.Instance != null)
        GameFlowManager.Instance.FinishMinigame(won);
    }
}