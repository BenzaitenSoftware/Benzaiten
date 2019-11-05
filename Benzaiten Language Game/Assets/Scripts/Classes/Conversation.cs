using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Conversation
{
    [JsonProperty]
    private Message[] messageList;
    private string NPC;

    private int currentMessage = -1;

    public Conversation(Message[] messageList)
    {
        this.messageList = messageList;
    }

    public Message NextMessage()
    {
        currentMessage++;
        if (currentMessage < messageList.Length)
        {
            return messageList[currentMessage];
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
