using UnityEngine;
using UnityEngine.SceneManagement;

public class Crate : MonoBehaviour
{
    public string nextScene = "Level2";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextScene);
    }
}