using System.Collections.Generic;

namespace ExpertSystem
{
    public class Contexte
    {
        private List<ContexteComponent> components = new List<ContexteComponent>();

        public bool addContextComponent(ContexteComponent component)
        {
            foreach (var comp in components)
            {
                if (comp.symbole.Equals(component.symbole) && comp.relationId.Equals(component.relationId))
                    return true;
            }
            this.components.Add(component);
            return false;
        }

        public ContexteComponent getLastComponent()
        {
            return components[components.Count-1];
        }

        public Contexte copy()
        {
            Contexte c = new Contexte();
            components.ForEach(component => c.addContextComponent(component));
            return c;
        }
        
    }

    public class ContexteComponent
    {
        public string symbole { get; private set; }
        public int relationId { get; private set; }

        public ContexteComponent(string symbole, int relationId)
        {
            this.symbole = symbole;
            this.relationId = relationId;
        }
    }
}