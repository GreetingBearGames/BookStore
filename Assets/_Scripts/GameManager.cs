using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private float _money, _moneyPerSecond = 1, _customerPerSecond = 1, _productPerSecond = 1, _bookValue = 1;
    private static GameManager _instance;
    private bool _isGameOver = false, _isWin = false, _isGameStarted = false;
    private int _savedLevel, _productionLevel;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Game Manager is null");
            }
            return _instance;
        }
        private set => _instance = value;
    }
    public float Money
    {
        get => _money;
        set
        {
            if (value < 0)
            {
                Debug.Log("Money can't be negative value!");
            }
            else
            {
                _money = value;
            }
        }
    }
    public int ProductionLevel
    {
        get => _productionLevel;
        set
        {
            if (value < 0)
            {
                Debug.Log("Money can't be negative value!");
            }
            else
            {
                _productionLevel = value;
            }
        }
    }
    public float BookValue
    {
        get => _bookValue;
        set
        {
            if (value < 0)
            {
                Debug.Log("Money can't be negative value!");
            }
            else
            {
                _bookValue = value;
            }
        }
    }
    public float MoneyPerSecond
    {
        get => _moneyPerSecond;
        set
        {
            if (value < 0)
            {
                Debug.Log("MoneyPerSec can't be negative value!");
            }
            else
            {
                _moneyPerSecond = value;
            }
        }
    }
    public float CustomerPerSecond
    {
        get => _customerPerSecond;
        set
        {
            if (value < 0)
            {
                Debug.Log("CustomerPerSec can't be negative value!");
            }
            else
            {
                _customerPerSecond = value;
            }
        }
    }
    public float ProductPerSecond
    {
        get => _productPerSecond;
        set
        {
            if (value < 0)
            {
                Debug.Log("ProductPerSec can't be negative value!");
            }
            else
            {
                _productPerSecond = value;
            }
        }
    }
    public bool IsGameOver
    {
        get => _isGameOver;
        set => _isGameOver = value;
    }
    public bool IsGameStarted
    {
        get => _isGameStarted;
        set => _isGameStarted = value;
    }
    public bool IsWin
    {
        get => _isWin;
        set => _isWin = value;
    }
    public int SavedLevel
    {
        get => _savedLevel;
        set => _savedLevel = value;
    }
    private void Awake()
    {
        Instance = this;
        Money = PlayerPrefs.GetFloat("MoneyAmount", 0f);
        MoneyPerSecond = PlayerPrefs.GetFloat("MoneyPerSecAmount", 1f);
        CustomerPerSecond = PlayerPrefs.GetFloat("CustomerPerSecAmount", 1f);
        ProductPerSecond = PlayerPrefs.GetFloat("ProductPerSecAmount", 1f);
        BookValue = PlayerPrefs.GetFloat("BookValue", 1f);
    }
    public void NextLevel()
    {
        PlayerPrefs.SetFloat("MoneyAmount", Money);
        PlayerPrefs.SetFloat("MoneyPerSec", MoneyPerSecond);
        PlayerPrefs.SetFloat("CustomerPerSecAmount", CustomerPerSecond);
        PlayerPrefs.SetFloat("ProductPerSecAmount", ProductPerSecond);
        PlayerPrefs.SetFloat("BookValue", BookValue);
        PlayerPrefs.SetInt("SavedLeved", _savedLevel + 1);

        LevelLoader.Current.ChangeLevel("Level " + PlayerPrefs.GetInt("SavedLeved"));
    }
}
