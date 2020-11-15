namespace ExpertSystem
{
    public class RightXor : RightRelation
    {
        private ProgramObject leftObject;

        public RightXor(Symbole rightSymbole, ProgramObject leftObject)
        {
            this.rightSymbole = rightSymbole;
            this.leftObject = leftObject;
        }

        public override bool checkValue(Contexte contexte)
        {
            int lastRelationId = rightSymbole.getMatchRelation<RightXor>(contexte.getLastComponent().symbole);
            if (lastRelationId >= 0)
                contexte.addContextComponent(new ContexteComponent(rightSymbole.getStringSymbole(), lastRelationId));
            bool left = leftObject.checkValue(contexte);
            bool xor;
            try {
                xor  = rightSymbole.checkValue(contexte);
            }
            catch (UndefinedValueException) {
                xor = false;
            }

            return left != xor;
        }
    }
}