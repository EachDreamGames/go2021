using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace TheGame.Core.Common
{
  public class Timer : MonoBehaviour
  {
    [SerializeField] private float _interval;
    [SerializeField] private bool _isRepeatable;
    [SerializeField] private bool _autoStart;
    [SerializeField] private UnityEvent _onTimer;

    private Coroutine _invocation;

    private void Start()
    {
      if (_autoStart)
        StartTimer();
    }

    private IEnumerator InvokeTimer()
    {
      do
      {
        if (_interval > 0)
          yield return new WaitForSeconds(_interval);
        _onTimer?.Invoke();
      } while (_isRepeatable);
    }

    public void StartTimer()
    {
      StopTimer();
      _invocation = StartCoroutine(InvokeTimer());
    }

    public void StopTimer()
    {
      if (_invocation == null) return;

      StopCoroutine(_invocation);
      _invocation = null;
    }
  }
}