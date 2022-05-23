using NUnit.Framework;
using RomanNumeral2Number;
using FluentAssertions;
using System;

namespace RomanNumeral2NumberTests
{
    public class Tests
    {
        private Converter converter;

        [SetUp]
        public void Setup()
        {
            converter = new Converter();
        }

        [Test]
        public void GivenValidRomanLetters_ShouldReturnCorrectNumber()
        {
            converter.ConvertRomanNumeralToNumber("V").Should().Be(5);
            converter.ConvertRomanNumeralToNumber("X").Should().Be(10);
            converter.ConvertRomanNumeralToNumber("I").Should().Be(1);
            converter.ConvertRomanNumeralToNumber("C").Should().Be(100);
            converter.ConvertRomanNumeralToNumber("D").Should().Be(500);

        }

        [Test]
        public void GivenValidRomanNumeralWithAdditiveElements_ShouldReturnCorrectNumber()
        {
            converter.ConvertRomanNumeralToNumber("VII").Should().Be(7);
            converter.ConvertRomanNumeralToNumber("XIII").Should().Be(13);
            converter.ConvertRomanNumeralToNumber("DCXVI").Should().Be(616);
        }

        [Test]
        public void GivenValidRomanNumeralWithSubtractiveElements_ShouldReturnCorrectNumber()
        {
            converter.ConvertRomanNumeralToNumber("IV").Should().Be(4);
            converter.ConvertRomanNumeralToNumber("IX").Should().Be(9);
            converter.ConvertRomanNumeralToNumber("XD").Should().Be(490);
            converter.ConvertRomanNumeralToNumber("CM").Should().Be(900);
        }

        [Test]
        public void GivenValidRomanNumeralWithAdditiveAndSubtractiveElements_ShouldReturnCorrectNumber()
        {
            converter.ConvertRomanNumeralToNumber("CXIX").Should().Be(119);
            converter.ConvertRomanNumeralToNumber("CMXLIV").Should().Be(944);
            converter.ConvertRomanNumeralToNumber("CDXXX").Should().Be(430);
        }

        [Test]
        public void GivenZeroInput_ShouldThrowInvalidInputException()
        {
            converter.Invoking(c => c.ConvertRomanNumeralToNumber("0"))
                .Should().Throw<ArgumentException>()
                .WithMessage("Invalid input. Please enter valid Roman numeral.");
        }

        [Test]
        public void GivenMoreThanOneSubtractiveElement_ShouldThrowInvalidInputException()
        {
            converter.Invoking(c => c.ConvertRomanNumeralToNumber("IVC"))
                .Should().Throw<ArgumentException>()
                .WithMessage("Invalid input. Please enter valid Roman numeral.");
            converter.Invoking(c => c.ConvertRomanNumeralToNumber("CMXXD"))
                .Should().Throw<ArgumentException>()
                .WithMessage("Invalid input. Please enter valid Roman numeral.");
            converter.Invoking(c => c.ConvertRomanNumeralToNumber("XXC"))
                .Should().Throw<ArgumentException>()
                .WithMessage("Invalid input. Please enter valid Roman numeral.");
        }

        [Test]
        public void GivenInvalidRepettionsOfElement_ShouldThrowInvalidInputException()
        {
            converter.Invoking(c => c.ConvertRomanNumeralToNumber("XIIII"))
                .Should().Throw<ArgumentException>()
                .WithMessage("Invalid input. Please enter valid Roman numeral.");
            converter.Invoking(c => c.ConvertRomanNumeralToNumber("CXXXX"))
                .Should().Throw<ArgumentException>()
                .WithMessage("Invalid input. Please enter valid Roman numeral.");
            converter.Invoking(c => c.ConvertRomanNumeralToNumber("CVV"))
                .Should().Throw<ArgumentException>()
                .WithMessage("Invalid input. Please enter valid Roman numeral.");
            converter.Invoking(c => c.ConvertRomanNumeralToNumber("XMXDXLXC"))
                .Should().Throw<ArgumentException>()
                .WithMessage("Invalid input. Please enter valid Roman numeral.");
        }

        [Test]
        public void GivenInvalidSubtractiveelement_ShouldThrowInvalidInputException()
        {
            converter.Invoking(c => c.ConvertRomanNumeralToNumber("VX"))
                .Should().Throw<ArgumentException>()
                .WithMessage("Invalid input. Please enter valid Roman numeral.");
            converter.Invoking(c => c.ConvertRomanNumeralToNumber("LC"))
                .Should().Throw<ArgumentException>()
                .WithMessage("Invalid input. Please enter valid Roman numeral.");
            converter.Invoking(c => c.ConvertRomanNumeralToNumber("DM"))
                .Should().Throw<ArgumentException>()
                .WithMessage("Invalid input. Please enter valid Roman numeral.");
        }


    }
}