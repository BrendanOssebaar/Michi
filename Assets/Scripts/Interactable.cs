using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject menu;
    private GameObject _player;

    void Start()
    {
        _player = GameObject.Find("Player");
    }

    public void OpenMenu()
    {
        _player.GetComponent<MenuManager>().currentMenu = menu;
        menu.SetActive(true);
        menu.transform.GetChild(UnityEngine.Random.Range(0, 3)).gameObject.SetActive(true);
    }

}
