using UnityEngine;

namespace TheGame.Core.Common
{
  
  
  public class GameObjectDestroyer : MonoBehaviour
  {
    [SerializeField] private GameObject _gameObject;

    public void DestroyGameObject() => 
      Destroy(_gameObject);
  }
}