using Sirenix.OdinInspector;
using TheGame.Core.Animations.Attributes;
using UnityEngine;

namespace TheGame.Management.GameController
{
  public class GameScreenController : AnimatorStateAttributeBehaviour
  {
    [SerializeField, AssetsOnly] private GameObject _prefab;
    [SerializeField] private bool _mustUnload;

    private GameObject _gameScreen;
    private GameObject Instance => _gameScreen ? _gameScreen : _gameScreen = MakeInstance();

    protected override void OnStateActivate() =>
      Instance.gameObject.SetActive(true);

    protected override void OnStateDeactivate()
    {
      Instance.gameObject.SetActive(false);
      if (!_mustUnload) return;

      Destroy(_gameScreen);
    }

    private GameObject MakeInstance()
    {
      GameObject instance = Instantiate(_prefab, transform, true);
      instance.name = nameof(Instance);
      return instance;
    }
  }
}