// See https://aka.ms/new-console-template for more information
using RomanNumeral2Number;

Console.WriteLine("Roman Numeral Converter\n");
Console.Write("Enter the roman numeral: ");
var numeral = Console.ReadLine();
Converter converter = new Converter();
var number = converter.ConvertRomanNumeralToNumber(numeral);
Console.WriteLine($"{numeral} is {number}");
