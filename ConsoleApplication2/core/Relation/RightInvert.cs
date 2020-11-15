
namespace ExpertSystem
{
    public class RightInvert : RightRelation
    {
        private ProgramObject leftObject;
        
        public RightInvert(ProgramObject leftObject)
        {
            this.leftObject = leftObject;
        }

        public override bool checkValue(Contexte contexte)
        {
            return !this.leftObject.checkValue(contexte);
        }
    }
}