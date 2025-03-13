using System;
using System.Diagnostics;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject menu;
    private GameObject _player;
    private int _randomNumber;

    void Start()
    {
        _player = GameObject.Find("Player");
    }

    public void OpenMenu()
    {
        menu.transform.GetChild(_randomNumber).gameObject.SetActive(false);
        if(_player.GetComponent<Inventory>().hasPlush)
        {
            _randomNumber = UnityEngine.Random.Range(1, 3);
        }
        else
        {
            _randomNumber = UnityEngine.Random.Range(0, 3);
        }
        _player.GetComponent<MenuManager>().OpenMenu(menu);
        menu.transform.GetChild(_randomNumber).gameObject.SetActive(true);
        _player.GetComponent<Inventory>().AddToInventory((Inventory.itemType)_randomNumber);
    }
}
