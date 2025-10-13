using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
  [Header("Target Settings")]
  [SerializeField] private Transform target;     // The object to follow

  [Header("Camera Settings")]
  [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);  // Typical 2D camera offset
  [SerializeField, Range(0.01f, 1f)] private float smoothSpeed = 0.125f; // How fast the camera catches up

  private Vector3 velocity = Vector3.zero;

  void LateUpdate()
  {
    if (target == null) return;

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
    if (target == null) return;
    transform.position = target.position + offset;
  }

  /// <summary>
  /// Call this to change the target at runtime.
  /// </summary>
  public void SetTarget(Transform newTarget)
  {
    target = newTarget;
  }
}
