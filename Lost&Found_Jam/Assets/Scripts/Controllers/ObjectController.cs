using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    #region Fields
    [SerializeField] private List<ItemProperties> _item = null;
    [SerializeField] private BoxController _boxController = null;
    [SerializeField] private GameOverController _gameOverController = null;
    [SerializeField] private BonusMalusController _bonusMalusController = null;
    [SerializeField] private Spawner _spawner = null;

    private int _decrementBM = 0;
    private string _objectColor = string.Empty;
    private string _objectType = string.Empty;
    private bool _triggerNeutral = false;
    private bool _triggerMoreItem = false;
    private bool _test = false;
    private bool _isDone = false;
    #endregion Fields

    #region Properties
    public bool IsDone
    {
        get => _isDone;
        set => _isDone = value;
    }
    #endregion Properties

    #region Methodes
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(InputManager.Instance.Red))
        {
            CheckColor("RED", 0);
        }
        else if (Input.GetKeyDown(InputManager.Instance.Blue))
        {
            CheckColor("BLUE", 1);
        }
        else if (Input.GetKeyDown(InputManager.Instance.Green))
        {
            CheckColor("GREEN", 2);
        }
        else if (Input.GetKeyDown(InputManager.Instance.Yellow))
        {
            CheckColor("YELLOW", 3);
        }
        else if (Input.GetKeyDown(InputManager.Instance.Special))
        {
            CheckType();
        }

    }

    void CheckColor(string color, int box)
    {
        if (_item.Count > 1)
        {
            if (_decrementBM > 0 && _triggerNeutral)
            {
                _spawner.IsNeutral(true);
                _decrementBM--;
            }
            else if(_decrementBM > 0 && _triggerMoreItem)
            {
                _decrementBM--;
            }
            else if(_decrementBM <= 0 && (_triggerNeutral || _triggerMoreItem))
            {
                _bonusMalusController.MoreItem(false);
                _spawner.IsNeutral(false);
                _triggerNeutral = false;
                _triggerMoreItem = false;
            }

            _objectColor = _item[1].GetObjColor();
            if (_objectColor == color || _objectColor == "NEUTRAL")
            {
                _test = _boxController.BoxValidator(box);
                if (_test)
                {
                    //Debug.Log("Color: " + _objectColor + " | SUCCESS !");
                }
                else
                {
                    //Debug.Log("Color: " + _objectColor + " | ERROR !");
                    _gameOverController.AddError();
                }
            }
            else
            {
                //Debug.Log("Color: " + _objectColor + " | ERROR !");
                _gameOverController.AddError();
            }
            _item.Remove(_item[1]);
            _isDone = true;

        }
    }

    void CheckType()
    {
        if (_item.Count > 1)
        {
            Debug.Log(_item[1].name);
            _objectType = _item[1].GetObjType();
            if (_objectType == "BONUS" || _objectType == "MALUS")
            {
                if (_item[1].name == "BonusCleaner(Clone)")
                {
                    _bonusMalusController.ClearTrigger(true);
                }
                else if (_item[1].name == "BonusNeutral(Clone)")
                {
                    _triggerNeutral = true;
                    _decrementBM = 5;
                }
                else if (_item[1].name == "MalusMoreItem(Clone)")
                {
                    _bonusMalusController.MoreItem(true);
                    _triggerMoreItem = true;
                    _decrementBM = 5;
                }
                else if (_item[1].name == "BonusSlow(Clone)")
                {
                    _bonusMalusController.SlowDown();
                }
                else if (_item[1].name == "MalusSpeedUp(Clone)")
                {
                    _bonusMalusController.SpeedUp();
                }
                _item.Remove(_item[1]);
                _isDone = true;
            }
        }
    }

    public void AddItem(ItemProperties value)
    {
        _item.Add(value);
    }

    public void RemoveItem(ItemProperties value)
    {
        _item.Remove(value);
    }
    #endregion Methodes
}
