using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace TheGame.Characters.Squirrel.Scripts
{
  public class SquirrelController : MonoBehaviour
  {
    [SerializeField] private Transform _squirrelTransform;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    [SerializeField] private float _maxSpeedDistance;

    [SerializeField, PropertyRange(0, "$" + nameof(_maxSpeedDistance))]
    private float _minSpeedDistance;

    [SerializeField, PropertyRange(0, "$" + nameof(_minSpeedDistance))]
    private float _criticalDistance;

    [SerializeField] private UnityEvent _onOvertook;

    private void FixedUpdate()
    {
      Vector3 position = _squirrelTransform.position;
      float distance = _playerTransform.position.x - position.x;
      CheckCriticalDistance(distance);

      float speed = distance <= _minSpeedDistance
        ? _minSpeed
        : distance >= _maxSpeedDistance
          ? _maxSpeed
          : Mathf.Lerp(_minSpeed,
            _maxSpeed,
            0.5f);
      float deltaX = speed * Time.deltaTime;
      position.x += deltaX;
      _squirrelTransform.position = position;
    }

    private void CheckCriticalDistance(float distance)
    {
      if (distance > _criticalDistance) return;

      _onOvertook?.Invoke();
      enabled = false;
    }

    private void OnDrawGizmosSelected()
    {
      Vector3 position = _squirrelTransform.position;
      Gizmos.color = Color.green;
      Gizmos.DrawRay(new Vector3(position.x, position.y - 0.5f), Vector3.right * _minSpeedDistance);

      Gizmos.color = Color.yellow;
      Gizmos.DrawRay(new Vector3(position.x, position.y + 0.5f), Vector3.right * _maxSpeedDistance);

      Gizmos.color = Color.red;
      Gizmos.DrawRay(new Vector3(position.x, position.y + -1.5f), Vector3.right * _criticalDistance);
    }
  }
}