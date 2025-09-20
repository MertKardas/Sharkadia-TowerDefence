using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingBar : MonoBehaviour {
    [SerializeField] private List<BuildingSO> buildingSOs;
    [SerializeField] private GameObject buildingButtonPrefab;

    public event Action<BuildingSO> OnSelectedBuildingChanged;

    private BuildingSO _selectedBuildingSO;
    public BuildingSO SelectedBuildingSO {
        get => _selectedBuildingSO;
        set {
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
        buttonGO.GetComponent<BuildingButton>().Initialize(buildingSO, this);

    }
}
