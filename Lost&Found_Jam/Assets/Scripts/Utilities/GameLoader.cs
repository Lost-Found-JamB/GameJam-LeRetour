using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager = null;
    [SerializeField] private GameStateManager _gameStateManager = null;
    [SerializeField] private GameLoopManager _gameLoopManager = null;

    private void Start()
    {
        _inputManager.Initialize();
        _gameStateManager.Initialize();
        _gameLoopManager.Initialize();
        GameStateManager.Instance.LaunchTransition(EGameState.MAINMENU);
    }
}
