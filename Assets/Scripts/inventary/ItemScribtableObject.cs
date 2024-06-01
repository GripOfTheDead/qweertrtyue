using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {Key , Cure , ItemUrna}
public class ItemScribtableObject : ScriptableObject
{
    public ItemType ItemType;
    public string name;
    public int maxAmountStack;
    public Sprite icon;
    public bool isConsumeable;// можно употреблять или действия с предметом
    public bool isOpened;
    public bool isPutDown;
    public GameObject mainDoor;
    public GameObject zamorZabor;
    public GameObject Urna;
    public GameObject caseS;
    public GameObject Knife;
    public GameObject KeyCar;
    public GameObject BankKeyCar;



    [Header("Treatment")]
    public float changedHealth;
}
