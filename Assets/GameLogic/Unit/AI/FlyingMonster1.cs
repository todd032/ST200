using UnityEngine;
namespace WindGuardian
{
    class FlyingMonster1 : MonoBehaviour
    {
        readonly private float changeTime = 5.0f;
        private float cooltime;
        private Vector2 direction;

        public void Start()
        {
            cooltime = changeTime;
            direction.Set(1.0f, 0.0f);
        }

        public void Update()
        {
            float dt = Time.deltaTime;
            var velocity = GetComponent<FlyComponent>().velocity;

            var trans = GetComponent<Transform>();
            trans.Translate(velocity.x * direction.x * dt,
                velocity.y * direction.y * dt,
                0);

            cooltime -= dt;

            if(cooltime <= 0.0f)
            {
                cooltime = changeTime;
                //direction = direction * -1;
                trans.Rotate(0.0f, 180, 0.0f);
            }
        }
    }
}
