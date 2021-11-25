using Sirenix.OdinInspector;
using UnityEngine;

namespace TheGame.Common
{
  [CreateAssetMenu(fileName = "NewStaticTargetContainer", menuName = "StaticTargetContainer")]
  public class StaticTargetContainer : ScriptableObject
  {
    [ReadOnly] public GameObject Target;
  }
}