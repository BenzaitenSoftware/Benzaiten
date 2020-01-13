using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Message
{
    [JsonProperty]
    private string text;
    [JsonProperty]
    private bool player;
    [JsonProperty]
    private bool branching;
    [JsonProperty]
    private Dictionary<string, int> branches;
    [JsonProperty]
    private int playerAnimState, npcAnimState;
    [JsonProperty]
    private float progression;

    public Message(string text, bool player)
    {
        this.text = text;
        this.player = player;
        this.branching = false;
        branches = new Dictionary<string, int>();
        progression = 0;
        playerAnimState = 0;
        npcAnimState = 0;
    }

    [JsonIgnore]
    public string Text
    {
        get
        {
            return text;
        }
    }
    [JsonIgnore]
    public bool Player
    {
        get
        {
            return player;
        }
    }
    [JsonIgnore]
    public bool Branching
    {
        get
        {
            return branching;
        }
    }
    [JsonIgnore]
    public Dictionary<string,int> Branches
    {
        get
        {
            return branches;
        }
    }
    [JsonIgnore]
    public int PlayerAnimState
    {
        get
        {
            return playerAnimState;
        }
    }
    [JsonIgnore]
    public int NpcAnimState
    {
        get
        {
            return npcAnimState;
        }
    }
    [JsonIgnore]
    public float Progression
    {
        get
        {
            return progression;
        }
    }
}
