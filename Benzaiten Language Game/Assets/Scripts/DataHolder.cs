using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.IO;

public class DataHolder : MonoBehaviour
{
    [JsonIgnore]
    public string fileName;
    private string playerName;
    private PhraseBook phraseBook;
    private Dictionary<string, float> playerProgression;
    private UnityWebRequest dateConnection;

    // Start is called before the first frame update
    void Start()
    {
        playerName = "Luke";
        phraseBook = new PhraseBook();

        if (File.Exists("Assets/PlayerData/Player.save"))
        {
            playerProgression = JsonConvert.DeserializeObject<Dictionary<string, float>>(File.ReadAllText("Assets/PlayerData/Player.save"));
        }
        else
        {
            playerProgression = new Dictionary<string, float>();
        }

        // TESTING CODE
        playerProgression = new Dictionary<string, float>();

        DontDestroyOnLoad(this);
    }

    private void OnApplicationQuit()
    {
        Debug.Log("Application Quit!");
        File.WriteAllText("Assets/PlayerData/" + playerName + ".json", JsonConvert.SerializeObject(playerProgression, Formatting.Indented));
    }

    public void Splash(bool connection, UnityWebRequest uwr)
    {
        dateConnection = uwr;

        if (connection)
        {
            SceneManager.LoadScene("Main Menu");
        }
        else
        {
            Debug.Log("CONNECTION FAILED");
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("CafeScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadConversation(string fileName)
    {
        this.fileName = fileName;
        SceneManager.LoadScene("ConversationScene");
    }

    public void SetProgression(string[] input)
    {
        string name = input[0];
        float points = float.Parse(input[1]);

        playerProgression[name] = points;
    }

    public string PlayerName
    {
        get
        {
            return playerName;
        }
        set
        {
            name = value;
        }
    }

    public Dictionary<string,float> PlayerProgression
    {
        get
        {
            return playerProgression;
        }
        set
        {
            playerProgression = value;
        }
    }
}
