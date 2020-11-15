
namespace ExpertSystem
{
    public class RightNormal : RightRelation
    {
        private ProgramObject leftObject;
        
        public RightNormal(ProgramObject leftObject)
        {
            this.leftObject = leftObject;
        }

        public override bool checkValue(Contexte contexte)
        {
            return this.leftObject.checkValue(contexte);
        }
    }
}