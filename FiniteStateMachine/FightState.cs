using System;
using SpendADayAsAnOrc.FiniteStateMachine.SpendADayAsAnOrc.FiniteStateMachine;

namespace SpendADayAsAnOrc.FiniteStateMachine
{
    internal class FightState : State
    {
        private Random _Random = new();

        public override void Enter(Orc orc)
        {
            Console.WriteLine("Enemy has breached through our gates! ATTAAAAAACK!");
        }

        public override void Execute(Orc orc)
        {
            Console.WriteLine("Fight me you bastard! * cling, clang *");
            orc.Health -= this._Random.Next(1, 10);
            orc.EnemyHealth -= this._Random.Next(1, 10);

            if (orc.Health < 10)
            {
                orc.ChangeState(new RunAwayState());
            }

            if (orc.EnemyHealth < 10)
            {
                Console.WriteLine("HAHAAAAA, die you bastard!");
                orc.ChangeState(new PatrolState());
            }
        }

        public override void Exit(Orc orc)
        {
            orc.EnemyHealth = 100;
            orc.EnemyDistance = 100;
            Console.WriteLine("No more fighting to do");
        }
    }
}