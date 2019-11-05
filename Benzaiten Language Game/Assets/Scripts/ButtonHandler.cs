using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    private Text text;
    private ConversationHandler conversationHandler;

    private void Start()
    {
        text = GetComponent<Text>();
        conversationHandler = transform.parent.GetComponentInParent<ConversationHandler>();
    }

    public void OnClick()
    {
        conversationHandler.NextMessage(text.text);
    }
}
