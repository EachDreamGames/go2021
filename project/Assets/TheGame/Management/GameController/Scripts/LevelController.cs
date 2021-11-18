using System;
using System.Collections;
using TheGame.Core.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheGame.Management.GameController
{
  public class LevelController : MonoBehaviour
  {
    [SerializeField] private AudioListener _audioListener;
    [SerializeField] private GameActions _gameActions;

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
            StartCoroutine(Blackout.Hide());
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
    
    public void StartNextLevel(LevelDescription description)
    {
      StartCoroutine(DoStart());

      IEnumerator DoStart()
      {
        yield return Blackout.Show();
        _gameActions.StartLevel(description);
      }
    }

    private enum LevelState
    {
      None,
      Started,
      Paused
    }
  }
}