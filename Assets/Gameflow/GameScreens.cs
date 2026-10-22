using UnityEngine;
using TMPro;

public class GameScreens : MonoBehaviour
{
    private GameObject screenRoot;
    private TMP_Text messageText;

    void Awake()
    {
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

        Hide();
    }

    public void Show(string message)
    {
        messageText.text = message;
        screenRoot.SetActive(true);
    }

    public void Hide()
    {
        if (screenRoot != null)
        {
            screenRoot.SetActive(false);
        }
    }
}