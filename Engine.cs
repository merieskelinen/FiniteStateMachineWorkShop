using System;

namespace SpendADayAsAnOrc
{
    class Engine
    {
        static void Main(string[] args)
        {
            var orc = new Orc();
            while (true)
            {
                orc.Update();
            }
        }
    }
}
