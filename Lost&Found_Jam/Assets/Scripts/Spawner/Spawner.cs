using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectMovement[] _gameObjectsToSpawn = null;
    [SerializeField] private float _spawnRateMin = 1f;
    [SerializeField] private float _spawnRateMax = 1f;
    [SerializeField] private Transform _objectContainer = null;
    [SerializeField] private ObjectController _objectController = null;

    private float _spawnRate = 0f;
    private int _objectType = 0;
    private float _timeStamp = 0f;

    // Start is called before the first frame update
    void Start()
    {
        RandomGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        _timeStamp += Time.deltaTime;
        if(_timeStamp >= _spawnRate)
        {
            Spawn();
        }
    }

    private void RandomGenerator()
    {
        _spawnRate = Random.Range(_spawnRateMin, _spawnRateMax);
        _objectType = Random.Range(0, 4);
    }

    private void Spawn()
    {
        ObjectMovement ObjectClone = Instantiate(_gameObjectsToSpawn[_objectType], transform.position, transform.rotation, _objectContainer);
        _objectController.AddItem(ObjectClone.GetComponent<ItemProperties>());
        ObjectClone.Init(_objectController);
        _timeStamp = 0;
        _spawnRate = Random.Range(_spawnRateMin, _spawnRateMax);
        _objectType = Random.Range(0, 4);
    }
}
