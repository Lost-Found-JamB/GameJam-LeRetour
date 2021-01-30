using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    #region Fields
    [SerializeField] private List<BoxProperties> _box = null;
    [SerializeField] private float _timer = 3f;

    private string _boxColor = "";
    private string _state = "";
    private int _maxCapacity = 0;
    private int _capacity = 0;
    #endregion Fields

    #region Properties

    #endregion Properties

    #region Methodes
    private void Start()
    {
        for(int i = 0; i<_box.Count; i++)
        {
            _state = _box[i].GetBoxState();
        }
    }

    public bool BoxValidator(int boxNb)
    {
        _state = _box[boxNb].GetBoxState();

        if (_state == "FULL" || _state == "SEND" || _state == "ERROR")
        {
            Debug.Log("WARNING: " + _state);
            return false;
        }

        _maxCapacity = _box[boxNb].GetBoxMaxCapacity();
        _capacity = _box[boxNb].GetBoxCapacity();
        _box[boxNb].SetBoxCapacity(_capacity + 1);
        _capacity = _box[boxNb].GetBoxCapacity();

        if (_capacity == _maxCapacity)
        {
            _state = "FULL";
            _box[boxNb].SetBoxState(BoxStates.FULL);
        }
        else if (_capacity == _maxCapacity - 1)
        {
            _state = "ALMOSTFULL";
            _box[boxNb].SetBoxState(BoxStates.ALMOSTFULL);
        }
        Debug.Log(_state);
        return true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(InputManager.Instance.OneR))
        {
            _box[0].SetBoxState(BoxStates.SEND);
            StartCoroutine(Sending(0));
            //score up;
        }
        else if (Input.GetKeyDown(InputManager.Instance.TwoB))
        {
            _box[1].SetBoxState(BoxStates.SEND);
            StartCoroutine(Sending(1));
            //score up;
        }
        else if (Input.GetKeyDown(InputManager.Instance.ThreeG))
        {
            _box[2].SetBoxState(BoxStates.SEND);
            StartCoroutine(Sending(2));
            //score up;
        }
        else if (Input.GetKeyDown(InputManager.Instance.FourY))
        {
            _box[3].SetBoxState(BoxStates.SEND);
            StartCoroutine(Sending(3));
            //score up;
        }
    }

    IEnumerator Sending(int i)
    {
        yield return new WaitForSeconds(_timer);
        _box[i].SetBoxCapacity(0);
        _box[i].SetBoxState(BoxStates.NOTFULL);
    }

    /*void CheckBoxColor()
    {
        if (_item.Count > 1)
        {
            _objectColor = _item[1].GetObjColor();
            if (_objectColor == color || _objectColor == "NEUTRAL")
            {
                _test = _boxController.BoxValidator(box);
                if (_test)
                {
                    Debug.Log("Color: " + _objectColor + " | SUCCESS !");
                }
                else
                {
                    Debug.Log("Color: " + _objectColor + " | ERROR !");
                }
            }
            else
            {
                Debug.Log("Color: " + _objectColor + " | ERROR !");
            }
            _item.Remove(_item[1]);
        }
    }*/


    #endregion Methodes
}
