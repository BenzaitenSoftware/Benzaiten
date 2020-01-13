using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{
    [SerializeField]
    private PlayerSelector playera, playerb;
    private SpriteRenderer image;

    public bool selected;

    private void Start()
    {
        image = GetComponent<SpriteRenderer>();
        selected = false;
    }

    private void OnMouseDown()
    {
        selected = true;
        playera.selected = false;
        playerb.selected = false;
    }

    private void Update()
    {
        if (selected)
        {
            Color temp = image.color;
            temp.a = 1;
            image.color = temp;
        }
        else
        {
            Color temp = image.color;
            temp.a = 0;
            image.color = temp;
        }
    }

}
