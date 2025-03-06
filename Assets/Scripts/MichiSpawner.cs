using System;
using UnityEngine;

public class MichiSpawner : MonoBehaviour
{
    [SerializeField] private GameObject michi;
    [SerializeField] private GameObject michiSpawnPoint;
    [SerializeField] private float timeMichiStays;
    private Transform _michiWaitSpot;
    public RoomSpawner roomSpawner;
    private float _startTimeMichiStays;
    private bool _michiMoved;

    private void Awake()
    {
        _michiWaitSpot = michi.transform;
        _startTimeMichiStays = timeMichiStays;
    }
    

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        SpawnMichi();
        
    }

    void SpawnMichi()
    {
        if (timeMichiStays >= 0)
        {
            if (roomSpawner.roomIsTransitioned && _michiMoved == false)
            {
                michi.transform.position = roomSpawner.currentRoom.transform.position;
                _michiMoved = true;
            }

            timeMichiStays--;
        }
        else
        {
            timeMichiStays = _startTimeMichiStays;
            michi.transform.position = _michiWaitSpot.transform.position;
            _michiMoved = false;
        }
        
    }
}
