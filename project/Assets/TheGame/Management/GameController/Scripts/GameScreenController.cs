using TheGame.Core.Animations.Attributes;
using TheGame.GameScreens;
using UnityEngine;
using UnityEngine.Events;

namespace TheGame.Management.GameController.Scripts
{
  public class GameScreenController : AnimatorStateAttributeBehaviour
  {
    [SerializeField] private GameScreen _prefab;
    [SerializeField] private bool _mustUnload;
    [SerializeField] private UnityEvent _onAnyKey;
    [SerializeField] private UnityEvent _onClose;

    private GameScreen _gameScreen;
    private GameScreen GameScreen => _gameScreen ? _gameScreen : _gameScreen = MakeInstance();

    protected override void OnStateActivate() =>
      GameScreen.gameObject.SetActive(true);

    protected override void OnStateDeactivate()
    {
      GameScreen.OnAnyKey -= AnyKeyGameScreen;
      GameScreen.OnClose -= CloseGameScreen;
      GameScreen.gameObject.SetActive(false);
      if (!_mustUnload) return;

      Destroy(_gameScreen);
    }

    private GameScreen MakeInstance()
    {
      GameScreen instance = Instantiate(_prefab, transform, true);
      instance.name = nameof(GameScreen);
      instance.OnAnyKey += AnyKeyGameScreen;
      instance.OnClose += CloseGameScreen;
      return instance;
    }

    private void AnyKeyGameScreen() => 
      _onAnyKey?.Invoke();

    private void CloseGameScreen() => 
      _onClose?.Invoke();
  }
}