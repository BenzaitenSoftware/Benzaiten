using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Newtonsoft.Json;
using System;

public class Conversation
{
    [JsonProperty]
    private Message[] messageList;
    private string NPCString;

    private int currentMessage = 0;

    public Conversation(Message[] messageList)
    {
        this.messageList = messageList;
    }

    public Message NextMessage()
    {
        if (currentMessage == 0)
        {
            return messageList[0];
        }
        else if (currentMessage < messageList.Length)
        {
            int nextIndex = messageList[currentMessage].Branches["Next"];
            if (nextIndex != -1)
            {
                currentMessage = nextIndex;
                return messageList[currentMessage];
            }
            else
            {
                GameObject.Find("DataHolder").GetComponent<DataHolder>().player.SetProgression(NPCString, messageList[currentMessage].Progression);
                return null;
            }  
        }
        else
        {
            return null;
        }
    }

    public Message NextMessage(int choice)
    {
        if (choice < messageList.Length)
        {
            currentMessage = choice;
            return messageList[choice];
        }
        else
        {
            return null;
        }
    }

    public string NPC
    {
        get
        {
            return NPCString;
        }

        set
        {
            NPCString = value;
        }
    }
}
