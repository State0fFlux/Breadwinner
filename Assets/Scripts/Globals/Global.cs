using System;
using System.Collections;
using UnityEngine;

static class Global
{

  // Collision layers
  public const int wallLayer = 6;
  public const int playerLayer = 7;
  public const int bridgeLayer = 8;

  // Helpful flags
  public static bool newCompanion = false;


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

  public static Action OnFairyAcquired;
  public static Action OnCatAcquired;
  public static Action OnGhostAcquired;

  public static IEnumerator AnimateFloat(float start, float end, Action<float> onUpdate, float duration = 2f, Action onComplete = null)
  {
    float t = 0f;
    while (t < duration)
    {
      t += Time.deltaTime;
      float value = Mathf.Lerp(start, end, t / duration);
      onUpdate?.Invoke(value);
      yield return null;
    }
    onUpdate?.Invoke(end);
    onComplete?.Invoke();
  }
}