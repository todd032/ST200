using UnityEngine;

namespace WindGuardian
{
    class WalkComponent : MonoBehaviour
    {
        public Vector2 velocity;

        public void Start()
        {
            velocity.Set(10.0f, 0.0f);
        }
    }
}
