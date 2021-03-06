﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CloseButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler {

    public Sprite[] closeButtons;

    //0 == Normal
    //1 == Hilighted
    //2 == Pressed

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Change sprite to hilighted
        GetComponent<Image>().sprite = closeButtons[1];
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Change sprite to normal
        GetComponent<Image>().sprite = closeButtons[0];
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Change sprite to pressed
        GetComponent<Image>().sprite = closeButtons[2];
    }
}
