/* SUGERENCIAS
* -----------
* - Empieza del caso más simple al más complejo.
* - Haz un commit de cada paso, para que se puedan ver los pasos seguidos durante el desarrollo.
* - Haz commit tanto cuando crees algo como cuando refactorices.
* - Utiliza una aproximación TDD para desarrollar la kata.
* - Tómate tu tiempo para hacerlo, reserva un rato tranquilo.
* - El tiempo estimado para realizarlo es entre 1 y 4 horas.
* - El tiempo no es un factor clave, pero será tenido en cuenta.
* - Puedes implementar cuantas clases e interfaces creas necesarios. La clase principal del juego es la presente.
* - Implementa un contrato que sea: int Add(string valores)
* - No es necesario probar casos de error.
*/
using System;
namespace Summer
{
    public class Sum : ISum
    {
        //Public property
        public string InputValues { get; set; }

        private int Result { get; set; }

        //Constant values
        private const string Coma = ",";

        //ctors.
        public Sum() { }

        //Public method
        public int GetSum()
        {
            if (String.IsNullOrWhiteSpace(InputValues)) return 0;
            try
            {
                return ConvertStringToSingleNumber();
            }
            catch
            {
                return SumNumbersInStringFormat();
            }
        }

        //String parsing private methods 
        private int ConvertStringToSingleNumber()
        {
            return Convert.ToInt32(InputValues);
        }

        private int SumNumbersInStringFormat()
        {
            try
            {
                string[] arrayNumbers = InputValues.Split(Coma.ToCharArray());
                if (arrayNumbers?.Length == 2)
                {
                    foreach (string stringNumber in arrayNumbers)
                    {
                        Result += Convert.ToInt32(stringNumber);
                    }
                    return Result;
                }
                else throw new FormatException();
            }
            catch
            {
                throw new FormatException();
            }
        }
    }
}
