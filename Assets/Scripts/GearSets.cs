using UnityEngine;

[CreateAssetMenu(fileName = "NewGearSet", menuName = "Gear/Gear Set")]
public class GearSet : ScriptableObject
{
  [Header("Gear Prefabs (in order of stages)")]
  public GameObject[] gearPrefabs = new GameObject[3];

  [Header("Set Settings")]
  public bool edible = false;
}
