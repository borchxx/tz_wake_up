using System;
using UnityEngine;
using TMPro;
using Button = UnityEngine.UI.Button;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _gameView;
    [SerializeField] private GameObject _startView;
    [SerializeField] private GameObject _gameOverView;
    [SerializeField] private BestScore _bestScore;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _bonusText;
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private TextMeshProUGUI _currentScore;
    
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Player _player;
    [SerializeField] private int _healht = 3;
    [SerializeField] private GeneratePlane _generatePlane;

    
    // [SerializeField] private int _healht = 3;
    private int _healthCounter;
    private int _bonusCounter = 0;
    void Start()
    {
        _player.PlayerTakeDamage += CountHelth;
        _player.PlayerTakeBonus += CountBonus;
        _healthCounter = _healht;
        _startButton.onClick.AddListener(StartGame);
        _restartButton.onClick.AddListener(StartGame);
        OpenMenu();
    }

    private void CountHelth()
    {
        _healthCounter -= 1;
        if (_healthCounter <= 0)
        {
            _gameView.SetActive(false);            
            _gameOverView.SetActive(true);
            _generatePlane.Remove();
            if (_bestScore.Score < _bonusCounter)
            {
                _bestScore.Score = _bonusCounter;
            }
            _bestScoreText.text = $"Best score: {_bestScore.Score.ToString()}";
            _currentScore.text =  $"Current score: {_bonusCounter.ToString()}";
        }
        else
        {
            _healthText.text = _healthCounter.ToString();
        }
    }

    private void CountBonus()
    {
        _bonusCounter++;
        _bonusText.text = _bonusCounter.ToString();
    }

    private void OpenMenu()
    {
        _gameOverView.SetActive(false);
        _startView.SetActive(true);
        _gameView.SetActive(false);
    }
    
    private void StartGame()
    {
        _bonusText.text = _bonusCounter.ToString();
        _bonusCounter = 0;
        _healthCounter = _healht;
        _gameOverView.SetActive(false);
        _startView.SetActive(false);
        _gameView.SetActive(true);
        _generatePlane.Generate();
    }
}
