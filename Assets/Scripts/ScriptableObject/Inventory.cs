using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct IngredientEntry
{
  public IngredientData ingredient;
  public int count;
}

[Serializable]
public struct CompanionEntry
{
  public CompanionData companion;
}

[CreateAssetMenu(fileName = "NewInventory", menuName = "Player/Inventory")]
public class Inventory : ScriptableObject
{


  [Header("Starting Ingredients")]
  public List<IngredientEntry> startingIngredients = new List<IngredientEntry>();

  [Header("Starting Companions")]
  public List<CompanionEntry> startingCompanions = new List<CompanionEntry>();

  private Dictionary<IngredientData, int> ingredients = new Dictionary<IngredientData, int>();
  private HashSet<CompanionData> companions = new HashSet<CompanionData>();

  // Signals
  public event Action OnInventoryChanged;

  public GameObject basicLantern;
  public GameObject upgradedLantern;

  /// <summary>
  /// Adds the specified ingredient to the inventory, if able to do so.
  /// </summary>
  /// <returns>True if the ingredient was added, false if we're already at max capacity.</returns>
  /// 
  /// 
  public static Inventory Instance;
  private void OnEnable()
  {
    Instance = this;

    // Initialize runtime dictionaries from inspector lists
    ingredients.Clear();
    foreach (var entry in startingIngredients)
    {
      ingredients[entry.ingredient] = entry.count;
    }

    companions.Clear();
    foreach (var entry in startingCompanions)
    {
      companions.Add(entry.companion);
    }
  }
  private void OnDisable() => Instance = null;

  public bool AddIngredient(IngredientData ingredient)
  {
    if (GetCount(ingredient) >= ingredient.needed)
    {
      return false;
    }

    ingredients[ingredient] = GetCount(ingredient) + 1;
    OnInventoryChanged?.Invoke();
    return true;
  }

  public void AddCompanion(CompanionData toAdd)
  {
    companions.Add(toAdd);
    OnInventoryChanged?.Invoke();
  }

  public IReadOnlyDictionary<IngredientData, int> GetIngredients() => ingredients;

  public IReadOnlyCollection<CompanionData> GetCompanions() => companions;

  public float GetPercentage(IngredientData ingredient)
  {
    return (float)GetCount(ingredient) / ingredient.needed;
  }

  public int GetCount(IngredientData ingredient)
  {
    return ingredients.GetValueOrDefault(ingredient, 0);
  }

  public bool HasCompanion(CompanionData.Type CompanionType)
  {
    foreach (CompanionData companion in companions)
    {
      if (companion.type == CompanionType)
      {
        return true;
      }
    }
    return false;
  }
}