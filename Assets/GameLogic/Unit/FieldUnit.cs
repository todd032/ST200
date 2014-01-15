using System.Collections;
using UnityEngine;

namespace WindGuardian
{
    public class FieldUnit : MonoBehaviour {
        private bool girlSkin;
        ACTION_STATE actionState;
        DIRECTION_STATE directionState;
        bool onGround;

        private Vector2 moveSpeed;

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
            moveSpeed.Set(10, 0);
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

        public void OnControllerColliderHit(ControllerColliderHit collision)
        {
            onGround = true;
            GetComponent<Transform>().Rotate(0.0f, 180.0f, 0.0f);
        }

        public void LogicUpdate(double dt)
        {
            SkeletonAnimation skeletonAnimation = GetComponent<SkeletonAnimation>();
            var trans = GetComponent<Transform>();

            Vector3 dMove = new Vector3(0, 0, 0);

            // Keydown
            if (Input.GetKeyDown("right"))
            {
                skeletonAnimation.state.SetAnimation(0, "walk", true);
                if(directionState == DIRECTION_STATE.DS_LEFT)
                {
                    GetComponent<Transform>().Rotate(0.0f, 180.0f, 0.0f);
                }

                actionState = ACTION_STATE.AS_WALK_RIGHT;
                directionState = DIRECTION_STATE.DS_RIGHT;
            }
            else if(Input.GetKeyDown("left"))
            {
                skeletonAnimation.state.SetAnimation(0, "walk", true);
                if (directionState == DIRECTION_STATE.DS_RIGHT)
                {
                    GetComponent<Transform>().Rotate(0.0f, 180.0f, 0.0f);
                }

                actionState = ACTION_STATE.AS_WALK_LEFT;
                directionState = DIRECTION_STATE.DS_LEFT;
            }
            else if(Input.GetKeyDown("space"))
            {
                if(onGround == true)
                {
                    GetComponent<CharacterController>().velocity.Set(0.0f, -900.8f, 0.0f);
                    onGround = false;
                }
            }
            // Keypress
            else if (Input.GetKey("right"))
            {
                dMove.Set(moveSpeed.x, moveSpeed.y, 0);
                actionState = ACTION_STATE.AS_WALK_RIGHT;
                directionState = DIRECTION_STATE.DS_RIGHT;
            }
            else if(Input.GetKey("left"))
            {
                dMove.Set(moveSpeed.x, moveSpeed.y, 0);
                actionState = ACTION_STATE.AS_WALK_LEFT;
                directionState = DIRECTION_STATE.DS_LEFT;
            }
            // Keyup
            else if(Input.GetKeyUp("right"))
            {
                actionState = ACTION_STATE.AS_STAND;
            }
            else if(Input.GetKeyUp("left"))
            {
                actionState = ACTION_STATE.AS_STAND;
            }
            else
            {
                skeletonAnimation.state.ClearTracks();
            }

            trans.Translate(dMove);

            foreach (GameComponent comp in components)
            {
                comp.OnUpdate(dt);
            }
        }

        public void Update()
        {
            LogicUpdate(0);
        }

        public void AddGameComponent(GameComponent comp)
        {
            comp.OnEquip(this);
            components.Add(comp);
        }
        public void RemoveGameComponent(GameComponent comp)
        {
            if(components.Contains(comp) == true)
            {
                comp.OnUnequip();
                components.Remove(comp);
            }
        }

        private ArrayList components = new ArrayList();
    }
}