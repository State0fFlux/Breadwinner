using UnityEngine;

public class SmoothCamera : KeepNewSingleton<SmoothCamera>
{
  [Header("Target Settings")]

  [Header("Camera Settings")]
  [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);  // Typical 2D camera offset
  [SerializeField, Range(0.01f, 1f)] private float responsiveness = 1f; // How fast the camera catches up

  private Vector3 velocity = Vector3.zero;
  private Transform target;

  void Start()
  {
    target = Player.Instance.transform;
    SnapToTarget();
  }

  void LateUpdate()
  {
    // Desired position = target position + offset
    Vector3 desiredPosition = target.position + offset;

    // Scale responsiveness by player speed
    float adjustedResponsiveness = responsiveness;

    // Convert responsiveness to SmoothDamp's smoothTime (smaller = faster catch up)
    float smoothTime = Mathf.Max(0.001f, 1f - adjustedResponsiveness);

    Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);

    // Apply the position
    transform.position = smoothedPosition;
  }

  /// <summary>
  /// Instantly snaps camera to the target (useful for initial setup)
  /// </summary>
  public void SnapToTarget()
  {
    transform.position = target.position + offset;
  }
}
