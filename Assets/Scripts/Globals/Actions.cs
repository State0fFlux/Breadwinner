using System;
using UnityEngine;
static class Actions
{
  public static Action<CompanionData> OnCompanionAcquired;
  public static Action OnFairyAcquired;
  public static Action OnGhostAcquired;
  public static Action OnCatAcquired;

  static Actions()
  {
    // Whenever OnCompanionAcquired is invoked, route based on type
    OnCompanionAcquired += RouteByType;
  }

  // Internal router method
  private static void RouteByType(CompanionData data)
  {
    switch (data.type)
    {
      case CompanionData.Type.Ghost:
        OnGhostAcquired?.Invoke();
        break;
      case CompanionData.Type.Fairy:
        OnFairyAcquired?.Invoke();
        break;
      case CompanionData.Type.Cat:
        OnCatAcquired?.Invoke();
        break;
    }
  }

}