using System;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    public Color ZeroCoin = Color.red;
    private TextMeshProUGUI _coinText;
    private GameContext _gameContext;
    private void Start()
    {
        _coinText = GetComponentInChildren<TextMeshProUGUI>();
       _gameContext = GameManager.Instance.GameContext;
        _coinText.text = _gameContext.Gold.ToString();
        _gameContext.OnGoldChanged += UpdateCoinDisplay;
    }

    

    private void UpdateCoinDisplay(int obj) {
        _coinText.text = obj.ToString();
        if (obj <= 0)
        {
            _coinText.color = ZeroCoin;
        }
        else
        {
            _coinText.color = Color.white;
        }
    }
}
