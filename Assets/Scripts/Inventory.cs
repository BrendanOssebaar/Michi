using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{

    [SerializeField] private GameObject menu;
    [SerializeField] private InputAction playerInput;
    public bool hasPlush;
    public int matches;
    public int candles;
    private int _maxCandles = 3;
    private int _maxMatches = 6;
    private GameObject _player;
    private int _timer;

    public enum itemType
    {
        Plushie,
        Candle,
        Match
    }

    void Start()
    {
        _player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        if (playerInput.ReadValue<float>() == 1 && _player.GetComponent<MenuManager>().canPress)
        {
            if(_player.GetComponent<MenuManager>().isShowing == false)
            {
                _player.GetComponent<MenuManager>().OpenMenu(menu);
            } 
            else
            {
                _player.GetComponent<MenuManager>().CloseMenu(menu);
            }
        }
    }        

    void OnEnable()
    {
        playerInput.Enable();
    }

    void OnDisable()
    {
        playerInput.Disable();
    }

    public void AddToInventory(Inventory.itemType item)
    {
        if(item == itemType.Plushie)
        {
            if (!hasPlush)
            {
                hasPlush = true;
            }
        }
        if (item == itemType.Candle) 
        {
            if (candles < _maxCandles)
            {
                candles++;
            }
        }
        if (item == itemType.Match)
        {
            if (matches < _maxMatches)
            {
                matches++;
            }
        }      
    }
}
