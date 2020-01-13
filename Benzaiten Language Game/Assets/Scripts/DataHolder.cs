using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.AddressableAssets;
using Newtonsoft.Json;
using System.IO;

public class DataHolder : MonoBehaviour
{
    [JsonIgnore]
    public string fileName;
    public Player player;
    private bool fileDetected;
    private PhraseBook phraseBook;
    private UnityWebRequest dateConnection;

    // Start is called before the first frame update
    void Start()
    { 
        DontDestroyOnLoad(this);

        if (File.Exists(Application.persistentDataPath + "/PlayerData.save"))
        {
            fileDetected = true;
            player = JsonConvert.DeserializeObject<Player>(File.ReadAllText(Application.persistentDataPath + "/PlayerData.save"));
        }
        else
        {
            fileDetected = false;
            player = new Player();
        }
    }

    private void OnApplicationQuit()
    {
        Debug.Log("Application Quit!");
        File.WriteAllText(Application.persistentDataPath + "/PlayerData.save", JsonConvert.SerializeObject(player, Formatting.Indented));
    }

    public void Splash(bool connection, UnityWebRequest uwr)
    {
        dateConnection = uwr;

        if (connection)
        {
            if (fileDetected)
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                SceneManager.LoadScene("PlayerSetup");
            }
        }
        else
        {
            Debug.Log("CONNECTION FAILED");
        }
    }

    public void SetupPlayer(string name)
    {
        player.PlayerName = name;
        File.WriteAllText(Application.persistentDataPath + "/PlayerData.save", JsonConvert.SerializeObject(player, Formatting.Indented));
        SceneManager.LoadScene("MainMenu");
    }

    public void Play()
    {
        if (player.PlayerProgression["Guide"] == 1)
        {
            SceneManager.LoadScene("CafeScene");
        }
        else
        {
            LoadConversation("Guide.json");
        }
        
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadConversation(string fileName)
    {
        Debug.Log(fileName);
        this.fileName = fileName;
        SceneManager.LoadScene("ConversationScene");
    }
}
