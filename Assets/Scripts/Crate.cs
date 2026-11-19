using UnityEngine;

public class Crate : MonoBehaviour
{
    public GameObject winPanel;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        winPanel.SetActive(true);
        Time.timeScale = 0f; // freeze the game
    }
}