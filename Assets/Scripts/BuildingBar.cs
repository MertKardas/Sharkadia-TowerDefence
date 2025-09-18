using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingBar : MonoBehaviour {
    [SerializeField] private List<BuildingSO> buildingSOs;
    [SerializeField] private GameObject buildingButtonPrefab;

    public event Action<BuildingSO> OnSelectedBuildingChanged;

    public BuildingSO _selectedBuildingSO;
    public BuildingSO SelectedBuildingSO {
        get => _selectedBuildingSO;
        private set {
            if (_selectedBuildingSO == value)
                return; // ayný seçim tekrar edilirse event tetiklenmesin

            _selectedBuildingSO = value;
            OnSelectedBuildingChanged?.Invoke(_selectedBuildingSO);

            Debug.Log($"Selected building: {_selectedBuildingSO.buildingName}");
        }
    }

    private void Start() {
        if (buildingSOs == null || buildingSOs.Count == 0)
            return;

        foreach (var buildingSO in buildingSOs) {
            CreateBuildingButton(buildingSO);
        }
    }

    private void CreateBuildingButton(BuildingSO buildingSO) {
        var buttonGO = Instantiate(buildingButtonPrefab, transform);

        // UI bileþenlerini doldur
        var image = buttonGO.GetComponent<Image>();
        if (buildingSO.icon)
            image.sprite = buildingSO.icon;

        var label = buttonGO.GetComponentInChildren<TextMeshProUGUI>();
        label.text = buildingSO.buildingName ?? "Castle null";

        var uiButton = buttonGO.GetComponent<Button>();
        uiButton.onClick.AddListener(() => {
            SelectedBuildingSO = buildingSO;
            GameObject buildingGO = Instantiate(buildingSO.buildingPrefab); 
            var building = buildingGO.GetComponent<Building>();
            

        });
    }
}
