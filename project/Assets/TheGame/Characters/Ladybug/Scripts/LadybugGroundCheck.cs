using System.Collections;
using TheGame.Core.Animations.Parameters;
using UnityEngine;

namespace TheGame.Characters.Ladybug
{
  public class LadybugGroundCheck : MonoBehaviour
  {
    [SerializeField] private Animator _animator;
    [SerializeField] private BoolAnimatorParameter _isGroundedParam;
    [SerializeField] private LayerMask _groundLayers;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private float _xPadding;

    private readonly Collider2D[] _overlappedColliders = new Collider2D[1];
    private bool _isDestroying;

    private void Start() =>
      StartCoroutine(DoCheck());

    private void OnDestroy() =>
      _isDestroying = true;

    private IEnumerator DoCheck()
    {
      while (!_isDestroying)
      {
        yield return new WaitForFixedUpdate();

        Bounds bounds = _collider.bounds;
        float minY = bounds.min.y;
        float maxX = bounds.max.x - _xPadding;
        float minX = bounds.min.x + _xPadding;

        int overlapCount = Physics2D.OverlapBoxNonAlloc(new Vector2((maxX + minX) / 2, minY), new Vector2(maxX - minX, 0.1f), 0f, _overlappedColliders, _groundLayers);
        _animator.SetValue(_isGroundedParam, overlapCount != 0);
      }
    }
  }
}