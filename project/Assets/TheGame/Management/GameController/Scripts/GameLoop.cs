using TheGame.Core.Animations.Attributes;
using TheGame.Levels.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheGame.Management.GameController.Scripts
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

      SceneManager.SetActiveScene(LevelScene);
    }

    protected override void OnStateDeactivate()
    {
      SceneManager.SetActiveScene(MenuScene);
      _levelController.LevelPause();
      _audioListener.enabled = enabled;
    }

    private Scene LevelScene =>
      _levelController.gameObject.scene;

    private Scene MenuScene =>
      gameObject.scene;
  }
}