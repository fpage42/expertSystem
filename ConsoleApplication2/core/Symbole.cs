using System;
using System.Collections.Generic;

namespace ExpertSystem
{
    public class Symbole : ProgramObject
    {
        private readonly List<RightRelation> relations = new List<RightRelation>();
        private bool value;
        
        public Symbole(string name)
        {
            this.name = name;
            Core.getCore().addSymbole(name, this);
        }

        public override bool checkValue(Contexte contexte)
        {
            if (this.value)
                return this.value;
            bool isSet = false;
            bool res = false;
            bool error = false;
            for (var i = 0; i < this.relations.Count; i++)
            {
                var rel = this.relations[i];
                ContexteComponent component = new ContexteComponent(this.name, i);
                if (contexte.addContextComponent(component))
                {
                    isSet = true;
                    continue;                    
                }
                try
                {
                    res = rel.checkValue(contexte);
                    isSet = true;
                }
                catch (UndefinedValueException)
                {}
                if (res)
                    return true;
            }

            if (!isSet && this.relations.Count != 0)
                throw new UndefinedValueException();
            return (this.relations.Count == 0)?this.value:res;
        }

        public void addRelation(RightRelation rel)
        {
            this.relations.Add(rel);
        }
        
        public void setTrue()
        {
            this.value = true;
        }

        public string getStringSymbole()
        {
            return this.name;
        }

        public int getMatchRelation<T>(string symbole) where T: RightRelation
        {
            for (var i = 0; i < relations.Count; i++)
            {
                if (relations[i].GetType() == typeof(T) &&
                    ((T) relations[i]).rightSymbole.name.Equals(symbole))
                    return i;
            }

            return -1;
        }
    }
}