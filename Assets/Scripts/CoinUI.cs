using System;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    private TextMeshProUGUI _coinText;
    private GameContext _gameContext;
    private void Start()
    {
        _coinText = GetComponentInChildren<TextMeshProUGUI>();
       _gameContext = GameManager.Instance.GameContext;
        _gameContext.OnGoldChanged += UpdateCoinDisplay;
        

    }

    private void UpdateCoinDisplay(int obj) {
        _coinText.text = obj.ToString();
    }
}
