using UnityEngine;

public class GameProgress : MonoBehaviour
{
    public int startingLives = 5;
    public int difficultyInterval = 5;
    public float startingTime = 10f;
    public float timeDecrease = 1f;
    public float minimumTime = 3f;
    public float startingSpeed = 1f;
    public float speedIncrease = 0.2f;
    public int Lives { get; private set; }
    public int GamesCompleted { get; private set; }
    public float CurrentTime { get; private set; }
    public float CurrentSpeed { get; private set; }
    public void ResetProgress()
    {
        Lives = startingLives;
        GamesCompleted = 0;
        CurrentTime = startingTime;
        CurrentSpeed = startingSpeed;
    }

    public void RecordResult(bool won)
    {
        GamesCompleted++;

        if (!won)
        {
            Lives--;
        }

        if (difficultyInterval > 0 &&
            GamesCompleted % difficultyInterval == 0)
        {
            CurrentTime = Mathf.Max(minimumTime, CurrentTime - timeDecrease);

            CurrentSpeed += speedIncrease;
        }
    }
}
