using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZoneController : MonoBehaviour
{
    [SerializeField] private ObjectController _objecController = null;
    [SerializeField] private GameOverController _gameOverController = null;

    private void OnTriggerEnter(Collider other)
    {
        _objecController.RemoveItem(other.GetComponent<ItemProperties>());
        _gameOverController.AddError();
        Destroy(other.gameObject);
        Debug.Log(other.name + " est tombé dans la trappe !! ERROR !!");
    }
}
