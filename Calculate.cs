using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_2_
{
    public class Calculate
    {
        public int a;
        public int b;
        public char znak;
        public Calculate(int A, int B, char Znak)
        {
            this.a = A;
            this.b = B;
            this.znak = Znak;
        }
        public int ResOfSum()
        {
            return a + b;
        }
        public int ResOfSub()
        {
            return a - b;
        }
        public int ResOfMul()
        {
            return a * b;
        }
        public int ResOfDiv()
        {
            try
            {
                return a / b;
            }
            catch when (b == 0)
            {
                return 0;
            }
        }
        public int Operation()
        {
            switch (znak)
            {
                case '+':
                    return ResOfSum();
                case '-':
                    return ResOfSub();
                case '*':
                    return ResOfMul();
                case '/':
                    return ResOfDiv();
                case ' ':
                    return 0;
            }
            return 0;
        }
    }
}
    

