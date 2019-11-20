using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestClickScript : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData pointerEvent)
    {
        Debug.Log(name + " Game Object Clicked!");
    }
   
}
