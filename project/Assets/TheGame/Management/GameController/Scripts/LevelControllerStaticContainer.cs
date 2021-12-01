using Sirenix.OdinInspector;
using UnityEngine;

namespace TheGame.Management.GameController
{
    [AssetSelector]
    [CreateAssetMenu(fileName = "NewLevelControllerStaticContainer", menuName = "LevelControllerStaticContainer")]
    public class LevelControllerStaticContainer : ScriptableObject
    {
        [ReadOnly] public LevelController LevelController;
    }
}