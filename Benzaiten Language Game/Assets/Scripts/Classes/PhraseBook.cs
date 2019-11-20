using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class PhraseBook
{
    private List<Phrase> phraseList;

    public PhraseBook()
    {
        phraseList = new List<Phrase>();

        string[] phraseFiles = Directory.GetFiles("Assets/Phrases", "*.json");
        foreach (string file in phraseFiles)
        {
            phraseList.Add(JsonConvert.DeserializeObject<Phrase>(File.ReadAllText(file)));
        }
    }
}
