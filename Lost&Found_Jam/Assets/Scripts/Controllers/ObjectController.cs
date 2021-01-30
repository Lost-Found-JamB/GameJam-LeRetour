using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    #region Fields
    [SerializeField] private List<ItemProperties> _item = null;

    private string _objectColor = "";
    private string _objectType = "";
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
            CheckColor("RED");
        }
        else if (Input.GetKeyDown(InputManager.Instance.Blue))
        {
            CheckColor("BLUE");
        }
        else if (Input.GetKeyDown(InputManager.Instance.Green))
        {
            CheckColor("GREEN");
        }
        else if (Input.GetKeyDown(InputManager.Instance.Yellow))
        {
            CheckColor("YELLOW");
        }
        else if (Input.GetKeyDown(InputManager.Instance.Special))
        {
            CheckType();
        }

    }

    void CheckColor (string color)
    {
        _objectColor = _item[0].GetObjColor();
        if (_objectColor == color || _objectColor == "NEUTRAL")
        {
            Debug.Log("Color: " + _objectColor + " | SUCCESS !");
        }
        else
            Debug.Log("Color: " + _objectColor + " | ERROR !");

        _item.Remove(_item[0]);
    }

    void CheckType ()
    {
        _objectType = _item[0].GetObjType();
        if (_objectType == "BONUS" || _objectType == "MALUS")
        {
            Debug.Log("Type: " + _objectType + " | SUCCESS !");
            _item.Remove(_item[0]);
        }
        else
            Debug.Log("Type: " + _objectType + " | NO EFFECT"); 
    }
    #endregion Methodes
}
