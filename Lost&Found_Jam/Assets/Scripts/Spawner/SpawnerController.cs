using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private Transform _maxForward = null;
    [SerializeField] private Transform _maxBack = null;

    private float _t = 0f;
    private bool _moveForward = true;

    private void Start()
    {
        
    }

    private void Update()
    {
        _t += _moveSpeed * Time.deltaTime;
        if (_moveForward)
        {
            transform.position = Vector3.Lerp(_maxForward.position, _maxBack.position, _t);
        }
        else
        {
            transform.position = Vector3.Lerp(_maxBack.position, _maxForward.position, _t);
        }

        if (_t >= 1)
        {
            _t = 0;
            _moveForward = !_moveForward;
        }
    }

}
