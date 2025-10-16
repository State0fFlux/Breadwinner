using System;
using UnityEngine;

static class Global
{

  // Collision layers
  public const int wallLayer = 6;
  public const int playerLayer = 7;
  public const int bridgeLayer = 8;


  // Utilities

  public static float CalculateDistance(Vector3 a, Vector3 b)
  {
    // Only consider X and Y for 2D distance
    return Vector2.Distance(new Vector2(a.x, a.y), new Vector2(b.x, b.y));
  }

  public static string FormatEnumName(Enum value)
  {
    string s = value.ToString();
    return System.Text.RegularExpressions.Regex.Replace(s, "(\\B[A-Z])", " $1");
  }
}