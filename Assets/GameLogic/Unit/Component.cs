namespace WindGuardian
{
    public abstract class GameComponent
    {
        public void OnEquip(FieldUnit unit)
        {
            owner = unit;
        }
        public void OnUnequip()
        {
            owner = null;
        }
        public abstract void OnUpdate(double dt);

        protected FieldUnit owner;
    }
}