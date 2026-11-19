using DiscordRPC;
using UnityEngine;

public class DiscordStatus : MonoBehaviour
{
    public string applicationId = "PASTE_APPLICATION_ID_HERE";

    static DiscordStatus instance;
    DiscordRpcClient client;

    void Awake()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);

        client = new DiscordRpcClient(applicationId);
        client.Initialize();
        client.SetPresence(new RichPresence
        {
            Details = "Playing Burger Jumper",
            State = "Level 1",
            Assets = new Assets { LargeImageKey = "burger" }
        });
    }

    void OnDestroy()
    {
        if (instance == this) client?.Dispose();
    }
}