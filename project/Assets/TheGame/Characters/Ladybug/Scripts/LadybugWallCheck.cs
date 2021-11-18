using System.Collections;
using TheGame.Core.Animations.Parameters;
using UnityEngine;

namespace TheGame.Characters.Ladybug
{
  public class LadybugWallCheck : MonoBehaviour
  {
    [SerializeField] private Animator _animator;
    [SerializeField] private BoolAnimatorParameter _isWallTouchingParam;
    [SerializeField] private LayerMask _groundLayers;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private float _yPadding = 0.1f;
    [SerializeField] private float _xSize = 0.1f;

    private readonly Collider2D[] _overlappedColliders = new Collider2D[10];
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

        OverlapBoxInfo overlapBox = GetOverlapBoxInfo();

        int overlapCount = Physics2D.OverlapBoxNonAlloc(overlapBox.Center, overlapBox.Size, 0f, _overlappedColliders, _groundLayers);

        bool isWallTouching = false;
        int i = 0;

        while (!isWallTouching && i < overlapCount)
        {
          Collider2D overlappedCollider = _overlappedColliders[i];
          isWallTouching = !overlappedCollider.usedByEffector || !overlappedCollider.GetComponent<PlatformEffector2D>();
          i++;
        }

        _animator.SetValue(_isWallTouchingParam, isWallTouching);
      }
    }

    private OverlapBoxInfo GetOverlapBoxInfo()
    {
      Bounds bounds = _collider.bounds;
      float x = transform.lossyScale.x > 0 ? bounds.max.x : bounds.min.x;
      float maxY = bounds.max.y - _yPadding;
      float minY = bounds.min.y + _yPadding;
      return new OverlapBoxInfo
      {
        Center = new Vector2(x, (maxY + minY) / 2),
        Size = new Vector2(_xSize, maxY - minY)
      };
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
      OverlapBoxInfo overlapBox = GetOverlapBoxInfo();
      
      Gizmos.color = !Application.isPlaying ? Color.white : _animator.GetValue(_isWallTouchingParam) ? Color.green : Color.red;
      Gizmos.DrawCube(overlapBox.Center, overlapBox.Size);
    }
#endif

    private struct OverlapBoxInfo
    {
      public Vector2 Center;
      public Vector2 Size;
    }
  }
}