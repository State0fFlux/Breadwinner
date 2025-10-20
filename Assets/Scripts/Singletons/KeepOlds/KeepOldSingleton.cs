using UnityEngine;

public abstract class KeepOldSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
  public static T Instance { get; private set; }

  protected virtual void Awake()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(gameObject); // kep the oldest Instance
      return;
    }

    Instance = this as T;
    DontDestroyOnLoad(gameObject);
  }
}

public class KeepOldSingleton : KeepOldSingleton<KeepOldSingleton>
{

}