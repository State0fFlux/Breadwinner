using UnityEngine;

public class SmoothCamera : KeepNewSingleton<SmoothCamera>
{
  [Header("Target Settings")]

  [Header("Camera Settings")]
  [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);  // Typical 2D camera offset
  [SerializeField, Range(0.01f, 1f)] private float smoothSpeed = 0.125f; // How fast the camera catches up

  private Vector3 velocity = Vector3.zero;
  private Transform target;

  void Start()
  {
    target = Player.Instance.transform;
  } 

  void LateUpdate()
  {
    // Desired position = target position + offset
    Vector3 desiredPosition = target.position + offset;

    // Smoothly interpolate between current and desired position
    Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 1f - smoothSpeed);

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
