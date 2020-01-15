using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

#pragma warning disable 0649

public class ConversationHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI playerBubble, npcBubble;
    [SerializeField]
    private Text[] buttonList;
    private Animator playerAnim, npcAnim;
    [SerializeField]
    private GameObject guide, kaoru, baristabird, player1, player2, player3, playerHolder, npcHolder, exitButton;

    private string playerName;

    private Conversation currentConversation;
    private Message currentMessage;
    private string currentText, fileName;
    private Random random;

    private float lastTime, delay;
    private int textIndex;
    private bool typing;

    private DataHolder dataHolder;

    // TESTING OBJECT
    public GameObject endPanel;

    void Start()
    {
        random = new Random();
        lastTime = Time.time;
        delay = 0.02f;

        try
        {
            dataHolder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
            fileName = dataHolder.fileName;
            playerName = dataHolder.player.PlayerName;
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
            endPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Please start game from main menu only!";
            endPanel.SetActive(true);
        }

        string jsonString = Resources.Load<TextAsset>("Conversations/" + fileName.Replace(".json", "")).ToString();
        currentConversation = JsonConvert.DeserializeObject<Conversation>(jsonString);

        LoadCharacters();
        NextMessage();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!typing && !currentMessage.Branching)
            {
                NextMessage();
            }
            else
            {
                if (currentMessage.Player)
                {
                    playerBubble.text = currentText;
                }
                else
                {
                    npcBubble.text = currentText;
                }

                typing = false;
            }
        }
        
        if (textIndex < currentText.Length && typing)
        {
            if ((Time.time - lastTime) > delay)
            {
                if (currentMessage.Player)
                {
                    playerBubble.text += currentText[textIndex];
                }
                else
                {
                    npcBubble.text += currentText[textIndex];
                }

                textIndex++;
                lastTime = Time.time;
            }
        }
        else
        {
            typing = false;
        }

        if (currentMessage == null)
        {
            dataHolder.SaveProgress();
            dataHolder.GetComponent<DataHolder>().Play();
        }
    }

    private void LoadCharacters()
    {
        GameObject npcPrefab, playerPrefab;

        switch (currentConversation.NPC)
        {
            case "Kaoru":
                npcPrefab = kaoru;
                exitButton.SetActive(true);
                break;
            case "Guide":
                npcPrefab = guide;
                exitButton.SetActive(false);
                break;
            case "BaristaBird":
                npcPrefab = baristabird;
                exitButton.SetActive(true);
                break;
            default:
                npcPrefab = guide;
                exitButton.SetActive(false);
                Debug.LogError("CURRENT NPC NOT KNOWN");
                break;
        }

        switch (dataHolder.player.PlayerSprite)
        {
            case 1:
                playerPrefab = player1;
                break;
            case 2:
                playerPrefab = player2;
                break;
            case 3:
                playerPrefab = player3;
                break;
            default:
                playerPrefab = player3;
                break;

        }

        GameObject NPC = Instantiate(npcPrefab, npcHolder.transform);
        GameObject Player = Instantiate (playerPrefab, playerHolder.transform);
        npcAnim = NPC.GetComponent<Animator>();
        playerAnim = playerHolder.GetComponent<Animator>();
    }

    private void NextMessage()
    {
        currentMessage = currentConversation.NextMessage();

        LoadMessage();
    }

    public void NextMessage(string text)
    {
        text = text.Replace(dataHolder.player.PlayerName, "~~");

        currentMessage = currentConversation.NextMessage(currentMessage.Branches[text]);

        LoadMessage();
    }

    private void LoadMessage()
    {
        currentText = currentMessage.Text;
        currentText = currentText.Replace("~~", playerName);
        textIndex = 0;
        typing = true;

        bool player = currentMessage.Player;
        playerBubble.transform.parent.gameObject.SetActive(player);
        npcBubble.transform.parent.gameObject.SetActive(!player);

        playerBubble.text = "";
        npcBubble.text = "";

        playerAnim.SetInteger("MessageState", currentMessage.PlayerAnimState);
        npcAnim.SetInteger("MessageState", currentMessage.NpcAnimState);

        if (currentMessage.Branching)
        {
            Dictionary<string, int> branches = currentMessage.Branches;
            List<string> buttonText = new List<string>(branches.Keys);
            int numOfButtons = branches.Count;

            for (int i = 0; i < buttonList.Length; i++)
            {
                bool active = i <= (numOfButtons - 1);

                buttonList[i].transform.parent.gameObject.SetActive(active);

                if (active)
                {
                    int textIndex = random.Next(0, buttonText.Count - 1);

                    buttonList[i].text = buttonText[textIndex].Replace("~~", dataHolder.player.PlayerName);

                    buttonText.RemoveAt(textIndex);
                }
            }
        }
        else
        {
            for (int i = 0; i < buttonList.Length; i++)
            {
                buttonList[i].transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
