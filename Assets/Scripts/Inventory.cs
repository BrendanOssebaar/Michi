using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Inventory : MonoBehaviour
{

    [SerializeField] private GameObject menu;
    [SerializeField] private InputAction playerInput;
    public bool hasPlush;
    public int candles;
    public int matches;
    [SerializeField] private GameObject plushSlot;
    [SerializeField] private GameObject candleSlot;
    [SerializeField] private GameObject matchSlot;
    [SerializeField] private TextMeshProUGUI candleText;
    [SerializeField] private TextMeshProUGUI matchText;
    private int _maxCandles = 3;
    private int _maxMatches = 6;
    private GameObject _player;
    private int _timer;

    public enum itemType
    {
        Plushie = 0,
        Candle = 1,
        Match = 2
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
                plushSlot.SetActive(hasPlush);
                if(candles > 0)
                {
                    candleSlot.SetActive(true);
                }
                else
                {
                    candleSlot.SetActive(false);
                }
                if(matches > 0)
                {
                    matchSlot.SetActive(true);
                }
                else
                {
                    matchSlot.SetActive(false);
                }
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
                candleText.text = candles.ToString();
            }
        }
        if (item == itemType.Match)
        {
            if (matches < _maxMatches)
            {
                matches++;
                matchText.text = matches.ToString();
            }
        }      
    }
}
