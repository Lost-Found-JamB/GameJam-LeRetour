using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private int _errorCount = 0;
    [SerializeField] private GameObject _gameOverScreen = null;
    [SerializeField] private GameObject _spawner = null;
    [SerializeField] private BoxController _boxController = null;
    [SerializeField] private GameObject _error1 = null;
    [SerializeField] private GameObject _error2 = null;
    [SerializeField] private GameObject _error3 = null;
    [SerializeField] private GameObject _error4 = null;
    [SerializeField] private GameObject _error5 = null;

    private bool _gameIsOver = false;

    public void AddError()
    {
        _errorCount++;
        //set active les X pour les erreurs
        switch (_errorCount)
        {
            case 1:
                _error1.SetActive(true);
                break;
            case 2:
                _error2.SetActive(true);
                break;
            case 3:
                _error3.SetActive(true);
                break;
            case 4:
                _error4.SetActive(true);
                break;
            case 5:
                _error1.SetActive(false);
                _error2.SetActive(false);
                _error3.SetActive(false);
                _error4.SetActive(false);
                _error5.SetActive(true);
                break;
            default:
                _error1.SetActive(false);
                _error2.SetActive(false);
                _error3.SetActive(false);
                _error4.SetActive(false);
                _error5.SetActive(false);
                break;
        }

        if (_errorCount >= 5)
        {
            _gameIsOver = true;
            _gameOverScreen.SetActive(true);
            _spawner.SetActive(false);
        }
    }

    public void Restart()
    {
        _boxController.ResetAllBoxes();
        GameStateManager.Instance.LaunchTransition(EGameState.GAME);
    }
        
    public void Menu()
    {
        _boxController.ResetAllBoxes();
        GameStateManager.Instance.LaunchTransition(EGameState.MAINMENU);
    }

    public bool GameIsOver()
    {
        return _gameIsOver;
    }
}
