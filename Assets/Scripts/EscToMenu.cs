using UnityEngine;
using UnityEngine.SceneManagement;

public class EscToMenu : MonoBehaviour
{
    [SerializeField] string mainMenuScene = "MainMenu"; // exact scene name

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(mainMenuScene);
    }
}