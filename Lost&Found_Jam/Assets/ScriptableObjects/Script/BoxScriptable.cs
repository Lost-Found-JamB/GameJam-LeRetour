using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "Box")]
public class BoxScriptable : ScriptableObject
{
    #region Fields
    [SerializeField] private string _name = "New Box";
    [SerializeField] private Transform _transform = null;
    [SerializeField] private int _maxCapacity = 10;
    [SerializeField] private BoxColor _color = BoxColor.NONE;
    [SerializeField] private BoxStates _state = BoxStates.NONE;
    #endregion Fields

    #region Properties
    public string GetNameValue()
    {
        return _name;
    }

    public string GetBoxColor()
    {
        return _color.ToString();
    }

    public string GetBoxState()
    {
        return _state.ToString();
    }
    #endregion Properties
}
