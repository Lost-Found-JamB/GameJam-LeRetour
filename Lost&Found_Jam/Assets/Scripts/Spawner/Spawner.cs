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
    [SerializeField] private Sprite[] _objectsNeutral = null;

    private float _spawnRate = 0f;
    private float _timeStamp = 0f;
    private float _timer = 5f;
    private int _objectType = 0;
    private bool _canBeBonusMalus = false;
    private bool _isNeutral = false;

    [Header("Bonus")]
    [SerializeField] private ObjectMovement[] _bonusToSpawn = null;
    [SerializeField] private float _bonusSpawnRateMin = 1f;
    [SerializeField] private float _bonusSpawnRateMax = 1f;
    [SerializeField] private GameObject[] _bonusAnimation = null;
    /*[SerializeField] private GameObject _bonusAnimation1 = null;
    [SerializeField] private GameObject _bonusAnimation2 = null;
    [SerializeField] private GameObject _bonusAnimation3 = null;
    [SerializeField] private GameObject _bonusAnimation4 = null;
    [SerializeField] private GameObject _bonusAnimation5 = null;
    [SerializeField] private GameObject _bonusAnimation6 = null;*/
    [Header("Malus")]
    [SerializeField] private ObjectMovement[] _malusToSpawn = null;
    [SerializeField] private float _malusSpawnRateMin = 1f;
    [SerializeField] private float _malusSpawnRateMax = 1f;
    [SerializeField] private GameObject _malusAnimation = null;

    private float _malusTimer = 2.3f;
    private float _bonusTimer = 5f;

    private float _spawnRateBonus = 0f;
    private float _spawnRateMalus = 0f;

    private float _timeStampBonus = 0f;
    private float _timeStampMalus = 0f;

    private int _bonusType = 0;
    private int _malusType = 0;

    public void SpawnRateMax(float spawnRMax)
    {
        _spawnRateMax = spawnRMax;
    }

    public float GetSpawnRateMax()
    {
        return _spawnRateMax;
    }

    public void IsNeutral(bool neutral)
    {
        _isNeutral = neutral;
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

        if (_timeStamp >= _spawnRate)
        {
            Spawn();
        }
    }

    private void RandomGenerator()
    {
        _spawnRate = Random.Range(_spawnRateMin, _spawnRateMax);

        _bonusType = Random.Range(0, 3);
        _malusType = Random.Range(0, 2);
    }

    private void Spawn()
    {
        int rand = Random.Range(0, 14);
        if (_isNeutral)
        {
            _objectType = 5;
        }
        else
        _objectType = Random.Range(0, 5);

        if (_objectType == 4)
        {
            if (_canBeBonusMalus)
            {
                int _randomType = Random.Range(0, 2);
                if (_randomType == 0)
                {
                    SpawnBonus();
                    return;
                }
                else
                {
                    SpawnMalus();
                    return;
                }
            }
            else
            {
                _canBeBonusMalus = true;
                Spawn();
                return;
            }
        }
        else
        {
            
            ObjectMovement ObjectClone = Instantiate(_gameObjectsToSpawn[_objectType], transform.position, transform.rotation, _objectContainer);
            _objectController.AddItem(ObjectClone.GetComponent<ItemProperties>());
            ObjectClone.Init(_objectController);

            string color = ObjectClone.GetComponent<ItemProperties>().GetObjColor();
            string type = ObjectClone.GetComponent<ItemProperties>().GetObjType();

            if (color == "RED")
            {
                ObjectClone.GetComponent<SpriteRenderer>().sprite = _objectsRed[rand];
            }

            else if (color == "BLUE")
            {
                ObjectClone.GetComponent<SpriteRenderer>().sprite = _objectsBlue[rand];
            }

            else if (color == "GREEN")
            {
                ObjectClone.GetComponent<SpriteRenderer>().sprite = _objectsGreen[rand];
            }

            else if (color == "YELLOW")
            {
                ObjectClone.GetComponent<SpriteRenderer>().sprite = _objectsYellow[rand];
            }
            else if (color == "NEUTRAL")
            {
                Debug.Log("OBJET NEUTRE HAHAHAHAHA");
                ObjectClone.GetComponent<SpriteRenderer>().sprite = _objectsNeutral[rand];
            }

            _timeStamp = 0;
            _spawnRate = Random.Range(_spawnRateMin, _spawnRateMax);
            _canBeBonusMalus = false;
        }
    }

    private void SpawnBonus()
    {
        int bonusAnim = Random.Range(0, 6);

        switch (bonusAnim)
        {
            case 0:
                _bonusAnimation[bonusAnim].SetActive(true);
                break;
            case 1:
                _bonusAnimation[bonusAnim].SetActive(true);
                break;
            case 2:
                _bonusAnimation[bonusAnim].SetActive(true);
                break;
            case 3:
                _bonusAnimation[bonusAnim].SetActive(true);
                break;
            case 4:
                _bonusAnimation[bonusAnim].SetActive(true);
                break;
            case 5:
                _bonusAnimation[bonusAnim].SetActive(true);
                break;
            default:
                for (int i = 0; i<= _bonusAnimation.Length; i++)
                {
                    _bonusAnimation[i].SetActive(false);
                }
                break;
        }

        StartCoroutine(GoodOmen());

        _timeStamp = 0;
        _spawnRate = Random.Range(_spawnRateMin, _spawnRateMax);
        _bonusType = Random.Range(0, 3);
        _canBeBonusMalus = false;
    }

    private void SpawnMalus()
    {
        _malusAnimation.SetActive(true);
        StartCoroutine(BadOmen());

        _timeStamp = 0;
        _spawnRate = Random.Range(_spawnRateMin, _spawnRateMax);
        _malusType = Random.Range(0, 2);
        _canBeBonusMalus = false;
    }

    IEnumerator GoodOmen()
    {
        yield return new WaitForSeconds(_timer);
        ObjectMovement BonusClone = Instantiate(_bonusToSpawn[_bonusType], transform.position, transform.rotation, _objectContainer);
        _objectController.AddItem(BonusClone.GetComponent<ItemProperties>());
        BonusClone.Init(_objectController);

        string itemName = BonusClone.GetComponent<ItemProperties>().name;
        for (int i = 0; i <= _bonusAnimation.Length; i++)
        {
            _bonusAnimation[i].SetActive(false);
        }
    }

    IEnumerator BadOmen()
    {
        yield return new WaitForSeconds(_malusTimer);
        _malusAnimation.SetActive(false);
        yield return new WaitForSeconds(_timer);
        ObjectMovement MalusClone = Instantiate(_malusToSpawn[_malusType], transform.position, transform.rotation, _objectContainer);
        _objectController.AddItem(MalusClone.GetComponent<ItemProperties>());
        MalusClone.Init(_objectController);

        string itemName = MalusClone.GetComponent<ItemProperties>().name;
        
    }
}
