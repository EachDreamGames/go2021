using UnityEngine;

namespace TheGame.Common
{
  public abstract class TargetLocator : MonoBehaviour
  {
    public abstract GameObject Target { get; }
  }
}