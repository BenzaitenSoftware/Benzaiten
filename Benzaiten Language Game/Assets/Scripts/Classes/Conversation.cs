using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Newtonsoft.Json;

public class Conversation
{
    [JsonProperty]
    private Message[] messageList;
    private string NPC;

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
            currentMessage = messageList[currentMessage].Branches["Next"];
            if (currentMessage != -1)
            {
                return messageList[currentMessage];
            }
            else
            {
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
}
