using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }    
    public GameContext GameContext { get; private set; }
    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        GameContext = new GameContext();
        GameContext.AddGold(500);
        InvokeRepeating(nameof(Test), 5f, 5f);
    }
    private void Test() {
        GameContext.AddGold(50);
    }
}
