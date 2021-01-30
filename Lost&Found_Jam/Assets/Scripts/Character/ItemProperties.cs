using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProperties : MonoBehaviour
{
    #region Fields
    [SerializeField] private ObjectScriptable _item = null;

    private string _objectColor = "";
    private string _objectType = "";
    #endregion Fields

    #region Properties
    public string GetObjColor()
    {
        return _item.GetObjColor();
    }

    public string GetObjType()
    {
        return _item.GetObjType();
    }
    #endregion Properties

    #region Methodes
    // Start is called before the first frame update
    void Start()
    {

    }
    #endregion Methodes

}
