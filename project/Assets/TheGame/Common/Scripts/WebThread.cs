using Sirenix.OdinInspector;
using UnityEngine;

namespace TheGame.Common
{
  public class WebThread : MonoBehaviour
  {
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;

    [Button]
    private void Update()
    {
      Vector2 startPointPosition = _startPoint.position;
      Vector2 endPointPosition = _endPoint.position;

      Vector2 webThreadVector = startPointPosition - endPointPosition;
      Vector2 webThreadDirection = webThreadVector.normalized;

      float angle = Mathf.Atan2(webThreadDirection.y, webThreadDirection.x) * Mathf.Rad2Deg - 90;
      
      transform.position = startPointPosition;
      // ReSharper disable once Unity.InefficientPropertyAccess
      transform.eulerAngles = new Vector3(0, 0, angle);
      _renderer.size = new Vector2(_renderer.size.x, webThreadVector.magnitude);
    }

    public void SetStartPoint(Transform value) =>
      _startPoint = value;

    public void SetEndPoint(Transform value) =>
      _endPoint = value;
  }
}