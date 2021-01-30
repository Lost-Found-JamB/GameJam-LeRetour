using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 300f;
    [SerializeField] private float _downSpeed = 100f;

    private Rigidbody _rb = null;
    private bool _isOut = false;

    public Rigidbody Rb
    {
        get => _rb;
        set => _rb = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void IsOutToggle()
    {
        _isOut = !_isOut;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isOut)
        {
            _rb.velocity = Vector3.zero;
            transform.position += Vector3.down * _downSpeed * Time.deltaTime;
        }
        else if(!_isOut)
        {
            _rb.velocity = Vector3.right * _moveSpeed * Time.deltaTime;
        }
    }
}
