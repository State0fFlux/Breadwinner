using System;
using System.Collections.Generic;
using UnityEngine;


public class InventoryData : KeepOldSingleton<InventoryData>
{
  // Only used for setting debug start inventory

  [Header("Starting Ingredients")]
  [SerializeField] private List<IngredientData> startingIngredients = new List<IngredientData>();

  [Header("Starting Companions")]
  [SerializeField] private List<CompanionData> startingCompanions = new List<CompanionData>();

  // Used internally to store inventory during game
  private readonly Dictionary<IngredientData, int> ingredients = new Dictionary<IngredientData, int>();
  private readonly HashSet<CompanionData> companions = new HashSet<CompanionData>();
  public IReadOnlyDictionary<IngredientData, int> Ingredients => ingredients;
  public IReadOnlyCollection<CompanionData> Companions => companions;

  // Signals
  public event Action OnInventoryChanged;

  public GameObject basicLantern;
  public GameObject upgradedLantern;

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

  public bool AddCompanion(CompanionData toAdd)
  {
    if (companions.Contains(toAdd))
    {
      return false;
    }
    companions.Add(toAdd);
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