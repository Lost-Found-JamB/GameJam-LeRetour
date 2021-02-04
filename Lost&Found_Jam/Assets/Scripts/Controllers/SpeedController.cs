using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 300f;
    [SerializeField] private float _speedUp = 300f;
    [SerializeField] private float _timer = 10f;

    private Timer _clock = null;

    private void Awake()
    {
        _clock = new Timer();
        _clock.OnTick += GameTime;
        _clock.StartTimer(0f);
    }

    private void GameTime()
    {
        _clock.StartTimer(_timer);
        SetMoveSpeed(_speedUp);
    }

    public float GetMoveSpeed()
    {
        return _moveSpeed;
    }

    public void SetMoveSpeed(float value)
    {       
        _moveSpeed += value;
        //Debug.Log("VROOOOOOOM : " + _moveSpeed);
    }
}
