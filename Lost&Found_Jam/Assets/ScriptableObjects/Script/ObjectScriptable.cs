using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "Object")]
public class ObjectScriptable : ScriptableObject
{
    #region Fields
    [SerializeField] private string _name = "New Item";
    [SerializeField] private Sprite _sprite;

    [SerializeField] private ObjColor _color = ObjColor.NONE;
    [SerializeField] private ObjType _type = ObjType.NONE;
    #endregion Fields

    #region Properties
    public string GetNameValue()
    {
        return _name;
    }

    public Sprite Sprite
    {
        get
        {
            return _sprite;
        }
    }

    public string GetObjColor()
    {
        return _color.ToString();
    }

    public void SetObjColor(ObjColor color)
    {
        _color = color;
    }

    public string GetObjType()
    {
        return _type.ToString();
    }
    #endregion Properties
}