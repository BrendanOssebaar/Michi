using System.Security.Principal;
using UnityEngine;

public class CandleBehaviour : MonoBehaviour
{

    [SerializeField] public float _maxCandleDuration;
    private float _currentCandleDuration;
    private int _currentCandleState = 0;
    private Light _candleLight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentCandleDuration = (_maxCandleDuration * 60);
        _candleLight = gameObject.GetComponent<Light>();
    }

    // Countdown for the candle
    void FixedUpdate()
    {
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
