using UnityEngine;

namespace TheGame.Core.Common
{
  public class DontDestroyOnLoad : MonoBehaviour
  {
    private void Start() => 
      DontDestroyOnLoad(gameObject);
  }
}