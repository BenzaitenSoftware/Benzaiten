using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationHandler : MonoBehaviour
{
    [SerializeField]
    private Text bubble1, bubble2;
    private string[] conversation;

    // Start is called before the first frame update
    void Start()
    {
        conversation = new string[5] { "Hello", "Hi!", "How are you?", "I am good! How are you", "I am ok , thank you!"};
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            for (int i = 0; i < conversation.Length; i++)
            {
                string text = conversation[i];

                if (i % 2 == 0)
                {
                    for (int j = 0; j < text.Length; i++)
                    {
                        bubble1.text += text[j];
                    }
                }
            }
        }
    }
}
