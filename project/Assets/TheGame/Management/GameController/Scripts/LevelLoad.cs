using TheGame.Core.Animations.Attributes;
using TheGame.Core.Animations.Parameters;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheGame.Management.GameController
{
  public class LevelLoad : AnimatorStateAttributeBehaviour
  {
    [SerializeField] private BoolAnimatorParameter _isLevelLoaded;

    private const string FirstLevelScene = "TheGame/Levels/Scenes/Level-1";

    public static Scene LoadedScene;

    private void Start() =>
      SceneManager.sceneLoaded += LevelLoaded;

    protected override void OnStateActivate() =>
      SceneManager.LoadSceneAsync(FirstLevelScene, LoadSceneMode.Additive);

    private void LevelLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
      if (!IsStateActive) return;

      Animator.SetValue(_isLevelLoaded, true);
      LoadedScene = scene;
    }
  }
}