using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private int _error = 0;
    [SerializeField] private GameObject _gameOverScreen = null;
    [SerializeField] private GameObject _spawner = null;

    private bool _gameIsOver = false;

    public void AddError()
    {
        _error++;
        if (_error >= 5)
        {
            _gameIsOver = true;
            _gameOverScreen.SetActive(true);
            _spawner.SetActive(false);
        }
    }

    public void Restart()
    {

        GameStateManager.Instance.LaunchTransition(EGameState.GAME);
    }
        
    public void Menu()
    {
        GameStateManager.Instance.LaunchTransition(EGameState.MAINMENU);
    }

    public bool GameIsOver()
    {
        return _gameIsOver;
    }
}
