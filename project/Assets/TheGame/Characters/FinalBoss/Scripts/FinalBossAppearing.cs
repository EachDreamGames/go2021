using Sirenix.OdinInspector;
using TheGame.Common;
using TheGame.Core.Animations.Attributes;
using TheGame.Core.Animations.Parameters;
using UnityEngine;

namespace TheGame.Characters.FinalBoss.Scripts
{
  public class FinalBossAppearing : AnimatorStateAttributeBehaviour
  {
    [SerializeField] private TriggerAnimatorParameter _mustEndParameter;
    [SerializeField] private Rigidbody2D _bossBody;
    [SerializeField] private SceneAnchor _webThreadStartPointAnchor;
    [SerializeField] private Transform _webThreadEndPoint;
    [SerializeField] private SceneAnchor _descentStartPointAnchor;
    [SerializeField] private SceneAnchor _descentStopPointAnchor;
    [SerializeField] private float _descentSpeed = 1;
    [SerializeField, AssetsOnly] private WebThread _webThreadPrefab;

    private WebThread _webThreadInstance;

    protected override void OnStateActivate()
    {
      _webThreadInstance = Instantiate(_webThreadPrefab);
      _webThreadInstance.SetStartPoint(_webThreadStartPointAnchor.Transform);
      _webThreadInstance.SetEndPoint(_webThreadEndPoint);

      _bossBody.position = _descentStartPointAnchor.Transform.position;
    }

    protected override void OnStateUpdate()
    {
      Vector2 currentPosition = _bossBody.position;
      Vector2 endPosition = _descentStopPointAnchor.Transform.position;
      Vector2 distance = endPosition - currentPosition;
      Vector2 direction = distance.magnitude < 1 ? distance : distance.normalized;
      Vector2 nextPosition = currentPosition + direction * _descentSpeed * Time.deltaTime;

      if ((endPosition - nextPosition).magnitude > 0.01)
      {
        _bossBody.MovePosition(nextPosition);
        return;
      }

      _bossBody.MovePosition(endPosition);
      Animator.SetTrigger(_mustEndParameter);
    }

    protected override void OnStateDeactivate()
    {
      if (!_webThreadInstance) return;
      Destroy(_webThreadInstance.gameObject);
    }
  }
}