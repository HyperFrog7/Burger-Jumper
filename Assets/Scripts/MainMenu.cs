using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_Dropdown levelDropdown;
    [SerializeField] string[] levelScenes;
    [SerializeField] string mainMenuScene = "MainMenu";

    void Start()
    {
        if (levelDropdown != null)
            levelDropdown.onValueChanged.AddListener(_ => AudioManager.Play(Sfx.Click));

        foreach (Button b in FindObjectsByType<Button>(FindObjectsInactive.Include))
        {
            b.onClick.AddListener(() => AudioManager.Play(Sfx.ButtonPress));

            EventTrigger trigger = b.GetComponent<EventTrigger>();
            if (trigger == null) trigger = b.gameObject.AddComponent<EventTrigger>();

            var hover = new EventTrigger.Entry { eventID = EventTriggerType.PointerEnter };
            hover.callback.AddListener(_ =>
            {
                if (b.interactable) AudioManager.Play(Sfx.ButtonHover);
            });
            trigger.triggers.Add(hover);
        }
    }

    void Update()
    {
        if (Keyboard.current?.escapeKey.wasPressedThisFrame == true && SceneManager.GetActiveScene().name != mainMenuScene)
            SceneManager.LoadScene(mainMenuScene);
    }

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