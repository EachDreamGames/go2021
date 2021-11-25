using UnityEngine;

namespace TheGame.Common
{
  public class SceneAnchorInformer : MonoBehaviour
  {
    [SerializeField] private SceneAnchor _anchor;
    [SerializeField] private Transform _transform;

    private void OnEnable() =>
      _anchor.Transform = _transform;

    private void OnDisable()
    {
      if (_anchor.Transform == _transform)
        _anchor.Transform = null;
    }
  }
}