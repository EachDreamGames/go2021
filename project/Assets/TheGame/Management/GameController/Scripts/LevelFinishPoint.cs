using TheGame.Core.Common;
using UnityEngine;

namespace TheGame.Management.GameController
{
  public class LevelFinishPoint : MonoBehaviour, IInteractable
  {
    [SerializeField] private LevelController _levelController;
    [SerializeField] private LevelDescription _nextLevelDescription;

    public void Interact() =>
      _levelController.StartNextLevel(_nextLevelDescription);
  }
}