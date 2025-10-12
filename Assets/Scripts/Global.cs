using System.Collections.Generic;

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

  public static void AddCompanion(Companion toAdd)
  {
    companions.Add(toAdd);
  }

  public static bool HasCompanion(Companion toCheck)
  {
    return companions.Contains(toCheck);
  }

}