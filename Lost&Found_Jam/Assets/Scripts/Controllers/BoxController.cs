using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    #region Fields
    [SerializeField] private List<BoxProperties> _item = null;

    private string _boxColor = "";
    private string _state = "";
    private int _maxCapacity = 0;
    private int _capacity = 0;
    #endregion Fields

    #region Properties
    #endregion Properties

    #region Methodes
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion Methodes
}
