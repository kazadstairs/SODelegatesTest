using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SODelegatesTest
{
    class A
    {
    }
    class GeneralClass
    {
        public A foo;
    }

    class IC1 : GeneralClass { }
    class IC2 : GeneralClass { }
    class Program
    {
        static void Main(string[] args)
        {
        }

        static public void OuterWorking(Func<A, GeneralClass> Function)
        {
            A My_A_Object = new A();
            GeneralClass My_IC1_Object = Function(My_A_Object);
        }

        static public void OuterFailing(Func<GeneralClass, GeneralClass> Function)
        {
            GeneralClass My_IC1_Object = Function(new IC1());
        }

        static public void UseOuterWorking()
        {
            OuterWorking(FirstFunction);
        }

        static public void UseOuterFailing()
        {
            OuterFailing(SecondFunction);
        }

        static IC1 FirstFunction(A arg)
        {
            return new IC1();
        }

        static IC1 SecondFunction(GeneralClass Arg)
        {
            return new IC1();
        }


    }
}
