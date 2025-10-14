using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "Player/Player")]
public class PlayerData : ScriptableObject
{
  public static PlayerData Instance;
  private void OnEnable() => Instance = this;
  private void OnDisable() => Instance = null;

  public int health;
  public int speed;
}