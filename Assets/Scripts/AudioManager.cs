using System.Collections;
using UnityEngine;

public enum Sfx { Click, DeathVoice, ButtonHover, ButtonPress, Bonus, GameOver, Spawn, Whoosh, Respawn }

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    static AudioManager instance;

    [Header("Clips")]
    [SerializeField] AudioClip click;
    [SerializeField] AudioClip deathVoice;
    [SerializeField] AudioClip buttonHover;
    [SerializeField] AudioClip buttonPress;
    [SerializeField] AudioClip bonus;
    [SerializeField] AudioClip gameOver;
    [SerializeField] AudioClip spawn;
    [SerializeField] AudioClip whoosh;
    [SerializeField] AudioClip respawn;

    [Header("Volume")]
    [Range(0f, 1f)] [SerializeField] float sfxVolume = 1f;

    AudioSource sfx;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        sfx = GetComponent<AudioSource>();
        sfx.playOnAwake = false;
    }

    void OnDestroy()
    {
        if (instance == this) instance = null;
    }

    public static void Play(Sfx s, float delay = 0f)
    {
        if (instance == null) return;
        AudioClip c = instance.Get(s);
        if (c == null) return;

        if (delay <= 0f) instance.sfx.PlayOneShot(c, instance.sfxVolume);
        else instance.StartCoroutine(instance.PlayAfter(c, delay));
    }

    IEnumerator PlayAfter(AudioClip c, float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        sfx.PlayOneShot(c, sfxVolume);
    }

    AudioClip Get(Sfx s) => s switch
    {
        Sfx.Click       => click,
        Sfx.DeathVoice  => deathVoice,
        Sfx.ButtonHover => buttonHover,
        Sfx.ButtonPress => buttonPress,
        Sfx.Bonus       => bonus,
        Sfx.GameOver    => gameOver,
        Sfx.Spawn       => spawn,
        Sfx.Whoosh      => whoosh,
        Sfx.Respawn     => respawn,
        _               => null
    };
}
