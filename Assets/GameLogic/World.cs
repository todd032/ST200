using System.Collections;

namespace WindGuardian
{
    public class World
    {
        public void Initialize()
        {
            Destroy();
        }
        public void Destroy()
        {
            fieldUnits.Clear();
        }

        public void AddFieldUnit(FieldUnit unit)
        {
            fieldUnits.Add(unit);
        }
        public ArrayList GetFieldUnits()
        {
            return fieldUnits;
        }

        private ArrayList fieldUnits = new ArrayList();
    }
}
