using System.Collections;
using System;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class TipsManager : MonoBehaviour
{
    public static Action<string> displayTipEvent;   //дилигат, отвечающий за появление окна
    public static Action disabeTipEvent;            // диллигат, отвечающий за исчезание окна

    [SerializeField] private TMP_Text messageText;  //текст в сплывающем окне

    private Animator anim; //переменная, которая нужна для появления и исчезания всплывающего окна

    private int activeTips; //колличество всплывающих подсказок

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        displayTipEvent += displayTip;
        disabeTipEvent += disableTip;
    }

    private void OnDisable()
    {
        displayTipEvent -= displayTip;
        disabeTipEvent -= disableTip;
    }

    private void displayTip(string message)
    {
        messageText.text = message;
        anim.SetInteger("state", ++activeTips);
    }

    private void disableTip()
    {
        anim.SetInteger("state", --activeTips);
    }
}
