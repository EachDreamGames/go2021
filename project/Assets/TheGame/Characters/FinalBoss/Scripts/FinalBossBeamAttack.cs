using System.Collections;
using Sirenix.OdinInspector;
using TheGame.Common;
using TheGame.Core.Animations.Attributes;
using TheGame.Core.Animations.Parameters;
using UnityEngine;

namespace TheGame.Characters.FinalBoss.Scripts
{
  public class FinalBossBeamAttack : AnimatorStateAttributeBehaviour
  {
    [SerializeField, AssetsOnly, AssetSelector]
    private Beam _beamPrefab;

    [SerializeField] private TriggerAnimatorParameter _mustEndParameter;

    [SerializeField, TabGroup("Points")] private Transform _start;
    [SerializeField, TabGroup("Points")] private Transform _finish1;
    [SerializeField, TabGroup("Points")] private Transform _finish2;
    [SerializeField, TabGroup("Points")] private bool _mustFixFinish2;

    [SerializeField, TabGroup("Timings"), SuffixLabel("s")]
    private float _startDelay;

    [SerializeField, TabGroup("Timings"), SuffixLabel("s")]
    private float _movementTime;

    [SerializeField, TabGroup("Timings"), SuffixLabel("s")]
    private float _endDelay;

    private Beam _beamInstance;
    private Transform _finishPoint;
    private Transform _targetFinishPoint;
    private Coroutine _attackCoroutine;

    protected override void OnStateActivate()
    {
      _beamInstance = Instantiate(_beamPrefab);
      _beamInstance.SetStartPoint(_start);
      MakeFinishPoints();
      _beamInstance.SetFinishPoint(_finishPoint);

      _attackCoroutine = StartCoroutine(DoAttack());
    }

    protected override void OnStateDeactivate()
    {
      if (_attackCoroutine != null)
        StopCoroutine(_attackCoroutine);
      Destroy(_beamInstance.gameObject);
      FreeFinishPoints();
    }

    private void MakeFinishPoints()
    {
      _finishPoint = new GameObject().transform;
      _finishPoint.name = $"{nameof(FinalBossBeamAttack)}.{nameof(_finishPoint)}";
      _finishPoint.position = _finish1.position;

      if (_mustFixFinish2)
      {
        _targetFinishPoint = new GameObject().transform;
        _targetFinishPoint.name = $"{nameof(FinalBossBeamAttack)}.{nameof(_targetFinishPoint)}";
        _targetFinishPoint.position = _finish2.position;
      }
      else
        _targetFinishPoint = _finish2;
    }

    private void FreeFinishPoints()
    {
      if (_finishPoint) Destroy(_finishPoint.gameObject);
      if (_mustFixFinish2 && _targetFinishPoint) Destroy(_targetFinishPoint.gameObject);
    }

    private IEnumerator DoAttack()
    {
      yield return new WaitForSeconds(_startDelay);

      float fullDistance = (_targetFinishPoint.position - _finishPoint.position).magnitude;
      float stepDistance = fullDistance / _movementTime * Time.fixedDeltaTime;

      float endMovementTime = Time.fixedTime + _movementTime;
      while (Time.fixedTime < endMovementTime)
      {
        yield return new WaitForFixedUpdate();

        _finishPoint.position = Vector2.MoveTowards(
          _finishPoint.position, _targetFinishPoint.position, stepDistance);
      }

      _finishPoint.position = _targetFinishPoint.position;
      yield return new WaitForSeconds(_endDelay);
      Animator.SetTrigger(_mustEndParameter);
      _attackCoroutine = null;
    }
  }
}