using System;
using UnityEngine;
using UnityEngine.Events;

namespace TheGame.Environment.Tree.Scripts
{
  public class TreeBranch : MonoBehaviour
  {
    [SerializeField] private Collider2D _branchCollider;
    [SerializeField] private LayerMask _trunkLayer;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private BoolUnityEvent _onVisibilityChanged;

    private void Start() =>
      UpdateVisibility();

    private void OnTriggerEnter2D(Collider2D other) =>
      UpdateVisibility();

    private void OnTriggerExit2D(Collider2D other) =>
      UpdateVisibility();

    private void UpdateVisibility()
    {
      _renderer.enabled = _branchCollider.IsTouchingLayers(_trunkLayer);
      _onVisibilityChanged?.Invoke(_renderer.enabled);
    }

    [Serializable]
    private class BoolUnityEvent : UnityEvent<bool>
    {
    }
  }
}