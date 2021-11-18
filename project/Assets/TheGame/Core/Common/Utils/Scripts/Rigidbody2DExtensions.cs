using UnityEngine;

namespace TheGame.Core.Common.Utils
{
    public static class Rigidbody2DExtensions
    {
        /// <summary>
        ///   Логика скопирована из https://stackoverflow.com/a/34252052
        /// </summary>
        public static void AddExplosionForce(this Rigidbody2D body, float force, Vector2 position,
            float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Force)
        {
            Vector2 direction = body.position - position;
            float distance = direction.magnitude;

            // Normalize without computing magnitude again
            if (upwardsModifier == 0)
                direction /= distance;
            else
            {
                // From Rigidbody.AddExplosionForce doc:
                // If you pass a non-zero value for the upwardsModifier parameter, the direction
                // will be modified by subtracting that value from the Y component of the centre point.
                direction.y += upwardsModifier;
                direction.Normalize();
            }

            body.AddForce(Mathf.Lerp(0, force, 1 - distance) * direction, mode);
        }
    }
}