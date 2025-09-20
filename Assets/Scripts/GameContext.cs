using System;
using UnityEngine;
/*<summary> 
/// <summary>
/// Provides central access to game state and shared resources.
</summary>*/

public class GameContext
{
    public event Action<int> OnGoldChanged;
    private int _gold = 0;
    public int Gold {
        get => _gold;
        private set { 
            _gold = value;
            OnGoldChanged?.Invoke(_gold);
        }
    }
    public GameContext() => OnGoldChanged?.Invoke(Gold);
    public void AddGold(int amount)
    {
        if(amount < 0)
        {
            Debug.LogError("Cannot add negative gold.");
            return;
        }
        Gold += amount;
        
    }
    public void SpendGold (int amount)
    {
        if(amount < 0)
        {
            Debug.LogError("Cannot spend negative gold.");
            return;
        }
        if(amount > Gold)
        {
            Debug.LogError("Not enough gold to spend.");
            return;
        }
        Gold -= amount;
        
    }
    public void ResetResource() { 
        Gold = 0;
    }
}
