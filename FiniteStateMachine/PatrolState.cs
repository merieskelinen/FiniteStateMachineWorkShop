namespace SpendADayAsAnOrc.FiniteStateMachine
{
    using System;

    namespace SpendADayAsAnOrc.FiniteStateMachine
    {
        public class PatrolState : State
        {
            private Random _Random = new();

            public override void Enter(Orc orc)
            {
                Console.WriteLine("I should take a look around.");
            }

            public override void Execute(Orc orc)
            {
                Console.WriteLine("Patroling...");
                orc.EnemyDistance = DecreaseEnemyDistance(orc);

                if (orc.Health > 10 && !orc.EnemyFar())
                {
                    orc.ChangeState(new FightState());
                }
                else if (orc.Health < 10 && orc.EnemyFar())
                {
                    orc.ChangeState(new RunAwayState());
                }
            }

            public override void Exit(Orc orc)
            {
                Console.WriteLine("No more patroling, need some action!");
            }

            private int DecreaseEnemyDistance(Orc orc)
            {
                var distance = orc.EnemyDistance - this._Random.Next(1, 10);
                return distance <= 0 ? 0 : distance;
            }
        }
    }

}
