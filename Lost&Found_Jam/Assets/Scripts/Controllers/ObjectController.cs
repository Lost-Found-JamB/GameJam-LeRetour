using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    #region Fields
    [SerializeField] private List<ItemProperties> _item = null;
    [SerializeField] private BoxController _boxController = null;

    private string _objectColor = "";
    private string _objectType = "";
    private bool _test = false;
    #endregion Fields

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
                    //_box[box].SetBoxState(BoxStates.ERROR);
                }
            }
            else
            {
                Debug.Log("Color: " + _objectColor + " | ERROR !");
            }
            _item.Remove(_item[1]);
        }
    }

    void CheckType()
    {
        if (_item.Count > 1)
        {
            _objectType = _item[0].GetObjType();
            if (_objectType == "BONUS" || _objectType == "MALUS")
            {
                //BoxValidator
                Debug.Log("Type: " + _objectType + " | SUCCESS !");
                _item.Remove(_item[0]);
            }
            else
            {
                Debug.Log("Type: " + _objectType + " | NO EFFECT");
            }
        }
    }
    #endregion Methodes
}
