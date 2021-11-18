using TheGame.Core.Animations.Attributes;
using TheGame.Core.Animations.Parameters;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheGame.Management.GameController
{
  public class LevelLoad : AnimatorStateAttributeBehaviour
  {
    [SerializeField] private GameController _gameController;
    [SerializeField] private BoolAnimatorParameter _isLevelLoadedParameter;

    private void Start() =>
      SceneManager.sceneLoaded += LevelLoaded;

    protected override void OnStateActivate()
    {
      Animator.SetValue(_isLevelLoadedParameter, false);
      SceneManager.LoadSceneAsync(_gameController.CurrentLevel.SceneName);
    }

    private void LevelLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
      if (!IsStateActive) return;

      Animator.SetValue(_isLevelLoadedParameter, true);
    }
  }
}