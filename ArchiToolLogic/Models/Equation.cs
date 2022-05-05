/**********************************************************
 * EQUATION.CS
 * 
 * Purpose: Holds a complete equation string for saving 
 * conversion calculator history
 * 
 * Author: Maria Bennett
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTool.ArchiToolLogic.Models
{
    public class Equation
    {
        public Equation()
        {
            Id = 0;
            EquationString = "";
        }

        public int Id { get; set; }
        public string EquationString { get; set; }
    }
}
