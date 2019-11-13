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

        //try
        //{
        //    fileName = GameObject.Find("DataHolder").GetComponent<DataHolder>().fileName;
        //}
        //catch (Exception e)
        //{
        //    endPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Please start game from main menu only!";
        //    endPanel.SetActive(true);
        //}

        fileName = "test.json";

        currentConversation = JsonConvert.DeserializeObject<Conversation>(File.ReadAllText("Assets/Conversations/" + fileName));

        //Message[] messageList = new Message[13];

        //messageList[0] = new Message("Konnichiwa ~~! Its been a long time, I'm glad you've arrived safely. Nihon he youkoso! That means welcome to Japan. How are you feeling?", false);
        //messageList[1] = new Message("I'm feeling excited!", true);
        //messageList[2] = new Message("I bet! Lets go catch up. My favourite cafe isn't far from here.", false);
        //messageList[3] = new Message("It's  gonna be real fun for you to make friends with loadsa new people. It'll take time to learn the language, but making those new connections is really worth it, you know?", false);
        //messageList[4] = new Message("How about I teach you a little bit of Japanese right now so you can make a go at saying hello and introducing yourself to the folks in the cafe ? ", false);
        //messageList[5] = new Message("Yes please!", true);
        //messageList[6] = new Message("Ok! The way to say hello, how are you: 'Konnichiwa, genki desu ka?'", false);
        //messageList[7] = new Message("So, how do I respond?", true);
        //messageList[8] = new Message("So if someone asks you 'Genki desu ka ? ' you say: 'Hai, genki desu'", false);
        //messageList[9] = new Message("Oh, we're nearly at the cafe now! If you want to know anymore phrases just come and ask!", false);
        //messageList[10] = new Message("I will do!", true);
        //messageList[11] = new Message("Okay! If you can't remember any phrases check the phrasebook in your phone or come ask me.", true);
        //messageList[12] = new Message("We're here! I hope you like it as much as I do. I come every day, so you should join me.",  true);

        //messageList[0].AddOption("I'm feeling excited!", 1);

        //messageList[4].AddOption("Yes please!", 5);
        //messageList[4].AddOption("Nah, I'm good thanks", 11);

        //messageList[6].AddOption("Could you repeat that for me?", 6);
        //messageList[6].AddOption("So, how do I respond?", 7);
        //messageList[6].AddOption("Thanks, that's enough for today.", 11);

        //messageList[9].AddOption("I will do!", 11);

        //currentConversation = new Conversation(messageList);

        File.WriteAllText("Assets/Conversations/test.json",JsonConvert.SerializeObject(currentConversation, Formatting.Indented));

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
