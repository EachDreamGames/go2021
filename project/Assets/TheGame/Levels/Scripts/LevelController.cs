using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheGame.Levels.Scripts
{
  public class LevelController : MonoBehaviour
  {
    [SerializeField] private AudioListener _audioListener;

    private LevelState _state;

    private LevelState State
    {
      get => _state;
      set
      {
        if (value == _state) return;
        _state = value;

        switch (_state)
        {
          case LevelState.None:
            break;
          case LevelState.Started:
            Time.timeScale = 1;
            _audioListener.enabled = true;
            break;
          case LevelState.Paused:
            Time.timeScale = 0;
            _audioListener.enabled = false;
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
      }
    }

    public bool IsLevelStarted => State != LevelState.None;

    public void LevelPause() =>
      State = LevelState.Paused;

    public void LevelResume() =>
      State = LevelState.Started;

    public void LevelStart() =>
      State = LevelState.Started;

    public void LevelRestart() =>
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    private enum LevelState
    {
      None,
      Started,
      Paused
    }
  }
}