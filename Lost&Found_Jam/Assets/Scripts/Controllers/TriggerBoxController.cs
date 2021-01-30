using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxController : MonoBehaviour
{
    private ObjectMovement _object = null;

    private void OnTriggerEnter(Collider other)
    {
        _object = other.GetComponent<ObjectMovement>();
    }

    private void Update()
    {
        if(_object != null)
        {
            _object.IsOutToggle();
        }
    }
}
