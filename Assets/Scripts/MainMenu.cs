using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_Dropdown levelDropdown;
    [SerializeField] string[] levelScenes; // same order as dropdown options

    public void Play() => SceneManager.LoadScene(levelScenes[levelDropdown.value]);

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}