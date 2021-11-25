using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TheGame.Common
{
  public class MouseDrivenTargetLocator : TargetLocator
  {
    [SerializeField] private MouseHelper _mouseHelper;
    [SerializeField] private float _radius;

    private readonly Collider2D[] _overlappedColliders = new Collider2D[10];
    private readonly List<Target> _overlappedTargets = new List<Target>();

    public override GameObject Target =>
      GetTarget();

    private GameObject GetTarget()
    {
      Vector3 cursorPosition = _mouseHelper.GetCursorPosition();
      _overlappedTargets.Clear();

      if (GetOverlappedColliders(cursorPosition, out int overlapCount)) return null;

      for (int index = 0; index < overlapCount; index++)
      {
        Collider2D overlappedCollider = _overlappedColliders[index];
        if (!overlappedCollider.TryGetComponent(out Target target)) continue;

        _overlappedTargets.Add(target);
      }

      switch (_overlappedTargets.Count)
      {
        case 0:
          return null;
        case 1:
          return _overlappedTargets[0].gameObject;
        default:
          _overlappedTargets.Sort(
            (left, right) =>
              ((Vector2)(left.transform.position - cursorPosition)).magnitude >
              ((Vector2)(right.transform.position - cursorPosition)).magnitude
                ? 1
                : -1);
          return _overlappedTargets.First().gameObject;
      }
    }

    private bool GetOverlappedColliders(Vector3 cursorPosition, out int overlapCount) =>
      (overlapCount = Physics2D.OverlapCircleNonAlloc(cursorPosition, _radius, _overlappedColliders)) == 0;
  }
}