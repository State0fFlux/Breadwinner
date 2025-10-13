using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

  // Inventory data
  private Dictionary<IngredientData, int> ingredients = new Dictionary<IngredientData, int>();
  private HashSet<CompanionData> companions = new HashSet<CompanionData>();

  // Signals
  public event Action OnInventoryChanged;

  public static Inventory Instance; // Singleton

  void Awake()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(Instance.gameObject);
    }
    else
    {
      Instance = this;
    }
  }

  /// <summary>
  /// Adds the specified ingredient to the inventory, if able to do so.
  /// </summary>
  /// <returns>True if the ingredient was added, false if we're already at max capacity.</returns>
  /// 
  public static bool AddIngredient(IngredientData ingredient)
  {
    if (GetCount(ingredient) >= ingredient.needed)
    {
      return false;
    }
    Instance.ingredients[ingredient] = GetCount(ingredient) + 1;
    Instance.OnInventoryChanged?.Invoke();
    return true;
  }

  public static void AddCompanion(CompanionData toAdd)
  {
    Instance.companions.Add(toAdd);
    Instance.OnInventoryChanged?.Invoke();
  }

  public static IReadOnlyDictionary<IngredientData, int> GetIngredients() => Instance.ingredients;

  public static IReadOnlyCollection<CompanionData> GetCompanions() => Instance.companions;

  public static float GetPercentage(IngredientData ingredient)
  {
    return (float)GetCount(ingredient) / ingredient.needed;
  }

  public static int GetCount(IngredientData ingredient)
  {
    return Instance.ingredients.GetValueOrDefault(ingredient, 0);
  }

  public static bool HasCompanion(CompanionData.Type CompanionType)
  {
    foreach (CompanionData companion in Instance.companions)
    {
      if (companion.type == CompanionType)
      {
        return true;
      }
    }
    return false;
  }
}