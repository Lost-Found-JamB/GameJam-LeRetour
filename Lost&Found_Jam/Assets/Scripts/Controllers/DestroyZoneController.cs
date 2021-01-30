using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZoneController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Debug.Log(other.name + " est tombé dans la trappe !! ERROR !!");
    }
}
