using System.Collections.Generic;
using UnityEngine;

static class Global
{

  // Enums
  public enum Companion
  {
    Fairy,
    Cat,
    Ghost
  }

  // Collision layers
  public const int wallLayer = 6;
  public const int playerLayer = 7;
  public const int bridgeLayer = 8;

  // Player stats
  public static int bridgesPlayerIsOn = 0;
  public static HashSet<Companion> companions = new HashSet<Companion>();

  // Utilities
  public static void AddCompanion(Companion toAdd)
  {
    companions.Add(toAdd);
  }

  public static bool HasCompanion(Companion toCheck)
  {
    return companions.Contains(toCheck);
  }

  public static float CalculateDistance(Vector3 a, Vector3 b)
  {
    // Only consider X and Y for 2D distance
    return Vector2.Distance(new Vector2(a.x, a.y), new Vector2(b.x, b.y));
  }

}