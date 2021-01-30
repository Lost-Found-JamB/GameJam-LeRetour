using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxProperties : MonoBehaviour
{
    #region Fields
    [SerializeField] private BoxScriptable _box = null;

    [SerializeField] private GameObject _boxEmpty = null;
    [SerializeField] private GameObject _boxHalf = null;
    [SerializeField] private GameObject _boxAlmost = null;
    [SerializeField] private GameObject _boxFull = null;
    [SerializeField] private GameObject _boxClosed = null;

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
    public void EmptyToHalf()
    {
        _boxEmpty.SetActive(false);
        _boxHalf.SetActive(true);
    }

    public void HalfToAlmost()
    {
        _boxHalf.SetActive(false);
        _boxAlmost.SetActive(true);
    }

    public void AlmostToFull()
    {
        _boxAlmost.SetActive(false);
        _boxFull.SetActive(true);
    }

    public void ToClosed()
    {
        _boxEmpty.SetActive(false);
        _boxHalf.SetActive(false);
        _boxAlmost.SetActive(false);
        _boxFull.SetActive(false);
        _boxClosed.SetActive(true);
    }

    public void ClosedToEmpty()
    {
        _boxClosed.SetActive(false);
        _boxEmpty.SetActive(true);
    }
    #endregion Methodes

}
