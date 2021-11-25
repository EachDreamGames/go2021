using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace TheGame.Common
{
  public class ProjectileEngine : MonoBehaviour
  {
    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private float _speed;
    [SerializeField, PropertyRange(0, 90), SuffixLabel("°")] private float _ricochetBounceAngle;
    [SerializeField] private UnityEvent _onReach;

    private Transform _targetTransform;
    private Vector2 _targetPosition;
    private bool _isFollowing;
    private bool _isLaunched;

    private void Start() =>
      _body.simulated = _isLaunched;

    private void FixedUpdate()
    {
      UpdateFollowing();
      _body.gravityScale = _isFollowing ? 0 : 1;
      if (!_isFollowing) return;

      Vector2 targetDirection = (GetTargetPosition() - (Vector2)_body.transform.position).normalized;

      _body.velocity = Vector2.Lerp(_body.velocity, targetDirection * _speed, Time.deltaTime);
    }

    private void UpdateFollowing()
    {
      if (!_isFollowing) return;
      if (_targetTransform) return;
      if ((_targetPosition - (Vector2)_body.transform.position).magnitude > 0.1) return;

      _isFollowing = false;
    }

    private Vector2 GetTargetPosition() =>
      _targetTransform ? (Vector2)_targetTransform.position : _targetPosition;

    public void Launch(GameObject target)
    {
      _isLaunched = true;
      _body.simulated = true;
      _targetTransform = target.transform;
      _targetPosition = Vector2.zero;
      _isFollowing = true;
    }

    public void Launch(Vector2 position)
    {
      _isLaunched = true;
      _body.simulated = true;
      _targetPosition = position;
      _targetTransform = null;
      _isFollowing = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (!_isFollowing) return;

      for (int i = 0; i < collision.contactCount; i++)
      {
        ContactPoint2D contact = collision.GetContact(i);
        float collisionAngle = 90 - Vector2.Angle(_body.velocity, contact.normal);
        if (_ricochetBounceAngle > collisionAngle || collisionAngle > 180 - _ricochetBounceAngle) continue;

        _isFollowing = false;
        _onReach?.Invoke();
        return;
      }
    }
  }
}