using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConversationHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI playerBubble, npcBubble;
    [SerializeField]
    private Text[] buttonList;
    [SerializeField]
    private Animator playerAnim, npcAnim;

    private string playerName;

    private Conversation currentConversation;
    private Message currentMessage;
    private string currentText, fileName;

    private float lastTime, delay;
    private int textIndex;
    private bool typing;

    // TESTING OBJECT
    public GameObject endPanel;

    // Start is called before the first frame update
    void Start()
    {
        lastTime = Time.time;
        delay = 0.02f;

        try
        {
            DataHolder dataHolder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
            fileName = dataHolder.fileName;
            playerName = dataHolder.PlayerName;
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
            endPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Please start game from main menu only!";
            endPanel.SetActive(true);
        }

        //fileName = "test.json";

        currentConversation = JsonConvert.DeserializeObject<Conversation>(File.ReadAllText("Assets/Conversations/" + fileName));

        File.WriteAllText("Assets/Conversations/" + fileName,JsonConvert.SerializeObject(currentConversation, Formatting.Indented));

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
            endPanel.SetActive(true);
        }
    }

    private void NextMessage()
    {
        currentMessage = currentConversation.NextMessage();

        LoadMessage();
    }

    public void NextMessage(string text)
    {
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
                if (active) buttonList[i].text = buttonText[i];
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
