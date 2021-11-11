using TheGame.Core.Animations.Attributes;
using TheGame.GameScreens;
using UnityEngine;

namespace TheGame.Management.GameController
{
  public class GameScreenController : AnimatorStateAttributeBehaviour
  {
    [SerializeField] private GameScreen _prefab;
    [SerializeField] private bool _mustUnload;

    private GameScreen _gameScreen;
    private GameScreen GameScreen => _gameScreen ? _gameScreen : _gameScreen = MakeInstance();

    protected override void OnStateActivate() =>
      GameScreen.gameObject.SetActive(true);

    protected override void OnStateDeactivate()
    {
      GameScreen.gameObject.SetActive(false);
      if (!_mustUnload) return;

      Destroy(_gameScreen);
    }

    private GameScreen MakeInstance()
    {
      GameScreen instance = Instantiate(_prefab, transform, true);
      instance.name = nameof(GameScreen);
      return instance;
    }
  }
}