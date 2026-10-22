using UnityEngine;
using UnityEngine.SceneManagement;

public class NextMiniGame : MonoBehaviour
{
    public string[] minigameScenes =
    {
        "Move to the Destination Mini Game",
        "Dodge it Mini Game",
        "Aim to win"
    };

    public void LoadNextMinigame()
    {
        int index = PlayerPrefs.GetInt("MinigameIndex", 0);

        if (index >= minigameScenes.Length)
        {
            index = 0;
        }

        SceneManager.LoadScene(minigameScenes[index]);

        PlayerPrefs.SetInt("MinigameIndex", index + 1);
        PlayerPrefs.Save();
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("MinigameIndex", 0);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Hub Scene");
    }
}
