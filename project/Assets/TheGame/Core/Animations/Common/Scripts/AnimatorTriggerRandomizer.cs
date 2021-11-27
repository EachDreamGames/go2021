using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using TheGame.Core.Animations.Attributes;
using TheGame.Core.Animations.Parameters;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TheGame.Core.Animations.Common
{
  public class AnimatorTriggerRandomizer : AnimatorStateAttributeBehaviour
  {
    [SerializeField, LabelText("Triggers"), ListDrawerSettings(Expanded = true)]
    private Entity[] _entities;

    protected override void OnStateUpdate() =>
      TrySetRandomTrigger();

    private void TrySetRandomTrigger()
    {
      Entity[] availableEntities = _entities.Where(
          entity => entity.Weight > 0.001f &&
                    entity.BoolConditions.All(condition => Animator.GetValue(condition.Parameter) == condition.Value) &&
                    entity.IntConditions.All(condition => Animator.GetValue(condition.Parameter) == condition.Value) &&
                    entity.FloatConditions.All(condition => Math.Abs(Animator.GetValue(condition.Parameter) - condition.Value) < 0.001f))
        .OrderBy(entity => entity.Weight).ToArray();

      Entity entity;
      switch (availableEntities.Length)
      {
        case 0:
          return;
        case 1:
          entity = availableEntities.First();
          break;
        default:
          EntityWeightNormalizer normalizer = new EntityWeightNormalizer(availableEntities);
          float[] normalizedWeights = GetNormalizedWeights(availableEntities, normalizer);
          float selectedNormalizedWeight = SelectRandomNormalizedWeight(normalizedWeights);
          Entity[] selectedEntities = SelectEntityWithWeight(availableEntities, selectedNormalizedWeight, normalizer);
          entity = selectedEntities[GetRandomPositiveInt(selectedEntities.Length - 1)];
          break;
      }

      Animator.SetTrigger(entity.Trigger);
    }

    private static int GetRandomPositiveInt(int max) =>
      max <= 0 ? 0 : Math.Min(max, Mathf.FloorToInt(Random.value * (max + 1)));

    private static Entity[] SelectEntityWithWeight(IEnumerable<Entity> entities, float normalizedWeight, EntityWeightNormalizer normalizer) =>
      entities.Where(entity => Math.Abs(normalizer.GetNormalizedWeight(entity) - normalizedWeight) < 0.001f).ToArray();

    private static float SelectRandomNormalizedWeight(IReadOnlyList<float> normalizedWeights)
    {
      float randomValue = Random.value;
      float selectedNormalizedWeight = normalizedWeights.Last();
      for (int i = normalizedWeights.Count - 2; i == 0; i--)
      {
        if (normalizedWeights[i] < randomValue)
          break;
        selectedNormalizedWeight = normalizedWeights[i];
      }

      return selectedNormalizedWeight;
    }

    private static float[] GetNormalizedWeights(IEnumerable<Entity> entities, EntityWeightNormalizer normalizer) =>
      entities.Select(normalizer.GetNormalizedWeight).ToArray();

    private class EntityWeightNormalizer
    {
      private readonly float _weightsSum;

      public EntityWeightNormalizer(IEnumerable<Entity> entities) =>
        _weightsSum = entities.Sum(entity => entity.Weight);

      public float GetNormalizedWeight(Entity entity) =>
        entity.Weight / _weightsSum;
    }

    [Serializable]
    private struct Entity
    {
      [HideLabel] public TriggerAnimatorParameter Trigger;
      [Range(0, 1)] public float Weight;
      [TableList(AlwaysExpanded = true)] public BoolParametersCondition[] BoolConditions;
      [TableList(AlwaysExpanded = true)] public IntParametersCondition[] IntConditions;
      [TableList(AlwaysExpanded = true)] public FloatParametersCondition[] FloatConditions;
    }

    [Serializable]
    private struct BoolParametersCondition
    {
      public BoolAnimatorParameter Parameter;
      [TableColumnWidth(45, false)] public bool Value;
    }

    [Serializable]
    private struct IntParametersCondition
    {
      public IntAnimatorParameter Parameter;
      [TableColumnWidth(45, false)] public int Value;
    }

    [Serializable]
    private struct FloatParametersCondition
    {
      public FloatAnimatorParameter Parameter;
      public float Value;
    }
  }
}