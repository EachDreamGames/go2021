using TheGame.Core.Animations.Attributes;
using TheGame.Levels.Scripts;

namespace TheGame.Management.GameController.Scripts
{
  public class GameLoop : AnimatorStateAttributeBehaviour
  {
    private LevelController _levelController;
    
    protected override void OnStateActivate()
    {
      _levelController = FindObjectOfType<LevelController>();
      if (_levelController.IsLevelStarted)
        _levelController.LevelResume();
      else
        _levelController.LevelStart();
    }

    protected override void OnStateDeactivate()
    {
      _levelController.LevelPause();
    }
  }
}