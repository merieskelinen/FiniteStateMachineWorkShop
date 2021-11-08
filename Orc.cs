using SpendADayAsAnOrc.FiniteStateMachine;

namespace SpendADayAsAnOrc
{
    public class Orc
    {
        public int Health;
        public int EnemyHealth;
        public int EnemyDistance;

        private State _CurrentState;

        public Orc()
        {
        }

        public void Update()
        {
            _CurrentState.Execute(this);
        }

        public void ChangeState(State newState)
        {
            _CurrentState.Exit(this);
            _CurrentState = newState;
            _CurrentState.Enter(this);
        }
    }
}
