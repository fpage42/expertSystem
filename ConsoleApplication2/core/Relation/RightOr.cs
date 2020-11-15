namespace ExpertSystem
{
    public class RightOr : RightRelation
    {
        private ProgramObject leftObject;

        public RightOr(Symbole rightSymbole, ProgramObject leftObject)
        {
            this.rightSymbole = rightSymbole;
            this.leftObject = leftObject;
        }

        public override bool checkValue(Contexte contexte)
        {
            int lastRelationId = rightSymbole.getMatchRelation<RightOr>(contexte.getLastComponent().symbole);
            if (lastRelationId >= 0)
                contexte.addContextComponent(new ContexteComponent(rightSymbole.getStringSymbole(), lastRelationId));
            bool left = leftObject.checkValue(contexte);
            bool or;
            try {
                or  = rightSymbole.checkValue(contexte);
            }
            catch (UndefinedValueException) {
                or = false;
            }
            if (or)
                throw new UndefinedValueException();
            if (!left)
                return false;
            return true;
        }
    }
}