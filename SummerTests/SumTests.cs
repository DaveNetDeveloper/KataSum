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

        [Test, Description("0 - Si recibimos una cadena no númerica, devolvemos FormatException.")]
        public void GivenNonNumericalValueReceivedWhenExecuteSumThenReturnFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(GetFormatException));
        }

        private void GetFormatException()
        {
            calculator = new Sum(inputValues: "abc");
            calculator.GetSum();
        }

        [Test, Description("1 - Si no hay valores, recibimos una cadena vacia, devolvemos 0.")]
        public void GivenEmptyStringRecievedWhenExecuteSumThenReturnZero()
        {
            calculator = new Sum(inputValues: string.Empty);
            Assert.AreEqual(0, calculator.GetSum());
        }
    }
}