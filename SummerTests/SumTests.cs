/* REGLAS
 * ------
 * Se trata de una calculadora que solo suma valores.
 * 1.- Si no hay valores, recibimos una cadena vacia, devolvemos 0.
 * 2.- Dado 1 solo valor, obtendremos el mismo valor.
 * 3.- Dados 2 valores, separados por coma (','), los suma. Ejemplo: 1,2 --> Resultado: 3
 * 4.- Ampliar para sumar N valores.
 * 5.- El separador puede ser tanto una coma (',') como un Carrier Return ('\n'). Ejemplo: 1,2\n3 --> Resultado: 6
 * 6.- Podemos añadirle un separador nuevo en la misma linea, usando el formato: //nuevo_separador\nValor1,Valor2... Ejemplo: //.\n1,2\n3.4 --> Resultado: 10.
 */
namespace SummerTests
{
    using NUnit.Framework;
    using Summer;
    using System;

    [TestFixture]
    public class SumTests
    {
        public Sum calculator;

        [SetUp]
        public void SetUp() => calculator = new Sum();

        [TearDown]
        public void Dispose()
        {
            calculator = null;
        }

        [Test, Description("0 - Si recibimos una cadena no númerica, devolvemos FormatException")]
        public void GivenNonNumericalValueReceivedWhenExecuteSumThenReturnFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(GetFormatException));
        }

        private void GetFormatException()
        {
            calculator.InputValues = "abc";
            calculator.GetSum();
        }

        [Test, Description("1 - Si no hay valores, recibimos una cadena vacia, devolvemos 0")]
        public void GivenEmptyStringReceivedWhenExecuteSumThenReturnZero()
        {
            calculator.InputValues =  string.Empty;
            Assert.AreEqual(0, calculator.GetSum());
        }

        [Test, Description("2 - Dado 1 solo valor, obtendremos el mismo valor.")]
        public void GivenOneNumericValueReceivedWhenExecuteSumThenReturnSameValue()
        {
            calculator.InputValues = "8";
            Assert.AreEqual(8, calculator.GetSum());
        }

        [Test, Description("3 - Dados 2 valores positivos, separados por coma, los suma")]
        public void GivenTwoPositiveValuesReceivedWhenExecuteSumThenReturnSumResult()
        {
            calculator.InputValues = "2, 2";
            Assert.AreEqual(4, calculator.GetSum());
        }

        [Test, Description("3 - Dados 2 valores negativos, separados por coma, los suma")]
        public void GivenTwoNNegativeValuesReceivedWhenExecuteSumThenReturnSumResult()
        {
            calculator.InputValues = "-5, -5";
            Assert.AreEqual(-10, calculator.GetSum());
        }
    }
}