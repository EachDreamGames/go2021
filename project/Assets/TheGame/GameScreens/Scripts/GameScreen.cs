using TheGame.Core.Animations.Attributes;
using UnityEngine;

namespace TheGame.GameScreens
{
  public class GameScreen : AnimatorStateAttributeBehaviour
  {
    [SerializeField] private GameObject _prefab;
    [SerializeField] private bool _mustUnload;

    private GameObject _instance;
    private GameObject Instance => _instance ? _instance : _instance = MakeInstance();

    protected override void OnStateActivate() =>
      Instance.SetActive(true);

    protected override void OnStateDeactivate()
    {
      Instance.SetActive(false);
      if (!_mustUnload) return;

      Destroy(_instance);
    }

    private GameObject MakeInstance()
    {
      GameObject instance = Instantiate(_prefab, transform, true);
      instance.name = nameof(Instance);
      return instance;
    }
  }
}