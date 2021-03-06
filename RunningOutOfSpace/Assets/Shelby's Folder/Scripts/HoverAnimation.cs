﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HoverAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Animator anim;
    string sceneToLoad;

    void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetBool(gameObject.name, true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetBool(gameObject.name, false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene(string scene)
    {
        sceneToLoad = scene;
        Invoke("Fade", 0.25f);
        GameObject.Find("FadeController").GetComponent<Animator>().SetTrigger("fade");
    }
    public void Fade()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
