using UnityEngine;
using NaughtyAttributes;  

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;
    [Scene, SerializeField] private string mainGameSceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    public void LoadMainGameScene()
    {
        LoadScene(mainGameSceneName);
    }

}
