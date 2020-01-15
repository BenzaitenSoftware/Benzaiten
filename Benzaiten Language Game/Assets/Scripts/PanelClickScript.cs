using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelClickScript : MonoBehaviour, IPointerClickHandler
{
    public int tableNumber;
    public bool glow;
    private CafeController cafe;
    private Image image;

    private float change = 0.02f;

    void Start()
    {
        cafe = GameObject.FindGameObjectWithTag("Cafe").GetComponent<CafeController>();
        image = gameObject.GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData pointerEvent)
    {
        if (!GameObject.Find("Phone").GetComponent<PhoneManager>().Show)cafe.TableClick(tableNumber);
    }

    public void FixedUpdate()
    {
        if (glow)
        {
            Color color = image.color;
            color.a += change;

            image.color = color;

            if (image.color.a <= 0) change = 0.02f;
            if (image.color.a >= 1) change = -0.02f;
        }
        else
        {
            image.color = new Color(1, 1, 1, 0);
        }
    }

}
