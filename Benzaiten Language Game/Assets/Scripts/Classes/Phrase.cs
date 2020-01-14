using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Phrase
{
    [JsonProperty]
    public string english, japanese;

    [JsonConstructor]
    public Phrase(string english, string japanese)
    {
        this.english = english;
        this.japanese = japanese;
    }

    
}
