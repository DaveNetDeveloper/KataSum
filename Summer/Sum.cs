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
        private const string CarrierReturn = "\n";
        private const string StarNewSeparator = "//";
        private const string EndNewSeparator = "\n";
        private const int OnePositionLength = 1;
        private const int StartPositionLength = 0;

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
        private int SumNumbersInStringFormat()
        {
            try
            {
                if (ContainStartNewSeparator() && IsStartPositionForNewSeparatorAtFirst() && ContainsEndNewSeparator())
                {
                    InputValues = InputValues.Replace(GetNewSeparator(), Coma);
                    InputValues = RemoveStarNewSymbol();
                    InputValues = ReplaceCarrierReturnByComaSeparator();
                    InputValues = RemoveFirstComaSymbol();
                }
                else if (ContainsCarrierReturn())
                {
                    InputValues = ReplaceCarrierReturnByComaSeparator();
                }
                return GetResultInCorrectFormat();
            }
            catch
            {
                throw new FormatException();
            }
        }
        private int GetResultInCorrectFormat()
        {
            string[] arrayNumbers = InputValues.Split(Coma.ToCharArray());
            if (arrayNumbers?.Length > 0)
            {
                foreach (string stringNumber in arrayNumbers)
                {
                    Result += Convert.ToInt32(stringNumber);
                }
                return Result;
            }
            else throw new FormatException();
        }
        private int ConvertStringToSingleNumber()
        {
            return Convert.ToInt32(InputValues);
        }
        private string ReplaceCarrierReturnByComaSeparator()
        {
            return InputValues.Replace(CarrierReturn, Coma);
        }
        
        //Check data private methods
        private bool ContainsCarrierReturn()
        {
            return InputValues.IndexOf(CarrierReturn) != -1;
        } 
        private string GetNewSeparator()
        {
            int startNewSeparatorFinalPosition = InputValues.IndexOf(StarNewSeparator) + StarNewSeparator.Length;
            return InputValues.Substring(startNewSeparatorFinalPosition, OnePositionLength);
        }  
        private bool ContainStartNewSeparator()
        {
            return InputValues.Contains(StarNewSeparator);

        } 
        private bool ContainsEndNewSeparator()
        {
            int startPositionForEndSeparator = InputValues.IndexOf(EndNewSeparator);
            return InputValues.Substring(startPositionForEndSeparator, OnePositionLength) == EndNewSeparator;
        }
        private bool IsStartPositionForNewSeparatorAtFirst()
        {
            return InputValues.Substring(StartPositionLength, OnePositionLength * 2) == StarNewSeparator;
        }

        //String removing private methods  
        private string RemoveFirstComaSymbol()
        {
            if (InputValues[0].ToString() == Coma && InputValues[1].ToString() == Coma)
            {
                return InputValues.Remove(StartPositionLength, OnePositionLength * 2);
            }
            else { return InputValues; }
        }
        private string RemoveStarNewSymbol()
        {
            return InputValues.Remove(InputValues.IndexOf(StarNewSeparator), OnePositionLength * 2);
        }
    }
}
