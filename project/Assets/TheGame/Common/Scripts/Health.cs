using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace TheGame.Common
{
  public class Health : MonoBehaviour
  {
    [SerializeField, MinValue(0)] private int _maxValue;

    [SerializeField, PropertyRange(0, "$" + nameof(_maxValue))]
    private int _currentValue;

    [SerializeField] private IntUnityEvent _onModified;

    public void Modify(int delta)
    {
      int newValue = Math.Max(0, Math.Min(_currentValue + delta, _maxValue));
      if (_currentValue == newValue) return;
      _currentValue = newValue;

      _onModified?.Invoke(_currentValue);
    }

    public void Decrease(int value)
    {
      if (value <= 0) return;
      Modify(-value);
    }

    public void Increase(int value)
    {
      if (value <= 0) return;
      Modify(value);
    }

    [Serializable]
    private class IntUnityEvent : UnityEvent<int>
    {
    }
  }
}