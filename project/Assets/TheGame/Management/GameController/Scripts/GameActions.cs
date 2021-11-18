using UnityEngine;

namespace TheGame.Management.GameController
{
  public class GameActions : MonoBehaviour
  {
    [SerializeField] private GameController _gameController;

    private void Start() =>
      _gameController = _gameController ? _gameController : FindObjectOfType<GameController>();

    public void StartNewGame() =>
      _gameController.StartNewGame();

    public void ContinueGame() =>
      _gameController.ContinueGame();

    public void ShowSettings() =>
      _gameController.ShowSettings();

    public void ShowHelp() =>
      _gameController.ShowHelp();

    public void ShowCredits() =>
      _gameController.ShowCredits();

    public void ExitGame() =>
      _gameController.ExitGame();

    public void StartLevel(LevelDescription description) =>
      _gameController.StartLevel(description);

    public void RestartCurrentLevel() =>
      _gameController.StartLevel(_gameController.CurrentLevel);
  }
}