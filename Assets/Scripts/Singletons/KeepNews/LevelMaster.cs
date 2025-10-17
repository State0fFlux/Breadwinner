using UnityEngine;
public class LevelMaster : KeepNewSingleton<LevelMaster>
{
  public LevelData data;

  private AudioSource audioSrc;

  protected override void OnEnable()
  {
    base.OnEnable();
    Global.OnFairyAcquired += ImproveCamera;
  }
  protected override void OnDisable()
  {
    base.OnDisable();
    Global.OnFairyAcquired -= ImproveCamera;
  }

  void Awake()
  {
    audioSrc = GetComponent<AudioSource>();
  }

  void Start()
  {
    InventoryData.Instance.Remove(data.ingredientGoal);
    InventoryData.Instance.Remove(data.companionGoal);
    audioSrc.clip = data.theme;
    audioSrc.Play();
  }

  void ImproveCamera()
  {
    StartCoroutine(Global.AnimateFloat(
        start: Camera.main.orthographicSize,
        end: Camera.main.orthographicSize * 2,
        onUpdate: value => Camera.main.orthographicSize = value
    ));
  }
}