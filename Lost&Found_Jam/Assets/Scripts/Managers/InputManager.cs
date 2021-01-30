using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    #region Fields
    [SerializeField] private KeyCode _upRed = KeyCode.UpArrow;
    [SerializeField] private KeyCode _downBlue = KeyCode.DownArrow;
    [SerializeField] private KeyCode _rightGreen = KeyCode.RightArrow;
    [SerializeField] private KeyCode _leftYellow = KeyCode.LeftArrow;
    
    [SerializeField] private KeyCode _space = KeyCode.Space;

    [SerializeField] private KeyCode _OneRed = KeyCode.Alpha1;
    [SerializeField] private KeyCode _TwoBlue = KeyCode.Alpha2;
    [SerializeField] private KeyCode _ThreeGreen = KeyCode.Alpha3;
    [SerializeField] private KeyCode _FourYellow = KeyCode.Alpha4;
    #endregion Fields

    #region Properties
    public KeyCode Red => _upRed;
    public KeyCode Blue => _downBlue;
    public KeyCode Green => _rightGreen;
    public KeyCode Yellow => _leftYellow;
    
    public KeyCode Special => _space;

    public KeyCode OneR => _OneRed;
    public KeyCode TwoB => _TwoBlue;
    public KeyCode ThreeG => _ThreeGreen;
    public KeyCode FourY => _FourYellow;
    #endregion Properties

    #region Events
    #endregion Events

    #region Methods
    public void Initialize()
    {

    }

    protected override void Update()
    {

    }
    #endregion Methods
}
