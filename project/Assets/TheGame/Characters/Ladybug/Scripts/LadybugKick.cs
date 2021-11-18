using TheGame.Core.Animations.Attributes;
using TheGame.Core.Common.Utils;
using UnityEngine;

namespace TheGame.Characters.Ladybug
{
    public class LadybugKick : AnimatorStateAttributeBehaviour
    {
        [SerializeField] private LayerMask _kickableLayers;
        [SerializeField] private LadybugKickAnimationsEvents _animationsEvents;
        [SerializeField] private Collider2D _kickArea;
        [SerializeField] private Transform _kickPoint;
        [SerializeField] private float _force;
        [SerializeField] private float _upwardsModifier;

        private readonly Collider2D[] _overlappedColliders = new Collider2D[5];

        private void Start() =>
            _animationsEvents.OnKick += DoKick;

        private void OnDestroy() =>
            _animationsEvents.OnKick -= DoKick;

        private void DoKick()
        {
            int overlapCount = _kickArea.OverlapCollider(new ContactFilter2D().NoFilter(), _overlappedColliders);
            if (overlapCount == 0) return;

            for (int i = 0; i < overlapCount; i++)
            {
                Rigidbody2D body = _overlappedColliders[i].GetComponent<Rigidbody2D>();
                if (body == null) continue;
                if (_kickableLayers != (_kickableLayers | (1 << body.gameObject.layer))) continue;

                body.AddExplosionForce(_force, _kickPoint.position, _upwardsModifier, ForceMode2D.Impulse);
            }
        }
    }
}