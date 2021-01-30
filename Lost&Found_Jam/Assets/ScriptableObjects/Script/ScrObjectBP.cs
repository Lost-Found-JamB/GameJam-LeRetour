using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "Inventory/Item")]
public class ScrObjectBP : ScriptableObject
{
    #region Fields
    [SerializeField] private string _name = "New Item";
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _stat = 0;

    [SerializeField] private enum Enum { Default, One, Two }
    [SerializeField] private Enum _enum = Enum.Default;
    #endregion Fields

    #region Properties
    public string GetNameValue(ScrObjectBP X)
    {
        return _name;
    }

    public Sprite IconGS
    {
        get
        {
            return _icon;
        }
    }

    public int GetStatValue(ScrObjectBP X)
    {
        return _stat;
    }

    public string GetEnumValue(ScrObjectBP X)
    {
        return _enum.ToString();
    }
    #endregion Properties
}
