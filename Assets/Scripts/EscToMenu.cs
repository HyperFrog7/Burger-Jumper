using UnityEngine;
using UnityEngine.SceneManagement;

public class EscToMenu : MonoBehaviour
{
    [SerializeField] string mainMenuScene = "MainMenu";
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;

        AudioManager.Play(Sfx.ButtonPress);
        SceneManager.LoadScene(mainMenuScene);
    }
}
