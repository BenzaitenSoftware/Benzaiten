using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{
    [SerializeField]
    private PlayerSelector playera, playerb;
    private SpriteRenderer image;
    private float change = 0.025f;

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

    private void FixedUpdate()
    {
        if (selected)
        {
            Color temp = image.color;
            temp.a += change;
            image.color = temp;

            if (temp.a >= 1) change = -0.025f;
            if (temp.a <= 0) change = 0.025f;
        }
        else
        {
            Color temp = image.color;
            temp.a = 0;
            image.color = temp;
        }
    }

}
