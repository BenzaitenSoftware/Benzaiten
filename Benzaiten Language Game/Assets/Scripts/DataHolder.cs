using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataHolder : MonoBehaviour
{
    public string fileName;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void LoadIntro()
    {
        fileName = "Intro.json";
        SceneManager.LoadScene("Testing");
    }
    public void LoadAdvanced()
    {
        fileName = "Kaoru.json";
        SceneManager.LoadScene("Testing");
    }
}
