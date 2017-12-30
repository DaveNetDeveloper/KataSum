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

        //ctors.
        public Sum() { }
        public Sum(string inputValues) => InputValues = inputValues.Trim();

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
                throw new FormatException();
            }
        }

        //String parsing private methods 
        private int ConvertStringToSingleNumber()
        {
            return Convert.ToInt32(InputValues);
        }
    }
}
