
using System;
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
            System.Console.WriteLine("Please enter 3 binary numbers with 9 digits:");
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
            int o_IntegerBinaryNumber;
            int.TryParse(i_InputBinaryNumber, out o_IntegerBinaryNumber);
            return o_IntegerBinaryNumber;
        }

        public static bool BinaryNumberIsGood(string io_BinaryNumber)
        {
            if (io_BinaryNumber.Length != 9)
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
            o_DecimalFirstNumber = BinaryNumberToDecimalInt(io_BinaryFirstNumber);
            o_DecimalSecondNumber = BinaryNumberToDecimalInt(io_BinarySecondNumber);
            o_DecimalThirdNumber = BinaryNumberToDecimalInt(io_BinaryThirdNumber);
        }

        public static int BinaryNumberToDecimalInt(int io_binaryNumber)
        {
            int io_DecimalNumber = 0;
            int i_DigitPosition = 1;

            while (io_binaryNumber > 0)
            {
                int i_LastDigit = io_binaryNumber % 10;
                io_DecimalNumber += i_LastDigit * i_DigitPosition;
                io_binaryNumber /= 10;
                i_DigitPosition *= 2;
            }
            return io_DecimalNumber;
        }

        public static void CalculateAndPrintStatistics(int io_BinaryFirstNumber, int io_BinarySecondNumber, int io_BinaryThirdNumber,
            int decimalFirstNumber, int decimalSecondNumber, int decimalThirdNumber)
        {
            float i_probabiltyOfOnesInsideBinaryNumbers, i_probabiltyOfZeroesInsideBinaryNumbers;
            int i_PowerOfTwoBinaryNumber = ProbabilityOfOnesAndZeroes(io_BinaryFirstNumber, io_BinarySecondNumber, io_BinaryThirdNumber, 
                out i_probabiltyOfOnesInsideBinaryNumbers, out i_probabiltyOfZeroesInsideBinaryNumbers);
            int i_NumberOfRisingDigits = CalculateNumberOfRisingDigits(io_BinaryFirstNumber, io_BinarySecondNumber, io_BinaryThirdNumber);

        }

        public static int CalculateNumberOfRisingDigits(int io_decimalFirstNumber, int io_decimalSecondNumber, int io_decimalThirdNumber)
        {
            int o_Result = 0;

            
            if(checkIfRisingDigits(io_decimalFirstNumber))
            {
                o_Result++;
            }
            if (checkIfRisingDigits(io_decimalSecondNumber))
            {
                o_Result++;
            }
            if (checkIfRisingDigits(io_decimalThirdNumber))
            {
                o_Result++;
            }

            return o_Result;
        }

        public static bool checkIfRisingDigits(int io_DecimalNumber)
        {
            int io_MaxNumber = io_DecimalNumber % 10 + 1;

            while (io_DecimalNumber > 0)
            {
                int i_LastDigit = io_DecimalNumber % 10;
                if(i_LastDigit < io_MaxNumber)
                {
                    return false;
                }
                io_MaxNumber = i_LastDigit;
            }
            return true;
        }

        public static int  ProbabilityOfOnesAndZeroes(int io_BinaryFirstNumber, int io_BinarySecondNumber, int io_BinaryThirdNumber, 
            out float o_probabiltyOfOnesInsideBinaryNumbers, out float o_probabiltyOfZeroesInsideBinaryNumbers)
        {
            float i_countZeroDigits, i_countOneDigits;
            float i_MaxNumberOfDigits = 27;
            float i_MaxBinaryNumbers = 3;
            float i_NumberOfOnesInFirstNumber = CountOnes(io_BinaryFirstNumber);
            float i_NumberOfOnesInSecondNumber = CountOnes(io_BinarySecondNumber);
            float i_NumberOfOnesInThirdNumber = CountOnes(io_BinaryThirdNumber);
            i_countOneDigits = i_NumberOfOnesInFirstNumber + i_NumberOfOnesInSecondNumber + i_NumberOfOnesInThirdNumber;
            i_countZeroDigits = i_MaxNumberOfDigits - i_countOneDigits;
            o_probabiltyOfOnesInsideBinaryNumbers = i_countOneDigits / i_MaxBinaryNumbers;
            o_probabiltyOfZeroesInsideBinaryNumbers = i_countZeroDigits / i_MaxBinaryNumbers;
            
            int o_PowerOfTwoBinaryNumber = 0;
            if (i_NumberOfOnesInFirstNumber == 1)
            {
                o_PowerOfTwoBinaryNumber++;
            }
            if (i_NumberOfOnesInSecondNumber == 1)
            {
                o_PowerOfTwoBinaryNumber++;
            }
            if (i_NumberOfOnesInThirdNumber == 1)
            {
                o_PowerOfTwoBinaryNumber++;
            }
            return o_PowerOfTwoBinaryNumber;
        }

        public static float CountOnes(int io_binaryNumber)
        {
            float io_Count = 0;

            while (io_binaryNumber > 0)
            {
                int i_LastDigit = io_binaryNumber % 10;
                if (i_LastDigit == 1)
                {
                    io_Count++;
                }
                io_binaryNumber /= 10;
            }

            return io_Count;
        }
    }
}
