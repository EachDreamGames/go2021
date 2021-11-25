using UnityEngine;

namespace TheGame.Common
{
  public class CameraInformer : MonoBehaviour
  {
    [SerializeField] private Camera _camera;
    [SerializeField] private MouseHelper _mouseHelper;

    private void OnEnable()
    {
      if (_mouseHelper)
        _mouseHelper.Camera = _camera;
    }

    private void OnDisable()
    {
      if (_mouseHelper && _mouseHelper.Camera == _camera)
        _mouseHelper.Camera = null;
    }
  }
}