using UnityEngine;
using UnityEngine.SceneManagement;

public class Crate2 : MonoBehaviour
{
    public string message = "You Win! Time for level 3...";
    public string nextScene = "Level3";
    public float seconds = 2f;

    bool show;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (show || !other.CompareTag("Player")) return;
        show = true;
        Invoke(nameof(LoadNext), seconds);
    }

    void LoadNext() => SceneManager.LoadScene(nextScene);

    void OnGUI()
    {
        if (!show) return;
        var style = new GUIStyle(GUI.skin.label)
        {
            fontSize = 64,
            alignment = TextAnchor.MiddleCenter
        };
        style.normal.textColor = Color.white;
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), message, style);
    }
}