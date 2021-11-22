using System;
using UnityEngine;

namespace TheGame.Characters.Ladybug
{
  public class LadybugSpitLaunchAnimationsEvents : MonoBehaviour
  {
    public event Action OnSpitLaunch;

    public void InvokeOnSpitLaunchEvent() =>
      OnSpitLaunch?.Invoke();
  }
}