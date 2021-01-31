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
    [SerializeField] private Sprite[] _objectsRed = null;
    [SerializeField] private Sprite[] _objectsYellow = null;
    [SerializeField] private Sprite[] _objectsGreen = null;
    [SerializeField] private Sprite[] _objectsBlue = null;

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
        int rand = Random.Range(0, 14);

        ObjectMovement ObjectClone = Instantiate(_gameObjectsToSpawn[_objectType], transform.position, transform.rotation, _objectContainer);
        _objectController.AddItem(ObjectClone.GetComponent<ItemProperties>());
        ObjectClone.Init(_objectController);

        string color = ObjectClone.GetComponent<ItemProperties>().GetObjColor();

        if (color == "RED")
        {
            ObjectClone.GetComponent<SpriteRenderer>().sprite = _objectsRed[rand];
        }

        if (color == "BLUE")
        {
            ObjectClone.GetComponent<SpriteRenderer>().sprite = _objectsBlue[rand];
        }

        if (color == "GREEN")
        {
            ObjectClone.GetComponent<SpriteRenderer>().sprite = _objectsGreen[rand];
        }

        if (color == "YELLOW")
        {
            ObjectClone.GetComponent<SpriteRenderer>().sprite = _objectsYellow[rand];
        }

        _timeStamp = 0;
        _spawnRate = Random.Range(_spawnRateMin, _spawnRateMax);
        _objectType = Random.Range(0, 4);
    }
}
