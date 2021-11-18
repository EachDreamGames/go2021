using UnityEngine;

namespace TheGame.Management.GameController
{
  [CreateAssetMenu(fileName = "NewLevelDescription", menuName = "LevelDescription")]
  public class LevelDescription : ScriptableObject
  {
    [SerializeField] private string _sceneName;

    public string SceneName => _sceneName;
  }
}