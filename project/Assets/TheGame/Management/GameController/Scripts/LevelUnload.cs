using TheGame.Core.Animations.Attributes;
using TheGame.Core.Animations.Parameters;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheGame.Management.GameController
{
  public class LevelUnload : AnimatorStateAttributeBehaviour
  {
    [SerializeField] private BoolAnimatorParameter _isLevelLoaded;

    private void Start() =>
      SceneManager.sceneUnloaded += LevelUnloaded;

    protected override void OnStateActivate() =>
      SceneManager.UnloadSceneAsync(LevelLoad.LoadedScene);

    private void LevelUnloaded(Scene scene)
    {
      if (!IsStateActive) return;

      Animator.SetValue(_isLevelLoaded, false);
    }
  }
}