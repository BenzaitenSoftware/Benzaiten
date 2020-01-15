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
    public Player player;
    private bool fileDetected;
    private PhraseBook phrasebook;
    private UnityWebRequest dateConnection;
    private AudioSource audio;
    private float volume;

    // Start is called before the first frame update
    void Start()
    { 
        DontDestroyOnLoad(this);

        phrasebook = new PhraseBook();
        audio = GetComponent<AudioSource>();
        volume = 0.6f;
        audio.volume = volume;


        if (File.Exists(Application.persistentDataPath + "/PlayerData.save"))
        {
            string jsonString = File.ReadAllText(Application.persistentDataPath + "/PlayerData.save");
            Debug.Log(jsonString);
            if (jsonString.Equals("null"))
            {
                player = new Player();
                fileDetected = false;
            }
            else
            {
                player = JsonConvert.DeserializeObject<Player>(jsonString);
                fileDetected = true;
            }
        }
        else
        {
            fileDetected = false;
            player = new Player();
        }
    }

    public void VolumeUpdate(float value)
    {
        volume = value;
        audio.volume = volume;
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

    public void ResetPlayer()
    {
        player = new Player();
        SceneManager.LoadScene("PlayerSetup");
    }

    public void SetupPlayer(string name, int choice)
    {
        player.PlayerName = name;
        player.PlayerSprite = choice;
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

    public void LoadConversation(string fileName)
    {
        Debug.Log(fileName);
        this.fileName = fileName;
        SceneManager.LoadScene("ConversationScene");
    }

    private void OnApplicationQuit()
    {
        Debug.Log("Application Quit!");
        SaveProgress();
    }

    public void SaveProgress()
    {
        File.WriteAllText(Application.persistentDataPath + "/PlayerData.save", JsonConvert.SerializeObject(player, Formatting.Indented));
    }

    public void Exit()
    {
        Application.Quit();
    }

    public PhraseBook Phrasebook
    {
        get
        {
            return phrasebook;
        }
    }

    public float Volume
    {
        get
        {
            return volume;
        }
    }
}
