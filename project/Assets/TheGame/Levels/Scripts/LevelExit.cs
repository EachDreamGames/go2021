using TheGame.Management.GameController;
using UnityEngine;

namespace TheGame.Levels.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class LevelExit : MonoBehaviour
    {
        [SerializeField] private LevelController _levelController;
        [SerializeField] private LevelDescription _nextLevel;

        private void OnTriggerEnter2D(Collider2D _) =>
            _levelController.StartNextLevel(_nextLevel);
    }
}