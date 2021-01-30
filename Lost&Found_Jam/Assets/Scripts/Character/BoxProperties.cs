using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxProperties : MonoBehaviour
{
    #region Fields
    [SerializeField] private BoxScriptable _box = null;

    private string _boxColor = "";
    private string _state = "";
    private int _capacity = 0;
    private int _maxCapacity = 10;
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

    public void SetBoxState(BoxStates state)
    {
        _box.SetBoxState(state);
    }

    public int GetBoxMaxCapacity()
    {
        return _box.GetBoxMaxCapacity();
    }

    public int GetBoxCapacity()
    {
        return _box.GetBoxCapacity();
    }

    public void SetBoxCapacity(int capacity)
    {
        _box.SetBoxCapacity(capacity);
    }
    #endregion Properties

    #region Methodes
    // Start is called before the first frame update
    void Start()
    {

    }
    #endregion Methodes

}
