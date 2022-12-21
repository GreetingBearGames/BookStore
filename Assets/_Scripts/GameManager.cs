using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private float _money, _moneyPerSecond, _customerPerSecond, _productPerSecond;
    private static GameManager _instance;
    private bool _isGameOver = false, _isWin = false, _isLose = false, _isGameStarted = false;
    private int _savedLevel;
    public static GameManager Instance {
        get {
            if (_instance == null) {
                Debug.LogError("Game Manager is null");
            }
            return _instance;
        }
        private set => _instance = value;
    }
    public float Money {
        get => _money;
        set{
            if(value < 0){
                Debug.Log("Money can't be negative value!");
            }
            else{
                _money = value;
            }
        }
    }
    public float MoneyPerSecond{
        get => _moneyPerSecond;
        set{
            if(value < 0){
                Debug.Log("MoneyPerSec can't be negative value!");
            }
            else{
                _moneyPerSecond = value;
            }
        }
    }
    public float CustomerPerSecond{
        get => _customerPerSecond;
        set{
            if(value < 0){
                Debug.Log("CustomerPerSec can't be negative value!");
            }
            else{
                _customerPerSecond = value;
            }
        }
    }
    public float ProductPerSecond{
        get => _productPerSecond;
        set{
            if(value < 0){
                Debug.Log("ProductPerSec can't be negative value!");
            }
            else{
                _productPerSecond = value;
            }
        }
    }
    public bool IsGameOver{
        get => _isGameOver;
        set => _isGameOver = value;
    }
    public bool IsGameStarted {
        get => _isGameStarted;
        set => _isGameStarted = value;
    }
    public bool IsWin {
        get => _isWin;
        set => _isWin = value;
    }
    public int SavedLevel {
        get => _savedLevel;
        set => _savedLevel = value;
    }
    private void Awake() {
        Instance = this;
        Money = PlayerPrefs.GetFloat("MoneyAmount", 0f);
        MoneyPerSecond = PlayerPrefs.GetFloat("MoneyPerSecAmount", 0f);
        CustomerPerSecond = PlayerPrefs.GetFloat("CustomerPerSecAmount", 0f);
        ProductPerSecond = PlayerPrefs.GetFloat("ProductPerSecAmount", 0f);
    }
    public void UpdateMoney(float updateAmount) {
        Money += updateAmount;
        if (Money < 0) {
            Money = 0;
        }
    }
    public void NextLevel() {
        PlayerPrefs.SetFloat("MoneyAmount", Money);
        PlayerPrefs.SetFloat("MoneyPerSec", MoneyPerSecond);
        PlayerPrefs.SetFloat("CustomerPerSecAmount", CustomerPerSecond);
        PlayerPrefs.SetFloat("ProductPerSecAmount", ProductPerSecond);
        PlayerPrefs.SetInt("SavedLeved", _savedLevel + 1);
        LevelLoader.Current.ChangeLevel("Level " + PlayerPrefs.GetInt("SavedLeved"));
    }
}
