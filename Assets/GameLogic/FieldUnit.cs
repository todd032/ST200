using System.Collections;

namespace WindGuardian
{
    public class FieldUnit {
        
        public void Update(double dt)
        {
            foreach(Component comp in components)
            {
                comp.OnUpdate(dt);
            }
        }

        public void AddComponent(Component comp)
        {
            comp.OnEquip(this);
            components.Add(comp);
        }
        public void RemoveComponent(Component comp)
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