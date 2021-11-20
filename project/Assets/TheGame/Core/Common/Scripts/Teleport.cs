using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace TheGame.Core.Common
{
  public class Teleport : MonoBehaviour, IInteractable
  {
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private UnityEvent _onBeforeTeleportation;
    [SerializeField] private UnityEvent _onAfterTeleportation;

    [Button, DisableInEditorMode]
    public void Interact()
    {
      StartCoroutine(DoEnter());

      IEnumerator DoEnter()
      {
        _onBeforeTeleportation?.Invoke();
        yield return Blackout.Show();
        _body.position = _targetPosition.position;
        yield return Blackout.Hide();
        _onAfterTeleportation?.Invoke();
      }
    }
  }
}