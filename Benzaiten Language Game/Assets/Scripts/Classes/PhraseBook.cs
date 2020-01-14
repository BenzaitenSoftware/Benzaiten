using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class PhraseBook
{
    private Object[] textAssets;
    private List<Phrase> phraseList;

    public PhraseBook()
    {
        textAssets = Resources.LoadAll("Phrases/", typeof(TextAsset));

        phraseList = new List<Phrase>();
        
        foreach(TextAsset obj in textAssets)
        {
            Debug.Log(obj.text);
            phraseList.Add(JsonConvert.DeserializeObject<Phrase>(obj.text));
        }
    }

    public List<Phrase> PhraseList
    {
        get
        {
            return phraseList;
        }
    }
}
