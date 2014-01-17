using UnityEngine;

namespace WindGuardian
{
    class FlyComponent : MonoBehaviour
    {
        public Vector2 velocity;

        public void Start()
        {
            velocity.Set(100.0f, 0.0f);
            GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        }
    }
}