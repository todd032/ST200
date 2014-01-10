using System.Collections;
using System.Timers;

namespace WindGuardian
{
    public class GameManager
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
                unit.GetComponent<FieldUnit>().Update(dt.TotalMilliseconds);
            }
        }

        private System.DateTime lastTime;
        private World world = new World();
    }
}