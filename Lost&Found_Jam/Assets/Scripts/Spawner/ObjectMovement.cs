using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private float _moveSpeed = 0f;
    [SerializeField] private float _downSpeed = 100f;

    private Rigidbody _rb = null;
    private bool _isOut = false;
    private ObjectController _obectController = null;
    private float _speedUp = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            _rb = GetComponent<Rigidbody>();
            _moveSpeed = FindObjectOfType<SpeedController>().GetMoveSpeed();
        }
        else
        {

        }
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

        if(_obectController.IsDone)
        {
            Destroy(gameObject);
            _obectController.IsDone = false;
        }
    }

    public void Init(ObjectController objectController)
    {
        _obectController = objectController;
    }
}
