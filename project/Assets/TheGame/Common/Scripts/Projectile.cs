using UnityEngine;

namespace TheGame.Common
{
  public class Projectile : MonoBehaviour
  {
    [SerializeField] private Rigidbody2D _body;

    private void Start() =>
      _body.simulated = false;

    public void Launch(Vector2 startVelocity, Vector2 impulse)
    {
      _body.simulated = true;
      _body.velocity = startVelocity;
      _body.AddForce(impulse, ForceMode2D.Impulse);
    }
  }
}