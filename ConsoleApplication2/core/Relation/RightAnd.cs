using System;

namespace ExpertSystem
{
    public class RightAnd : RightRelation
    {
        public ProgramObject leftObject;

        public RightAnd(Symbole rightSymbole, ProgramObject leftObject)
        {
            this.rightSymbole = rightSymbole;
            this.leftObject = leftObject;
        }

        public override bool checkValue(Contexte contexte)
        {
            bool left = leftObject.checkValue(contexte);
            bool and;
            try {
                and  = rightSymbole.checkValue(contexte);   
            }
            catch (UndefinedValueException e) {
                and = false;
            }
            if (left)
                return true;
  //          if (and)
                return false;
   //         throw new UndefinedValueException();
        }
    }
}