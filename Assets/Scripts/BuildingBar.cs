using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingBar : MonoBehaviour {
    [SerializeField] private List<BuildingSO> buildingSOs;
    [SerializeField] private GameObject buildingButtonPrefab;




    public GameObject BuildingGameObject { get; set; }
    public BuildingSO SelectedBuildingSO { get; set; }

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
