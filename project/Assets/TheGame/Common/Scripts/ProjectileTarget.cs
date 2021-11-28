using System;
using UnityEngine;
using UnityEngine.Events;

namespace TheGame.Common
{
  public class ProjectileTarget : MonoBehaviour
  {
    [SerializeField] private IntUnityEvent _onGetImpact;

    public void GetImpact(int strength) =>
      _onGetImpact?.Invoke(strength);

    [Serializable]
    private class IntUnityEvent : UnityEvent<int>
    {
    }
  }
}