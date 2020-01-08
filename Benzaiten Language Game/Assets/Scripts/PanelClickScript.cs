using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelClickScript : MonoBehaviour, IPointerClickHandler
{
    public int tableNumber;
    private CafeController cafe;

    void Start()
    {
        cafe = GameObject.FindGameObjectWithTag("Cafe").GetComponent<CafeController>();
    }

    public void OnPointerClick(PointerEventData pointerEvent)
    {
        Debug.Log(tableNumber);
        cafe.TableClick(tableNumber);
    }
   
}
