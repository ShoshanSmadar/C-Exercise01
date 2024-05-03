using System.Linq;

namespace Ex01_01
{
    class Program
    {
        static void Main()
        {
            int binaryFirstNumber, binarySecondNumber, binaryThirdNumber;
            int decimalFirstNumber, decimalSecondNumber, decimalThirdNumber;
            GetBinaryNumberFromUser(out binaryFirstNumber, out binarySecondNumber, out binaryThirdNumber);
            ConvertBinaryNumberToDecimal(binaryFirstNumber, binarySecondNumber, binaryThirdNumber,
                out decimalFirstNumber, out decimalSecondNumber, out decimalThirdNumber);
            CalculateAndPrintStatistics(binaryFirstNumber, binarySecondNumber, binaryThirdNumber,
                decimalFirstNumber, decimalSecondNumber, decimalThirdNumber);

        }

        public static void GetBinaryNumberFromUser(out int o_BinaryFirstNumber, out int o_BinarySecondNumber, out int o_BinaryThirdNumber)
        {
            o_BinaryFirstNumber = GetBinaryNumberFromUserAndCheckIt();
            o_BinarySecondNumber = GetBinaryNumberFromUserAndCheckIt();
            o_BinaryThirdNumber = GetBinaryNumberFromUserAndCheckIt();
        }

        public static int GetBinaryNumberFromUserAndCheckIt()
        {
            string i_InputBinaryNumber = System.Console.ReadLine();
            while (!BinaryNumberIsGood(i_InputBinaryNumber))
            {
                System.Console.WriteLine("The input is wrong, please try again.");
                i_InputBinaryNumber = System.Console.ReadLine();
            }
            return int.Parse(i_InputBinaryNumber);
        }

        public static bool BinaryNumberIsGood(string io_BinaryNumber)
        {
            int o_IntegerBinaryNumber;
            if (io_BinaryNumber.Length != 9)
            {
                return false;
            }
            else if (!int.TryParse(io_BinaryNumber, out o_IntegerBinaryNumber))
            {
                return false;
            }
            else if (!IsBinaryString(io_BinaryNumber))
            {
                return false;
            }
            return true;
        }

        public static bool IsBinaryString(string io_BinaryString)
        {
            return io_BinaryString.All(IsBinaryCharacter);
        }

        public static bool IsBinaryCharacter(char io_BinaryCharacter)
        {
            return io_BinaryCharacter == '0' || io_BinaryCharacter == '1';
        }

        public static void ConvertBinaryNumberToDecimal(int io_BinaryFirstNumber, int io_BinarySecondNumber, int io_BinaryThirdNumber,
            out int o_DecimalFirstNumber, out int o_DecimalSecondNumber, out int o_DecimalThirdNumber)
        {
            //TODO!!
            o_DecimalFirstNumber =1; o_DecimalSecondNumber =1; o_DecimalThirdNumber =1 ;
        }

        public static void CalculateAndPrintStatistics(int o_BinaryFirstNumber, int o_BinarySecondNumber, int o_BinaryThirdNumber,
            int decimalFirstNumber, int decimalSecondNumber, int decimalThirdNumber)
        {

        }
    }
}
