namespace ExpertSystem
{
    public abstract class ProgramObject
    {
        protected ProgramObjectType type;
        protected string name;
        protected ProgramObject s1, s2;

        public abstract bool checkValue(Contexte contexte);
    }
}