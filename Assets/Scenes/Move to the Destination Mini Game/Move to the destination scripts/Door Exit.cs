using UnityEngine;

public class DoorExit : MonoBehaviour
{
    public GameObject WinPanel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            WinPanel.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}
