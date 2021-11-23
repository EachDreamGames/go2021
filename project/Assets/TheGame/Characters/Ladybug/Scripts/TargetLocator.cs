using UnityEngine;

namespace TheGame.Characters.Ladybug
{
  public abstract class TargetLocator : MonoBehaviour
  {
    public abstract GameObject Target { get; }
  }
}