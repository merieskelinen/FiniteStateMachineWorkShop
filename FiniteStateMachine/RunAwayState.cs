using System;
using SpendADayAsAnOrc.FiniteStateMachine.SpendADayAsAnOrc.FiniteStateMachine;

namespace SpendADayAsAnOrc.FiniteStateMachine
{
    public class RunAwayState : State
    {
        private Random random = new Random();

        public override void Enter(Orc orc)
        {
            Console.WriteLine("Health low, running away from enemy...");
        }

        public override void Execute(Orc orc)
        {
            Console.WriteLine("Running away from enemy...");
            orc.EnemyDistance = IncreaseEnemyDistance(orc);

            if (orc.Health >= 100)
            {
                if (orc.EnemyFar())
                {
                    orc.ChangeState(new PatrolState());
                }
                else
                {
                    orc.ChangeState(new FightState());
                }

            }
            else
            {
                orc.Health += 10;
            }
        }

        public override void Exit(Orc orc)
        {
            Console.WriteLine("Healthy again!");
        }

        private int IncreaseEnemyDistance(Orc orc)
        {
            var distance = orc.EnemyDistance + random.Next(1, 10);
            return distance >= 100 ? 100 : distance;
        }
    }
}
