using UnityEngine;
using TMPro;

public class GameScreens : MonoBehaviour
{

    public static GameScreens Instance; 


    [SerializeField] private TMP_Text gameTimer;
    [SerializeField] private TMP_Text gameIntroText;

    void Awake()
    {
        /*
        GameObject canvasObject = new GameObject("GameFlowCanvas");
        Canvas canvas = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 100;
        canvasObject.AddComponent<UnityEngine.UI.CanvasScaler>();
        canvasObject.AddComponent<UnityEngine.UI.GraphicRaycaster>();
        screenRoot = canvasObject;
        DontDestroyOnLoad(canvasObject);
        GameObject textObject = new GameObject("GameFlowText");
        textObject.transform.SetParent(canvasObject.transform, false);
        messageText = textObject.AddComponent<TextMeshProUGUI>();
        messageText.alignment = TextAlignmentOptions.Center;
        messageText.fontSize = 40;
        messageText.color = Color.white;
        RectTransform rect = messageText.rectTransform;
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.offsetMin = new Vector2(30, 30);
        rect.offsetMax = new Vector2(-30, -30);
        */
        GameScreens.Instance = this;

        DontDestroyOnLoad(this);
        HideAll();
    }

    public void ShowText(string message)
    {
        gameTimer.gameObject.SetActive(true);
        gameIntroText.text = message;
    }

    public void ShowTimer()
    {
        gameTimer.gameObject.SetActive(false);
    }

    public void SetTimerNum(string time)
    {
        gameTimer.text = "Timer: " + time;
    }

    public void HideText()
    {
        gameIntroText.gameObject.SetActive(true);
        gameIntroText.text = " ";
    }




    public void HideAll()
    {
        if (gameTimer != null || gameIntroText != null)
        {
            gameTimer.gameObject.SetActive(false);
            gameIntroText.gameObject.SetActive(false);
            
        }
    }

}