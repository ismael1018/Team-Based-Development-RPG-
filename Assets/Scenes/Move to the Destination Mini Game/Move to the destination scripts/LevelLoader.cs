using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance;


    public List<GameObject> MazeList = new List<GameObject>();

    [SerializeField] GameObject currentMaze;
    public Transform mazeGameTransform;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadLevel(int MazeSelection)
    {
        foreach(GameObject i in MazeList)
        {
            i.SetActive(false);
        }


        currentMaze = MazeList[MazeSelection];
        //MazeList[MazeSelection].transform.position = mazeGameTransform.position;
        currentMaze.SetActive(true);
    }

    public void LoadRandomLevel()
    {
        int randomSelection = Random.Range(0, MazeList.Count);
        LoadLevel(randomSelection);
    }
}
