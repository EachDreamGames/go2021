using TheGame.Core.Animations.Attributes;
using TheGame.Levels.Scripts;
using UnityEngine;

namespace TheGame.Management.GameController
{
  public class GameLoop : AnimatorStateAttributeBehaviour
  {
    [SerializeField] private AudioListener _audioListener;

    private LevelController _levelController;

    protected override void OnStateActivate()
    {
      _audioListener.enabled = false;

      _levelController = FindObjectOfType<LevelController>();
      if (_levelController.IsLevelStarted)
        _levelController.LevelResume();
      else
        _levelController.LevelStart();
    }

    protected override void OnStateDeactivate()
    {
      _levelController.LevelPause();
      _audioListener.enabled = enabled;
    }
  }
}