using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateController : MonoBehaviour
{
    #region Fields
    private ECharacterState _currentState = ECharacterState.NONE;
    private Dictionary<ECharacterState, ACharacterState> _states = null;
    #endregion Fields

    #region Properties
    public ACharacterState CurrentState => _states[_currentState];
    #endregion Properties

    #region Methods
    #region Mono
    public void Start()
    {
        _states = new Dictionary<ECharacterState, ACharacterState>();

        CurrentState.EnterState();
    }

    private void Update()
    {

    }

    public void FixedUpdate()
    {
        CurrentState.UpdateState();
    }
    #endregion Mono

    #region StateMachine
    public void ChangeState(ECharacterState newState)
    {
        Debug.Log("Transition from " + _currentState + " to " + newState);
        CurrentState.ExitState();
        _currentState = newState;
        CurrentState.EnterState();
    }
    #endregion StateMachine
    #endregion Methods
}
