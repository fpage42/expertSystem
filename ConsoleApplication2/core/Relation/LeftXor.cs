namespace ExpertSystem
{
    public class LeftXor : LeftRelation
    {
        public LeftXor(ProgramObject s1, ProgramObject s2)
        {
            this.s1 = s1;
            this.s2 = s2;
            this.type = ProgramObjectType.Relation;
        }

        public override bool checkValue(Contexte contexte)
        {
            return s1.checkValue(contexte.copy()) != s2.checkValue(contexte.copy());
        }
    }
}