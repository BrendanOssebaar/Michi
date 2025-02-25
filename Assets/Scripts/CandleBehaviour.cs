using System.Security.Principal;
using UnityEngine;
using UnityEngine.InputSystem;

public class CandleBehaviour : MonoBehaviour
{

    [SerializeField] public float _maxCandleDuration;
    private float _currentCandleDuration;
    private int _currentCandleState = 0;
    private Light _candleLight;
    [SerializeField] private InputAction _playerInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentCandleDuration = (_maxCandleDuration * 60);
        _candleLight = gameObject.GetComponent<Light>();
    }

    void OnEnable()
    {
        _playerInput.Enable();
    }

    void OnDisable()
    {
        _playerInput.Disable();
    }

    // Countdown for the candle
    void FixedUpdate()
    {
        if (_playerInput.ReadValue<float>() == 1.0f)
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
        _currentCandleDuration = (_maxCandleDuration * 60);
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
