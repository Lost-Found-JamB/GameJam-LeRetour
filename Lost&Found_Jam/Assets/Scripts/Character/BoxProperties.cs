using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxProperties : MonoBehaviour
{
    #region Fields
    [SerializeField] private BoxScriptable _box = null;

    private string _boxColor = "";
    private string _state = "";
    #endregion Fields

    #region Properties
    public string GetBoxColor()
    {
        return _box.GetBoxColor();
    }

    public string GetBoxState()
    {
        return _box.GetBoxState();
    }
    #endregion Properties

    #region Methodes
    // Start is called before the first frame update
    void Start()
    {

    }
    #endregion Methodes

}
