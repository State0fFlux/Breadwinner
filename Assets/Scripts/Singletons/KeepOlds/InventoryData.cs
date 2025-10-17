using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;


public class InventoryData : KeepOldSingleton<InventoryData>
{
  // Only used for setting debug start inventory

  [Header("Starting Ingredients")]
  [SerializeField] private List<IngredientData> startingIngredients = new List<IngredientData>();

  [Header("Starting Companions")]
  [SerializeField] private List<CompanionData> startingCompanions = new List<CompanionData>();

  // Used internally to store inventory during game
  private readonly Dictionary<IngredientData, int> ingredients = new Dictionary<IngredientData, int>();
  private readonly List<CompanionData> companions = new List<CompanionData>();
  public IReadOnlyDictionary<IngredientData, int> Ingredients => ingredients;
  public IReadOnlyList<CompanionData> Companions => companions;

  // Signals
  public event Action OnInventoryChanged;

  public GameObject fairyLight;

  void OnEnable()
  {
    ResetInventory();
  }

  void Start()
  {
    OnInventoryChanged?.Invoke();
  }

  private void ResetInventory()
  {
    ingredients.Clear();
    foreach (IngredientData ingredient in startingIngredients)
    {
      ingredients[ingredient] = ingredient.needed; // max out
    }

    companions.Clear();
    foreach (CompanionData companion in startingCompanions)
    {
      companions.Add(companion);
    }
  }

  public bool Add(IngredientData ingredient)
  {
    if (GetCount(ingredient) >= ingredient.needed)
    {
      return false;
    }

    ingredients[ingredient] = GetCount(ingredient) + 1;
    OnInventoryChanged?.Invoke();
    return true;
  }

  public bool Add(CompanionData toAdd)
  {
    if (companions.Contains(toAdd))
    {
      return false;
    }
    companions.Add(toAdd);
    Global.newCompanion = true;
    OnInventoryChanged?.Invoke();
    return true;
  }

  public bool Remove(CompanionData toRemove)
  {
    if (!companions.Contains(toRemove))
    {
      return false;
    }
    companions.Remove(toRemove);
    OnInventoryChanged?.Invoke();
    return true;
  }

  public bool Remove(IngredientData toRemove)
  {
    if (GetCount(toRemove) == 0)
    {
      return false;
    }

    ingredients[toRemove] = GetCount(toRemove) - 1;
    OnInventoryChanged?.Invoke();
    return true;
  }

  public float GetPercentage(IngredientData ingredient)
  {
    float percentage = (float)GetCount(ingredient) / ingredient.needed;
    return percentage;
  }

  public int GetCount(IngredientData ingredient)
  {
    return ingredients.GetValueOrDefault(ingredient, 0);
  }

  public bool Has(CompanionData.Type type)
  {
    foreach (CompanionData companion in companions)
    {
      if (companion.type == type)
      {
        return true;
      }
    }
    return false;
  }

  public bool Has(IngredientData.Type type)
  {
    foreach (KeyValuePair<IngredientData, int> pair in ingredients)
    {
      if (pair.Key.type == type)
      {
        return pair.Value == pair.Key.needed;
      }
    }
    return false;
  }
}