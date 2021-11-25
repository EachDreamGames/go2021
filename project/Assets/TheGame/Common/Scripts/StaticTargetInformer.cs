using Sirenix.OdinInspector;
using UnityEngine;

namespace TheGame.Common
{
  public class StaticTargetInformer : MonoBehaviour
  {
    [SerializeField, AssetSelector] private StaticTargetContainer _container;
    [SerializeField] private GameObject _target;

    private void OnEnable() =>
      _container.Target = _target;

    private void OnDisable()
    {
      if (_container.Target == _target)
        _container.Target = null;
    }
  }
}