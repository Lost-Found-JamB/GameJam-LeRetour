using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    #region Fields
    [SerializeField] private KeyCode _upRed = KeyCode.UpArrow;
    [SerializeField] private KeyCode _downBlue = KeyCode.DownArrow;
    [SerializeField] private KeyCode _leftYellow = KeyCode.LeftArrow;
    [SerializeField] private KeyCode _rightGreen = KeyCode.RightArrow;
    [SerializeField] private KeyCode _space = KeyCode.Space;
    #endregion Fields

    #region Properties
    public KeyCode Red => _upRed;
    public KeyCode Blue => _downBlue;
    public KeyCode Yellow => _leftYellow;
    public KeyCode Green => _rightGreen;
    public KeyCode Special => _space;
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
