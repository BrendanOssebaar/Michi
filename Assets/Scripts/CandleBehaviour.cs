using System.Security.Principal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class CandleBehaviour : MonoBehaviour
{

    [SerializeField] public float maxCandleDuration;
    private float _currentCandleDuration;
    private int _currentCandleState = 0;
    private Light _candleLight;
    [SerializeField] private InputAction playerInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentCandleDuration = (maxCandleDuration * 60);
        _candleLight = gameObject.GetComponent<Light>();
    }

    void OnEnable()
    {
        playerInput.Enable();
    }

    void OnDisable()
    {
        playerInput.Disable();
    }

    // Countdown for the candle
    void FixedUpdate()
    {
        if (playerInput.ReadValue<float>() == 1.0f)
        {
            if (_currentCandleState == 3)
            {
                LightCandle();
            }
        }
        if ( _currentCandleDuration > 0)
        {
            _currentCandleDuration--;
        }
        else
        {
            _currentCandleState++;
            ChangeCandleState(_currentCandleState);
        }
    }

    void LightCandle()
    {
        //lucifers--;
        _currentCandleState = 0;
        gameObject.SetActive(true);
        ChangeCandleState(_currentCandleState);
    }

    void ChangeCandleState(int state)
    {
        _currentCandleDuration = (maxCandleDuration * 60);
        if (state == 0) {
            //change candle sprite
            _candleLight.intensity = 6;
        }
        if (state == 1)
        {
            //change candle sprite
            _candleLight.intensity = 4;
        }
        if (state == 2)
        {
            //change candle sprite
            _candleLight.intensity = 2;
        }
        if (state == 3)
        {
            //change candle sprite
            _candleLight.intensity = 0;
        }
    }
}
