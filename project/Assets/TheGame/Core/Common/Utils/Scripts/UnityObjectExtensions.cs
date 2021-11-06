using System;
using UnityEngine;

namespace TheGame.Core.Common.Utils
{
  public static class UnityObjectExtensions
  {
    public static TComponent AddComponent<TComponent>(this GameObject gameObject, Action<TComponent> onAdded) where TComponent : Component
    {
      TComponent component = gameObject.AddComponent<TComponent>();
      onAdded?.Invoke(component);
      return component;
    }

    public static TComponent AddSibling<TComponent>(this Component component, Action<TComponent> onAdded = null) where TComponent : Component =>
      component.gameObject.AddComponent(onAdded);

    public static TComponent GetOrAddComponent<TComponent>(this GameObject gameObject, Action<TComponent> onAdded = null) where TComponent : Component =>
      gameObject.TryGetComponent(out TComponent result) ? result : gameObject.AddComponent(onAdded);

    public static TComponent GetOrAddSibling<TComponent>(this Component component, Action<TComponent> onAdded = null) where TComponent : Component =>
      component.gameObject.GetOrAddComponent(onAdded);
  }
}