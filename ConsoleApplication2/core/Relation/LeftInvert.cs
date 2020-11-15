namespace ExpertSystem
{
    public class LeftInvert : LeftRelation
    {
        public LeftInvert(ProgramObject s1)
        {
            this.s1 = s1;
            this.type = ProgramObjectType.Relation;
        }

        public override bool checkValue(Contexte contexte)
        {
            return !this.s1.checkValue(contexte);
        }
    }
}