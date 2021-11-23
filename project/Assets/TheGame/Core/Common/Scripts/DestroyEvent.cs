using System;
using UnityEngine;

namespace TheGame.Core.Common
{
  public class DestroyEvent : MonoBehaviour
  {
    public event Action OnDestroyEvent;

    private void OnDestroy() => 
      OnDestroyEvent?.Invoke();
  }
}