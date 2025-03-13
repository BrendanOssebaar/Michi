using System;
using UnityEngine;

public class DisableFirstRoom : MonoBehaviour
{
        private float _timeUntilDisable = 30f;
        private void Update()
        {
                
                if (_timeUntilDisable <= 0)
                {
                        gameObject.SetActive(false);
                }
        }
}