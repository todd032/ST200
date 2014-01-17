using System.Collections;
using UnityEngine;

namespace WindGuardian
{
    class Player : FieldUnit
    {
        private bool girlSkin;
        ACTION_STATE actionState;
        DIRECTION_STATE directionState;
        bool onGround;

        public enum ACTION_STATE
        {
            AS_STAND,
            AS_WALK_LEFT,
            AS_WALK_RIGHT,
        }
        public enum DIRECTION_STATE
        {
            DS_LEFT,
            DS_RIGHT
        }

        public void Start()
        {
            actionState = ACTION_STATE.AS_STAND;
            directionState = DIRECTION_STATE.DS_RIGHT;
            onGround = true;
        }

        public void OnMouseDown()
        {
            SkeletonAnimation skeletonAnimation = GetComponent<SkeletonAnimation>();
            skeletonAnimation.skeleton.SetSkin(girlSkin ? "goblin" : "goblingirl");
            skeletonAnimation.skeleton.SetSlotsToSetupPose();

            girlSkin = !girlSkin;

            if (girlSkin)
            {
                skeletonAnimation.skeleton.SetAttachment("right hand item", null);
                skeletonAnimation.skeleton.SetAttachment("left hand item", "spear");
            }
            else
            {
                skeletonAnimation.skeleton.SetAttachment("left hand item", "dagger");
            }
        }

        public void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.GetComponent<FloorWall>() != null)
            {
                onGround = true;
            }
        }

        public override void LogicUpdate(double dt)
        {
            SkeletonAnimation skeletonAnimation = GetComponent<SkeletonAnimation>();
            var trans = GetComponent<Transform>();
            var walk = GetComponent<WalkComponent>();

            Vector3 dMove = new Vector3(0, 0, 0);

            // Keydown
            if (Input.GetKeyDown("right"))
            {
                skeletonAnimation.state.SetAnimation(0, "walk", true);
                if (directionState == DIRECTION_STATE.DS_LEFT)
                {
                    trans.Rotate(0.0f, 180.0f, 0.0f);
                }

                actionState = ACTION_STATE.AS_WALK_RIGHT;
                directionState = DIRECTION_STATE.DS_RIGHT;
            }
            else if (Input.GetKeyDown("left"))
            {
                skeletonAnimation.state.SetAnimation(0, "walk", true);
                if (directionState == DIRECTION_STATE.DS_RIGHT)
                {
                    trans.Rotate(0.0f, 180.0f, 0.0f);
                }

                actionState = ACTION_STATE.AS_WALK_LEFT;
                directionState = DIRECTION_STATE.DS_LEFT;
            }
            else if (Input.GetKeyDown("z"))
            {
                if (onGround == true)
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10000000000.0f));
                    onGround = false;
                }
            }
            // Keypress
            else if (Input.GetKey("right"))
            {
                dMove.Set(walk.velocity.x, walk.velocity.y, 0);
                actionState = ACTION_STATE.AS_WALK_RIGHT;
                directionState = DIRECTION_STATE.DS_RIGHT;
            }
            else if (Input.GetKey("left"))
            {
                dMove.Set(walk.velocity.x, walk.velocity.y, 0);
                actionState = ACTION_STATE.AS_WALK_LEFT;
                directionState = DIRECTION_STATE.DS_LEFT;
            }
            // Keyup
            else if (Input.GetKeyUp("right"))
            {
                actionState = ACTION_STATE.AS_STAND;
            }
            else if (Input.GetKeyUp("left"))
            {
                actionState = ACTION_STATE.AS_STAND;
            }
            else
            {
                skeletonAnimation.state.ClearTracks();
            }

            trans.Translate(dMove);
        }

        public void Update()
        {
            LogicUpdate(0);
        }
    }
}