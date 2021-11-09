using UnityEngine;

namespace TheGame.Levels.Scripts
{
  public class LevelController : MonoBehaviour
  {
    private State _state;

    public bool IsLevelStarted => _state != State.None;

    public void LevelPause() => 
      _state = State.Paused;

    public void LevelResume() => 
      _state = State.Started;

    public void LevelStart() => 
      _state = State.Started;

    private enum State
    {
      None,
      Started,
      Paused
    }
  }
}