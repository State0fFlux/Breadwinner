using UnityEngine;
public class MazeMaster : MonoBehaviour
{
  public static MazeMaster Instance; // Singleton
  public Door levelStart;
  [SerializeField] private IngredientData currentObjective;

  void OnEnable()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(Instance.gameObject);
    }
    Instance = this;
  }
  void OnDisable()
  {
    Instance = null;
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