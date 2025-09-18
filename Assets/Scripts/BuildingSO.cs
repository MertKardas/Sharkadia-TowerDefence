using UnityEngine;
using NaughtyAttributes;
[CreateAssetMenu(fileName = "New Building", menuName = "Building")]
public class BuildingSO : ScriptableObject {

    public string buildingName;
    [ShowAssetPreview(64, 64)]
    public GameObject buildingPrefab;

    [Min(0)]
    public int cost;

    [Min(0f)]
    public float buildTime;

    [ShowAssetPreview(64, 64)]
    public Sprite icon;
}

   
  
