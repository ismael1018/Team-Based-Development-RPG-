using System.Collections.Generic;
using UnityEngine;

public class MinigameSelector : MonoBehaviour
{
    public bool useRandomOrder = false;

    public string[] orderedScenes =
    {
        "Aim to win",
        "Move to the Destination Mini Game",
        "Dodge it Mini Game",
        "Champaign",
        "Balance game"
    };

    public string[] availableScenes =
    {
        "Aim to win",
        "Move to the Destination Mini Game",
        "Dodge it Mini Game",
        "Champaign",
        "Balance game"
    };

    private int nextIndex;
    private List<string> randomBag = new List<string>();

    public void ResetSelector()
    {
        nextIndex = 0;
        randomBag.Clear();
    }

    public string GetNextScene()
    {
        if (!useRandomOrder)
        {
            if (orderedScenes.Length == 0)
                return "";

            string scene = orderedScenes[nextIndex % orderedScenes.Length];

            nextIndex++;
            return scene;
        }

        if (availableScenes.Length == 0)
        return "";

        if (randomBag.Count == 0)
        {
            randomBag.AddRange(availableScenes);

            for (int i = randomBag.Count - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                string temp = randomBag[i];
                randomBag[i] = randomBag[j];
                randomBag[j] = temp;
            }
        }

        string selected = randomBag[0];
        randomBag.RemoveAt(0);
        return selected;
    }
}