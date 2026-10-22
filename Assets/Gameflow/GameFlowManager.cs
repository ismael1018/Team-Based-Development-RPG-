using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    public static GameFlowManager Instance;
    public GameProgress progress;
    public MinigameSelector selector;
    public GameScreens screens;
    public float introDuration = 3f;
    public float transitionDuration = 3f;
    public float gameOverDuration = 5f;

    public string[] introPhrases =
    {
        "TAKE YOUR SHOT!",
        "FIND THE EXIT!",
        "DODGE!",
        "POP THAT CORK!",
        "KEEP YOUR BALANCE!"
    };

    private bool runStarted;
    private bool changingScene;
    private bool finished;
    private Coroutine routine;
    public bool GameplayActive { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (progress == null)
            progress = GetComponent<GameProgress>();

        if (selector == null)
            selector = GetComponent<MinigameSelector>();

        if (screens == null)
            screens = GetComponent<GameScreens>();

        if (progress == null || selector == null ||
            screens == null)
        {
            Debug.LogError(
                "Add GameProgress and MinigameSelector"
            );
            enabled = false;
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
        Time.timeScale = 1f;
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Time.timeScale = 1f;
            Instance = null;
        }
    }

    public void StartRun()
    {
        if (runStarted)
        return;

        runStarted = true;
        finished = false;
        changingScene = false;

        progress.ResetProgress();
        selector.ResetSelector();

        LoadNextMinigame();
    }

    void LoadNextMinigame()
    {
        string scene = selector.GetNextScene();

        if (string.IsNullOrEmpty(scene))
        {
            Debug.LogError("No minigame scenes");
            runStarted = false;
            return;
        }

        changingScene = true;
        GameplayActive = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!runStarted || finished)
        return;

        GameplayActive = false;

        routine = StartCoroutine(BeginMinigame(scene.name));
    }

    IEnumerator BeginMinigame(string sceneName)
    {
        Time.timeScale = 0f;

        screens.Show(GetIntroPhrase(sceneName));

        yield return new WaitForSecondsRealtime(introDuration);

        screens.Hide();
        Time.timeScale = 1f;
        GameplayActive = true;
        changingScene = false;
    }

    string GetIntroPhrase(string sceneName)
    {
        string[] scenes = selector.availableScenes;

        for (int i = 0; i < scenes.Length; i++)
        {
            if (scenes[i] == sceneName &&
            i < introPhrases.Length)
            {
                return introPhrases[i];
            }
        }

        return "GET READY!";
    }

    public void FinishMinigame(bool won)
    {
        if (!runStarted || changingScene || finished)
        return;

        changingScene = true;
        GameplayActive = false;

        if (routine != null)
        StopCoroutine(routine);

        routine = StartCoroutine(ProcessResult(won));
    }

    IEnumerator ProcessResult(bool won)
    {
        Time.timeScale = 0f;
        progress.RecordResult(won);

        if (progress.Lives <= 0)
        {
            finished = true;

            screens.Show("GAME OVER\n\n" + "Minigames Completed: " + progress.GamesCompleted + "\nCurrent Speed: " + progress.CurrentSpeed.ToString("F1") + "x");

            yield return new WaitForSecondsRealtime(gameOverDuration);

            screens.Hide();
            Time.timeScale = 1f;
            runStarted = false;
            changingScene = false;

            SceneManager.LoadScene("Main Menu");
            yield break;
        }

        screens.Show("Minigames Completed: " + progress.GamesCompleted + "\nLives Remaining: " + progress.Lives);

        yield return new WaitForSecondsRealtime(transitionDuration);

        LoadNextMinigame();
    }
}