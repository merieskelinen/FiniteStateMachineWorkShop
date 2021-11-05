using SpendADayAsAnOrc.FiniteStateMachine;
using SpendADayAsAnOrc.FiniteStateMachine.SpendADayAsAnOrc.FiniteStateMachine;
using System;

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
            this.Health = 100;
            this.EnemyDistance = 50;
            this.EnemyHealth = 50;
            _CurrentState = new PatrolState();
        }

        public void Update()
        {
            System.Threading.Thread.Sleep(1000);
            if (this.Health < 100)
            {
                this.Health += 1;
            }

            _CurrentState.Execute(this);
        }

        internal bool EnemyFar()
        {
            return this.EnemyDistance > 20;
        }

        public void ChangeState(State newState)
        {
            System.Threading.Thread.Sleep(1000);
            _CurrentState.Exit(this);
            _CurrentState = newState;
            System.Threading.Thread.Sleep(1000);
            _CurrentState.Enter(this);
        }
    }
}
