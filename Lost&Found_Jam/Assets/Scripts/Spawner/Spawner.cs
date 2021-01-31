using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private ObjectMovement[] _gameObjectsToSpawn = null;
    [SerializeField] private float _spawnRateMin = 1f;
    [SerializeField] private float _spawnRateMax = 1f;
    [SerializeField] private Transform _objectContainer = null;
    [SerializeField] private ObjectController _objectController = null;
    [Header("Sprites")]
    [SerializeField] private Sprite[] _objectsRed = null;
    [SerializeField] private Sprite[] _objectsYellow = null;
    [SerializeField] private Sprite[] _objectsGreen = null;
    [SerializeField] private Sprite[] _objectsBlue = null;

    private float _spawnRate = 0f;
    private float _timeStamp = 0f;
    private int _objectType = 0;

    /*[Header("Bonus")]
    [SerializeField] private ObjectMovement[] _bonusToSpawn = null;
    [SerializeField] private float _bonusSpawnRateMin = 1f;
    [SerializeField] private float _bonusSpawnRateMax = 1f;
    [Header("Malus")]
    [SerializeField] private ObjectMovement[] _malusToSpawn = null;
    [SerializeField] private float _malusSpawnRateMin = 1f;
    [SerializeField] private float _malusSpawnRateMax = 1f;

    
    private float _spawnRateBonus = 0f;
    private float _spawnRateMalus = 0f;
 
    private float _timeStampBonus = 0f;
    private float _timeStampMalus = 0f;

    private int _bonusType = 0;
    private int _malusType = 0;*/

    public void SpawnRateMax(float spawnRMax)
    {
        _spawnRateMax = spawnRMax;
    }

    public float GetSpawnRateMax()
    {
        return _spawnRateMax;
    }

    // Start is called before the first frame update
    void Start()
    {
        RandomGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        _timeStamp += Time.deltaTime;
        /*_timeStampBonus += Time.deltaTime;
        _timeStampMalus += Time.deltaTime;*/

        if(_timeStamp >= _spawnRate)
        {
            Spawn();
        }

        /*if (_timeStampBonus >= _spawnRateBonus)
        {
            SpawnBonus();
        }

        if (_timeStampMalus >= _spawnRateMalus)
        {
            SpawnMalus();
        }*/
    }

    private void RandomGenerator()
    {
        _spawnRate = Random.Range(_spawnRateMin, _spawnRateMax);
        /*_spawnRateBonus = Random.Range(_bonusSpawnRateMin, _bonusSpawnRateMax);
        _spawnRateMalus = Random.Range(_malusSpawnRateMin, _malusSpawnRateMax);*/

        _objectType = Random.Range(0, 4);
        /*_bonusType = Random.Range(0, 2);
        _malusType = Random.Range(0, 1);*/
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

    /*private void SpawnBonus()
    {
        ObjectMovement BonusClone = Instantiate(_bonusToSpawn[_bonusType], transform.position, transform.rotation, _objectContainer);
        _objectController.AddItem(BonusClone.GetComponent<ItemProperties>());
        BonusClone.Init(_objectController);

        string itemName = BonusClone.GetComponent<ItemProperties>().name;

        _timeStampBonus = 0;
        _spawnRateBonus = Random.Range(_bonusSpawnRateMin, _bonusSpawnRateMax);
        _bonusType = Random.Range(0, 2);
    }

    private void SpawnMalus()
    {
        ObjectMovement MalusClone = Instantiate(_malusToSpawn[_malusType], transform.position, transform.rotation, _objectContainer);
        _objectController.AddItem(MalusClone.GetComponent<ItemProperties>());
        MalusClone.Init(_objectController);

        string itemName = MalusClone.GetComponent<ItemProperties>().name;

        _timeStampMalus = 0;
        _spawnRateMalus = Random.Range(_malusSpawnRateMin, _malusSpawnRateMax);
        _malusType = Random.Range(0, 1);
    }*/
}
