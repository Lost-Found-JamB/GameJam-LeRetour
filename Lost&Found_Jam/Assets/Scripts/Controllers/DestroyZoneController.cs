using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZoneController : MonoBehaviour
{
    [SerializeField] private ObjectController _objecController = null;

    private void OnTriggerEnter(Collider other)
    {
        _objecController.RemoveItem(other.GetComponent<ItemProperties>());
        Destroy(other.gameObject);
        Debug.Log(other.name + " est tombé dans la trappe !! ERROR !!");
    }
}
