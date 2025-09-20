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
            // Only create new building if different building is selected or no building is currently selected
            if (buildingBar.SelectedBuildingSO != buildingSO) {
                // Destroy existing building GameObject if one exists
                if (buildingBar.BuildingGameObject != null) {
                    Destroy(buildingBar.BuildingGameObject);
                }

                buildingBar.SelectedBuildingSO = buildingSO;
                buildingBar.BuildingGameObject = Instantiate(buildingSO.buildingPrefab);
                var building = buildingBar.BuildingGameObject.GetComponent<Building>();
                building.OnBuildingStateChange += (state) => {
                    if (state == BuildingState.Placed) {
                        buildingBar.BuildingGameObject = null;
                        buildingBar.SelectedBuildingSO = null;
                    }
                };

            }
        });

        
        _gameContext = GameManager.Instance.GameContext;
        _button.interactable = false; 
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
