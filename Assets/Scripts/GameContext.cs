using System;
using UnityEngine;
/*<summary> 
/// <summary>
/// Provides central access to game state and shared resources.
</summary>*/

public class GameContext
{
    public event Action<int> OnGoldChanged;
    public int Gold { get; private set; } = 0;
    public void AddGold (int amount)
    {
        if(amount < 0)
        {
            Debug.LogError("Cannot add negative gold.");
            return;
        }
        Gold += amount;
        OnGoldChanged?.Invoke(Gold);
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
        OnGoldChanged?.Invoke(Gold);
    }
    public void ResetResource() { 
        Gold = 0;
        OnGoldChanged?.Invoke(Gold);
    }
}
