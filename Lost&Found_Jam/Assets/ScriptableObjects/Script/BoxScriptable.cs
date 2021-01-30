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
    [SerializeField] private int _capacity = 0;
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

    public void SetBoxState(BoxStates state)
    {
        _state = state;
    }

    public int GetBoxMaxCapacity()
    {
        return _maxCapacity;
    }

    public int GetBoxCapacity()
    {
        return _capacity;
    }

    public void SetBoxCapacity(int capacity)
    {
        _capacity = capacity;
    }
    #endregion Properties
}
