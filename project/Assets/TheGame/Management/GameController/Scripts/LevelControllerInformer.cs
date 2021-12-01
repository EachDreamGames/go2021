using UnityEngine;

namespace TheGame.Management.GameController
{
    public class LevelControllerInformer : MonoBehaviour
    {
        [SerializeField] private LevelController _levelController;
        [SerializeField] private LevelControllerStaticContainer _staticContainer;
        private void OnEnable() =>
            _staticContainer.LevelController = _levelController;

        private void OnDisable()
        {
            if (_staticContainer.LevelController == _levelController)
                _staticContainer.LevelController = null;
        }
    }
}