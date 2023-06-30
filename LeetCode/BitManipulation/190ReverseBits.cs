using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.BitManipulation
{
    public class _190ReverseBits
    {
        public static void Test()
        {

            //uint input = Convert.ToUInt32("01000000000000000000000000000011", 2);
            uint input = Convert.ToUInt32("00000010100101000001111010011100", 2);
            var res = reverseBits2(input);//4
            ////var res = LengthOfLIS(new[] { 0, 1, 0, 3, 2, 3 });//4
            Console.WriteLine(res);
        }

        static uint reverseBits(uint n)
        {
            uint res = 0;
            uint _one = 1;
            for (var i = 31; i >= 0; i--)
            {
                var s = _one << i;
                if (n >= s)
                {
                    n = n - s;
                    res = res ^ (_one << 31 - i);
                }

            }

            return res;
        }

        static uint reverseBits2(uint n)
        {
            uint _8BitsLeft = 16711935; //Convert.ToUInt32("00000000111111110000000011111111", 2);//
            uint _8BitsRight = 4278255360;// Convert.ToUInt32("11111111000000001111111100000000", 2);//4278255360

            uint _4BitsLeft = 252645135;// Convert.ToUInt32("00001111000011110000111100001111", 2);//252645135
            uint _4BitsRight = 4042322160;// Convert.ToUInt32("11110000111100001111000011110000", 2);//4042322160

            uint _2BitsLeft = 858993459;// Convert.ToUInt32("00110011001100110011001100110011", 2);//858993459
            uint _2BitsRight = 3435973836;// Convert.ToUInt32("11001100110011001100110011001100", 2);//3435973836

            uint _1BitsLeft = 1431655765;// Convert.ToUInt32("01010101010101010101010101010101", 2);//1431655765
            uint _1BitsRight = 2863311530;// Convert.ToUInt32("10101010101010101010101010101010", 2);//2863311530

            //Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));

            n = n >> 16 | n << 16;
            //Console.WriteLine(Convert.ToString(n, 2).PadLeft(32,'0'));

            n = n >> 8 & _8BitsLeft | n << 8 & _8BitsRight;
            //Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));

            n = n >> 4 & _4BitsLeft | n << 4 & _4BitsRight;
            //Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));


            n = n >> 2 & _2BitsLeft | n << 2 & _2BitsRight;
            //Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));


            n = n >> 1 & _1BitsLeft | n << 1 & _1BitsRight;
            //Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));

            return n;
        }
    }
}
