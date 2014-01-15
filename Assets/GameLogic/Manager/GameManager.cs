using System.Collections;
using System.Timers;
using UnityEngine;

namespace WindGuardian
{
    public class GameManager : MonoBehaviour
    {
        public void Initialize()
        {
            lastTime = System.DateTime.UtcNow;
            world.Initialize();
        }
        public void Update()
        {
            ArrayList fieldUnits = world.GetFieldUnits();

            var currentTime = System.DateTime.UtcNow;
            System.TimeSpan dt = currentTime - lastTime;
            lastTime = currentTime;

            foreach(UnityEngine.GameObject unit in fieldUnits)
            {
                unit.GetComponent<FieldUnit>().LogicUpdate(dt.TotalMilliseconds);
            }
        }

        private System.DateTime lastTime;
        private World world = new World();
    }
}