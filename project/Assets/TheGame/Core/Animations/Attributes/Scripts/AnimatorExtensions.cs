using System;
using System.Collections;
using System.Collections.Generic;
using TheGame.Core.Common.Utils;
using UnityEngine;

namespace TheGame.Core.Animations.Attributes
{
  internal static class AnimatorExtensions
  {
    public static Attributes GetAttributes(this Animator animator) =>
      animator.GetOrAddSibling<Attributes>();

    public class Attributes : MonoBehaviour
    {
      public delegate void StateAttributeChangedEvent(AnimatorStateAttribute attribute, bool isActive);

      private readonly Dictionary<AnimatorStateAttribute, int> _counters = new Dictionary<AnimatorStateAttribute, int>();
      private readonly Dictionary<AnimatorStateAttribute, int> _prevCounters = new Dictionary<AnimatorStateAttribute, int>();
      private Animator _animator;

      public event StateAttributeChangedEvent OnChanged;

      private void Start()
      {
        _animator = GetComponent<Animator>();
        StartCoroutine(UpdateAttributes(_animator.updateMode));
      }

      private void OnDestroy() =>
        StopAllCoroutines();

      public void Add(AnimatorStateAttribute attribute)
      {
        if (!_counters.ContainsKey(attribute))
          _counters[attribute] = 0;

        _counters[attribute]++;
      }

      public void Remove(AnimatorStateAttribute attribute) =>
        _counters[attribute]--;

      public bool IsActive(AnimatorStateAttribute attribute) =>
        _counters.TryGetValue(attribute, out int count) && count > 0;

      private IEnumerator UpdateAttributes(AnimatorUpdateMode animatorUpdateMode)
      {
        while (enabled)
        {
          yield return animatorUpdateMode switch
          {
            AnimatorUpdateMode.Normal => null,
            AnimatorUpdateMode.AnimatePhysics => new WaitForFixedUpdate(),
            AnimatorUpdateMode.UnscaledTime => new WaitForEndOfFrame(),
            _ => throw new ArgumentOutOfRangeException(nameof(animatorUpdateMode), animatorUpdateMode, null)
          };

          foreach (KeyValuePair<AnimatorStateAttribute, int> pair in _counters)
          {
            AnimatorStateAttribute attribute = pair.Key;
            int count = pair.Value;
            bool isCountNotZero = count > 0;

            if (!_prevCounters.ContainsKey(attribute))
              _prevCounters[attribute] = 0;

            bool isPrevCountNotZero = _prevCounters[attribute] > 0;
            _prevCounters[attribute] = count;

            if (isCountNotZero == isPrevCountNotZero) continue;

            OnChanged?.Invoke(attribute, isCountNotZero);
          }
        }
      }
    }
  }
}