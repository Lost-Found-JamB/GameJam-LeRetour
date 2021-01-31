using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    #region Fields
    [SerializeField] private List<BoxProperties> _box = null;
    [SerializeField] private float _timerBrut = 3f;
    [SerializeField] private ScoreInGameScript _score = null;
    [SerializeField] private SpeedController _speedController = null;

    private string _boxColor = "";
    private string _state = "";
    private int _maxCapacity = 0;
    private int _capacity = 0;
    #endregion Fields

    #region Properties

    #endregion Properties

    #region Methodes
    private void Start()
    {
        for (int i = 0; i<_box.Count; i++)
        {
            _state = _box[i].GetBoxState();
        }
    }

    public bool BoxValidator(int boxNb)
    {
        _state = _box[boxNb].GetBoxState();

        if (_state == "FULL" || _state == "SEND" || _state == "ERROR")
        {
            Debug.Log("WARNING: " + _state);
            return false;
        }

        _maxCapacity = _box[boxNb].GetBoxMaxCapacity();
        _capacity = _box[boxNb].GetBoxCapacity();
        _box[boxNb].SetBoxCapacity(_capacity + 1);
        _capacity = _box[boxNb].GetBoxCapacity();

        if (_capacity == _maxCapacity)
        {
            _box[boxNb].AlmostToFull();
            _box[boxNb].SetBoxState(BoxStates.FULL);
            _state = "FULL";
        }
        else if (_capacity == _maxCapacity - 1)
        {
            _box[boxNb].HalfToAlmost();
            _box[boxNb].SetBoxState(BoxStates.ALMOSTFULL);
            _state = "ALMOSTFULL";
        }
        else if (_capacity == _maxCapacity/2)
        {
            _box[boxNb].EmptyToHalf();
            _box[boxNb].SetBoxState(BoxStates.HALFFULL);
            _state = "HALFFULL";
        }
        Debug.Log(_state);
        return true;
    }

    private void Update()
    {
        //Debug.Log(_clock.GetTimeStamp());
        if (Input.GetKeyDown(InputManager.Instance.OneR))
        {
            _box[0].ToClosed();
            _box[0].SetBoxState(BoxStates.SEND);
            StartCoroutine(Sending(0));
            //score up;
        }
        else if (Input.GetKeyDown(InputManager.Instance.TwoB))
        {
            _box[1].ToClosed();
            _box[1].SetBoxState(BoxStates.SEND);
            StartCoroutine(Sending(1));
            //score up;
        }
        else if (Input.GetKeyDown(InputManager.Instance.ThreeG))
        {
            _box[2].ToClosed();
            _box[2].SetBoxState(BoxStates.SEND);
            StartCoroutine(Sending(2));
            //score up;
        }
        else if (Input.GetKeyDown(InputManager.Instance.FourY))
        {
            _box[3].ToClosed();
            _box[3].SetBoxState(BoxStates.SEND);
            StartCoroutine(Sending(3));
            //score up;
        }
    }

    IEnumerator Sending(int i)
    {
        int itemToScore = _box[i].GetBoxCapacity();
        bool boxIsFull = (itemToScore == _box[i].GetBoxMaxCapacity());
        bool boxIsAlmostFull = (itemToScore == _box[i].GetBoxMaxCapacity()/2);

        yield return new WaitForSeconds(_timerBrut);
        _score.Score(itemToScore, boxIsFull, boxIsAlmostFull);
        _box[i].SetBoxCapacity(0);
        _box[i].SetBoxState(BoxStates.NOTFULL);
        _box[i].ClosedToEmpty();
    }

    #endregion Methodes
}
