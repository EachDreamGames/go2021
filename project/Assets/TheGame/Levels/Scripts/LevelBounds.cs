using TheGame.Management.GameController;
using UnityEngine;

namespace TheGame.Levels.Scripts
{
  [RequireComponent(typeof(Collider2D))]
  public class LevelBounds : MonoBehaviour
  {
    [SerializeField] private LevelController _levelController;

    private void OnTriggerEnter2D(Collider2D _) =>
      _levelController.LevelRestart();
  }
}