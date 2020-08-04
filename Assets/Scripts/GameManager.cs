using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData _gameData = null;
    [SerializeField] private Transform spawnPoint = null;
    private GameUI _gameUI = null;
    private Coroutine _startWaveCoroutine = null;
    private int currentWave = 0;
    private int _totalWaves = 0;
    private int _health = 0;
    private float _wavesDuration = 0;
    private int _coins = 0;
    private float timer = 0;
    private List<GameObject> enemys = null;
    private int counterEnemys = 0;
    public int Coins => _coins;
    

    private void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_KILL, CheckEnemys);
        _gameUI = GetComponent<GameUI>();
        _totalWaves = _gameData.Waves;
        _health = _gameData.Health;
        _coins = _gameData.Coins;
        _wavesDuration = _gameData.WavesDuration;
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
        _gameUI.CoinsUI.text = _coins.ToString();
        _gameUI.HealthUI.text = _health.ToString();
        _gameUI.WavesUI.text = "1 / " + _totalWaves;
        enemys = new List<GameObject>();
        _startWaveCoroutine = StartCoroutine(StartWave());
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > _wavesDuration + 5) // +5 sec pause time before wave;
        {
            timer = 0;
            StopCoroutine(_startWaveCoroutine);

            if (currentWave < _totalWaves)
            {
                _startWaveCoroutine = StartCoroutine(StartWave());
            }
        }
    }   

    private IEnumerator StartWave()
    {
        currentWave++;      
        _gameUI.WavesUI.text = currentWave + " / " + _totalWaves;

        yield return new WaitForSeconds(5.0f);

        while (true)
        {
            int rnd = UnityEngine.Random.Range(0, _gameData.Enemys.Length);
            GameObject enemy = Instantiate(_gameData.Enemys[rnd], spawnPoint.position, Quaternion.identity);
            enemys.Add(enemy);
            enemy.GetComponent<Enemy>().GameManager = this;
            yield return new WaitForSeconds(3.0f);
        }
    }

    private void CheckEnemys()
    {
        counterEnemys++;

        if (counterEnemys == enemys.Count)
        {
            Win();
        }
    }

    private void Win()
    {
        Time.timeScale = 0.0f;
        _gameUI.Win.gameObject.SetActive(true);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _health = 0;
            GameOver();
        }

        _gameUI.HealthUI.text = _health.ToString();
    }

    private void GameOver()
    {
        Time.timeScale = 0.0f;
        _gameUI.GameOverUI.gameObject.SetActive(true);
    }

    public void ChangeCoins(int incomeCoins)
    {
        _coins += incomeCoins;
        _gameUI.CoinsUI.text = _coins.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_KILL, CheckEnemys);
    }
}
