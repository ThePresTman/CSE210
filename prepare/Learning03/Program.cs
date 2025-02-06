using System;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    // Constructor with no parameters (defaults to 1/1)
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    // Constructor with one parameter (numerator, denominator defaults to 1)
    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }

    // Constructor with two parameters (numerator and denominator)
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        _numerator = numerator;
        _denominator = denominator;
    }

    // Getter and Setter for Numerator
    public int GetNumerator()
    {
        return _numerator;
    }

    public void SetNumerator(int numerator)
    {
        _numerator = numerator;
    }

    // Getter and Setter for Denominator
    public int GetDenominator()
    {
        return _denominator;
    }

    public void SetDenominator(int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        _denominator = denominator;
    }

    // Method to return fraction as a string
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    // Method to return decimal value of fraction
    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}