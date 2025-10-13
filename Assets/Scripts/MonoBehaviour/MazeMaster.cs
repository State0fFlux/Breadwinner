using UnityEngine;
public class MazeMaster : MonoBehaviour
{
  public static MazeMaster Instance; // Singleton
  public Door levelStart;
  [SerializeField] private IngredientData currentObjective;

  void Awake()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(Instance.gameObject);
    }

    Instance = this;
  }

  void Start()
  {
    levelStart.Exit();
  }

  public IngredientData GetCurrentObjective()
  {
    return currentObjective;
  }
}