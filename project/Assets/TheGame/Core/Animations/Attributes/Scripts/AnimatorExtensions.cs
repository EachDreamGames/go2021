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

      public event StateAttributeChangedEvent OnChanged;

      private void Start() =>
        StartCoroutine(UpdateAttributes());

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

      private IEnumerator UpdateAttributes()
      {
        while (enabled)
        {
          yield return new WaitForFixedUpdate();

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