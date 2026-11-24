using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EscToMenu : MonoBehaviour
{
    [SerializeField] string mainMenuScene = "MainMenu";
    void Update()
    {
        if (Keyboard.current?.escapeKey.wasPressedThisFrame != true) return;

        AudioManager.Play(Sfx.ButtonPress);
        SceneManager.LoadScene(mainMenuScene);
    }
}