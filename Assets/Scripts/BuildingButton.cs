using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BuildingButton : MonoBehaviour
{
    [SerializeField] private Image _image; 
    [SerializeField] private TextMeshProUGUI _label;
    private Button _button; 
    private GameContext _gameContext;
    private void Awake() {
        
        _button = GetComponent<Button>();
    }
    public void Initialize(BuildingSO buildingSO, BuildingBar buildingBar) {
        
        // UI bileþenlerini doldur
        if (buildingSO.icon)
            _image.sprite = buildingSO.icon;

        _label.text = buildingSO.buildingName ?? "Castle null";

        _button.onClick.AddListener(() => {
            buildingBar.SelectedBuildingSO = buildingSO;
            GameObject buildingGO = Instantiate(buildingSO.buildingPrefab);
            var building = buildingGO.GetComponent<Building>();


        });
        _gameContext = GameManager.Instance.GameContext;
        _button.interactable = _gameContext.Gold >= buildingSO.cost;
        _gameContext.OnGoldChanged += (gold) => {
            _button.interactable = gold >= buildingSO.cost;
        };
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
