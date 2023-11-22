using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSrvDesignPatterns.DesignPatterns;

public class CalcArguements { 
    public int a { get; set; }
    public int b { get; set; }
}

// Service Interface
public interface ICalculatorService
{
    int Add(CalcArguements c, int a);
    int Subtract(CalcArguements c);
    int Multiply(CalcArguements c, string type);
    
}

// Actual Calculator Service Implementation
public class CalculatorService : ICalculatorService
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Add(CalcArguements c, int a)
    {
        throw new NotImplementedException();
    }

    public int Multiply(CalcArguements c, string type)
    {
        throw new NotImplementedException();
    }

    public int Subtract(CalcArguements c)
    {
        throw new NotImplementedException();
    }
}