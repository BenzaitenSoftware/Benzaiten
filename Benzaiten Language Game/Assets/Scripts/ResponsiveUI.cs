using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponsiveUI : MonoBehaviour
{
    public RectTransform[] buttonList;
    public RectTransform player, npc;

    private int buttonCount;
    private float buttonSpacing;
    private float buttonPercentage, characterPercentage;
    private float height, width;

    // Start is called before the first frame update
    void Start()
    {
        buttonCount = buttonList.Length;

        buttonSpacing = 50f;

        buttonPercentage = 0.4f;
        characterPercentage = 1 - buttonPercentage;

        height = Screen.height;
        width = Screen.width;

        ResizeButtons();
        ResizeCharacters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ResizeButtons()
    {
        float buttonSpace = height * buttonPercentage;
        float buttonHeight = (buttonSpace - (buttonSpacing * (buttonCount + 1))) / buttonCount;

        for (int i = buttonCount - 1; i >= 0; i--)
        {
            float y = (buttonSpacing * (i + 1)) + (buttonHeight * (i)) + (buttonHeight * 0.5f);

            RectTransform button = buttonList[i];
            button.anchoredPosition = new Vector3(0, y, 0);
            button.sizeDelta = new Vector2(width * 0.9f, buttonHeight);
        }
    }

    private void ResizeCharacters()
    {
        float characterSpace = height * characterPercentage;

        Vector2 size = new Vector2(width * 0.25f, characterSpace * 0.6f);
    }
}
