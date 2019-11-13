using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using System.IO;

public class DataHolder : MonoBehaviour
{
    [JsonIgnore]
    public string fileName;
    public Dictionary<string, float> playerProgression;

    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists("Assets/PlayerData/Player.save"))
        {
            playerProgression = JsonConvert.DeserializeObject<Dictionary<string, float>>(File.ReadAllText("Assets/PlayerData/Player.save"));
        }
        else
        {
            playerProgression = new Dictionary<string, float>();
        }
        DontDestroyOnLoad(this);
    }

    private void OnApplicationQuit()
    {
        Debug.Log("Application Quit!");
        File.WriteAllText("Assets/PlayerData/Player.json", JsonConvert.SerializeObject(playerProgression, Formatting.Indented));
    }

    public void LoadConversation(string fileName)
    {
        this.fileName = fileName;
        SceneManager.LoadScene("Testing");
    }

    public void AddProgression(string[] input)
    {
        string name = input[0];
        float points = float.Parse(input[1]);

        Debug.Log(name);
        Debug.Log(points);

        if (playerProgression.ContainsKey(name))
        {
            playerProgression[name] += points;
        }
        else
        {
            playerProgression[name] = points;
        }
    }
}
