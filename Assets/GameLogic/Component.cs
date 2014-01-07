namespace WindGuardian
{
    public class Component
    {
        public void OnEquip(FieldUnit unit)
        {
            owner = unit;
        }
        public void OnUnequip()
        {
            owner = null;
        }
        public void OnUpdate(double dt)
        {

        }

        protected FieldUnit owner;
    }
}
