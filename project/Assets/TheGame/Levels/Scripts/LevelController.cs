using System;
using UnityEngine;

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
            _audioListener.enabled = true;
            break;
          case LevelState.Paused:
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

    private enum LevelState
    {
      None,
      Started,
      Paused
    }
  }
}