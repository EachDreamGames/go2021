using System.Collections.Generic;
using TheGame.Core.Animations.Attributes;
using TheGame.Core.Common;
using UnityEngine;

namespace TheGame.Characters.Ladybug
{
  public class LadybugInteract : AnimatorStateAttributeBehaviour
  {
    [SerializeField] private Collider2D _collider;

    protected override void OnStateActivate()
    {
      if (TryGetInteractable(out IInteractable interactable))
        interactable.Interact();
    }

    private bool TryGetInteractable(out IInteractable interactable)
    {
      interactable = null;

      List<Collider2D> colliders = new List<Collider2D>();
      if (_collider.OverlapCollider(new ContactFilter2D().NoFilter(), colliders) == 0)
        return false;

      foreach (Collider2D _ in colliders)
        if (_.TryGetComponent(out interactable))
          break;

      return interactable != null;
    }
  }
}