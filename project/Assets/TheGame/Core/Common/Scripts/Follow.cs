using UnityEngine;

namespace TheGame.Core.Common
{
  public class Follow : MonoBehaviour
  {
    [SerializeField] private Transform _target;
    [SerializeField] private bool _ignoreX;
    [SerializeField] private bool _ignoreY;
    [SerializeField] private bool _ignoreZ;

    private Vector3 _offset;
    private Transform _transform;

    private void Start()
    {
      _transform = transform;
      _offset = _target.position - _transform.position;
    }

    private void Update()
    {
      Vector3 currentPosition = _transform.position;
      Vector3 targetPosition = _target.position;
      Vector3 newPosition = new Vector3
      {
        x = _ignoreX ? currentPosition.x : targetPosition.x - _offset.x,
        y = _ignoreY ? currentPosition.y : targetPosition.y - _offset.y,
        z = _ignoreZ ? currentPosition.z : targetPosition.z - _offset.z,
      };

      _transform.position = newPosition;
    }
  }
}