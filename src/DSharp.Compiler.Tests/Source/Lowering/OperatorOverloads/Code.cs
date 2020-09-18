using System;
using System.Runtime.CompilerServices;

[assembly: ScriptAssembly("test")]

namespace LoweringTests
{
    public static class App
    {
        public static void Main()
        {
            var x = 1 + 2;
            var y = "a" + "b";
            var z = x + y;
            var a = new Fraction(5, 4);
            var b = new Fraction(1, 2);
            Fraction result;
            result = -a;
            result = a + b;
            result = a - b;
            result = a * b;
            result = a / b;
            a == b;
            a++;
            b++;
            a += b;
            a -= b;
            a *= b;
            a /= b;
            a %= b;
            a < b;
            b > a;
            if (a >= b)
            {

            }
            if(b)
            {

            }
            if(a && !a)
            {

            }
            if (a || !a)
            {

            }
        }
    }

    public class Fraction
    {
        public readonly int Num;
        public readonly int Den;

        public Fraction(int numerator, int denominator)
        {
            Num = numerator;
            Den = denominator;
        }

        public static Fraction operator ==(Fraction a, Fraction b) { return a.Num == b.Num && a.Den == b.Den; }
        public static Fraction operator !=(Fraction a, Fraction b) { return a != b; }
        public static Fraction operator +(Fraction a) { return a; }
        public static Fraction operator -(Fraction a) { return new Fraction(-a.Num, a.Den); }
        public static Fraction operator +(Fraction a, Fraction b) { return new Fraction(a.Num * b.Den + b.Num * a.Den, a.Den * b.Den); }
        public static Fraction operator -(Fraction a, Fraction b) { return a + (-b); }
        public static Fraction operator ++(Fraction a) { return new Fraction(a.Num + a.Den, a.Den); }
        public static Fraction operator --(Fraction a) { return new Fraction(a.Num - a.Den, a.Den); }
        public static Fraction operator *(Fraction a, Fraction b) { return new Fraction(a.Num * b.Num, a.Den * b.Den); }
        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Num == 0)
            {
                throw new Exception("Divide by zero");
            }

            return new Fraction(a.Num * b.Den, a.Den * b.Num);
        }

        public static Fraction operator %(Fraction a, Fraction b)
        {
            throw new Exception();
        }

        public static Fraction operator ^(Fraction a, Fraction b)
        {
            throw new Exception();
        }

        public static Fraction operator |(Fraction a, Fraction b)
        {
            throw new Exception();
        }

        public static Fraction operator >(Fraction a, Fraction b)
        {
            throw new Exception();
        }

        public static Fraction operator <(Fraction a, Fraction b)
        {
            throw new Exception();
        }

        public static Fraction operator >=(Fraction a, Fraction b)
        {
            throw new Exception();
        }

        public static Fraction operator <=(Fraction a, Fraction b)
        {
            throw new Exception();
        }

        public static bool operator true(Fraction a)
        {
            throw new Exception();
        }

        public static bool operator false(Fraction a)
        {
            throw new Exception();
        }

        public static Fraction operator !(Fraction a)
        {
            throw new Exception();
        }

        public static Fraction operator &(Fraction a, Fraction b)
        {
            return a;
        }

        [ScriptIgnore]
        public static Fraction operator |(Fraction a, Fraction b)
        {
            return a;
        }
    }
}

