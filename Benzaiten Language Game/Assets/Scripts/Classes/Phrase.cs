using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Phrase
{
    [JsonProperty]
    private string english, japanese;
    private bool unlocked;

    [JsonConstructor]
    public Phrase(string english, string japanese)
    {
        this.english = english;
        this.japanese = japanese;
        unlocked = false;
    }

    public Phrase(string english, string japanese, bool unlocked)
    {
        this.english = english;
        this.japanese = japanese;
        this.unlocked = unlocked;
    }

    public void Unlock()
    {
        unlocked = true;
    }
}
