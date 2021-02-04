using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMalusController : MonoBehaviour
{

    #region Field
    [SerializeField] private SpeedController _speedController = null;
    [SerializeField] private DestroyZoneController _destroyZoneController = null;
    [SerializeField] private ObjectController _objecController = null;
    [SerializeField] private Spawner _spawner = null;

    [SerializeField] private float _speedModifier = 25f;
    [SerializeField] private float _spawnRateMax = 1.5f;

    private float _savedSpawnRate = 3f;
    private bool _toggle = false;
    private bool _trigger = false;
    #endregion Field

    #region Properties
    #endregion Properties

    #region Methods
    private void Awake()
    {
        _savedSpawnRate = _spawner.GetSpawnRateMax();
    }

    private void OnTriggerStay(Collider other)
    {
        if (ClearTrigger(_trigger) == true)
        {
            ClearCBelt(other);
            _trigger = false;
        }
    }

    #region Bonus
    //Bonus :

    //-Ralentir le tapis
    public void SlowDown()
    {
        _speedController.SetMoveSpeed(-_speedModifier);
    }

    //-Clear le tapis
    private void ClearCBelt(Collider other)
    {
        _objecController.RemoveItem(other.GetComponent<ItemProperties>());
        Destroy(other.gameObject);
    }
    public bool ClearTrigger(bool trigger)
    {
        _trigger = trigger;
        return _trigger;
    }

    //-Les objets deviennent neutre (peuvent être rangé où le joueur décide)
    /*public bool AllNeutral(bool trigger)
    {
        IN OBJECT CONTROLLER
    }*/

    #endregion Bonus

    #region Malus
    //Malus :

    //-Accélérer le tapis
    public void SpeedUp()
    {
        _speedController.SetMoveSpeed(_speedModifier);
    }

    //-Augmente la fréquence d’apparition
    public void MoreItem(bool toggle)
    {
        _toggle = toggle;
        if (_toggle)
        {
            _spawner.SpawnRateMax(_spawnRateMax);
        }
        else
        {
            _spawner.SpawnRateMax(_savedSpawnRate);

        }
    }

    #endregion Malus
    #endregion Methods
}
