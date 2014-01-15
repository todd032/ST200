using System.Collections;

namespace WindGuardian
{
    public class World
    {
        public void Initialize()
        {
            Destroy();

            AddFieldUnit(new FieldUnit());
        }
        public void Destroy()
        {
            fieldUnits.Clear();
        }


        public void AddFieldUnit(FieldUnit unit)
        {
            var obj = new UnityEngine.GameObject();
            obj.AddComponent<FieldUnit>();
            fieldUnits.Add(obj);
        }
        public ArrayList GetFieldUnits()
        {
            return fieldUnits;
        }

        private ArrayList fieldUnits = new ArrayList();
    }
}