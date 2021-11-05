namespace SpendADayAsAnOrc.FiniteStateMachine
{
    public abstract class State
    {
        public abstract void Enter(Orc orc);
        public abstract void Execute(Orc orc);
        public abstract void Exit(Orc orc);
    }
}
