using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnMobile
{
    class OperatorHelper
    {
        public static double caculate(double v1, double v2, string ope)
        {
            double rs = 0;
            switch (ope)
            {
                case "+":
                    rs = v1 + v2;
                    break;
                case "-":
                    rs = v1 - v2;
                    break;
                case "x":
                    rs = v1 * v2;
                    break;
                case "/":
                    rs = v1 / v2;
                    break;
            }
            return rs;
        }
    }
}
