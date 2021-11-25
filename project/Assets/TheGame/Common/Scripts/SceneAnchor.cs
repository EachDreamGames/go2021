using Sirenix.OdinInspector;
using UnityEngine;

namespace TheGame.Common
{
  [AssetSelector]
  [CreateAssetMenu(fileName = "NewSceneAnchor", menuName = "SceneAnchor")]
  public class SceneAnchor : ScriptableObject
  {
    [ReadOnly] public Transform Transform;
  }
}