using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    class FirstApp
    {
        static void Main(string[] args)
        {
            char startChar;

            bool isProgramContinue = true;

            byte minUpperLetterCode = 65;
            byte minLowerLetterCode = 97;
            byte maxUpperLetterCode = 90;
            byte maxLowerLetterCode = 122;


            Console.WriteLine("Başlangıç karakterini giriniz: ");
            ConsoleKeyInfo consoleKeyInfoStartChar = Console.ReadKey();
            Console.WriteLine();

            startChar = consoleKeyInfoStartChar.KeyChar;

            if (startChar >= minLowerLetterCode && startChar <= maxLowerLetterCode)
            {
                Console.WriteLine("Küçük harf girdiniz. Büyük harf olarak devam edilsin mi? e/h");
                ConsoleKeyInfo consoleKeyInfoAnswer = Console.ReadKey();
                Console.WriteLine();

                if (consoleKeyInfoAnswer.KeyChar == 'e' || consoleKeyInfoAnswer.KeyChar == 'E')
                {
                    isProgramContinue = true;
                    /*
                     * a = 97 = minLowerLetterCode
                     b = 98,
                     A = 65 = minUpperLetterCode
                     B = 66
                     */

                    byte startCharAsciiCode = (byte)startChar;
                    byte distance = (byte)(startCharAsciiCode - minLowerLetterCode); //distance tanımladıktan sonra çıkarma işlemi int tipinde yapılacagı için casting işlemi uygulandı

                    byte upperLetterCode = (byte)(minUpperLetterCode + distance);
                    startChar = (char)upperLetterCode;
                }
                else
                {
                    isProgramContinue = false;
                }
            }

            if (isProgramContinue)
            {
                int letterCount;
                int wordCount;
                char tempStartChar;
                byte tempStartCharCode;
                string word = String.Empty;

                Console.WriteLine("Kaç kelime olsun: ");
                wordCount = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Kaç karakterli olsun: ");
                letterCount = Convert.ToInt32(Console.ReadLine());

                /*
                 * Her kelime döngüsünde bir sonraki harfe geçerek kelimeyi başlat
                 * 1. Kelime = A...  = A + 0
                 * 2. Kelime = B...  = A + 1
                 */
                for (int wordOrder = 1; wordOrder <= wordCount; wordOrder++)
                {

                    /*
                     * Her Kelime sırasına göre başlangıç harfine göre başlayıp karakter sırasına göre iki sonraki harf yazılarak devam eder
                     * 1. Kelime = ACE
                     *             024
                     * 2. Kelime = BDF
                     * ...
                     * ...
                     * x. Kelime = YAC ÖDEV
                     * x+1. Kelime = ZBD
                     */

                    tempStartCharCode = (byte)((byte)startChar + wordOrder - 1);
                    word = String.Empty;

                    for (int letterOrder = 1; letterOrder <= letterCount; letterOrder++)
                    {
                        byte letterCharCode = (byte)(tempStartCharCode + ((letterOrder - 1) * 2));


                        // A - Z Aralık Kontrol
                        if (letterCharCode > maxUpperLetterCode)
                        {
                            byte dif = (byte)(letterCharCode - maxUpperLetterCode);
                            letterCharCode = (byte)(minUpperLetterCode + dif - 1);
                        }

                        tempStartChar = (char)(letterCharCode);
                        word += tempStartChar;
                    }

                    string message = $"{wordOrder}. Kelime = {word}";
                    Console.WriteLine(message);

                }

            }
            else
            {
                Console.WriteLine("Program bitti ...");
            }

            Console.ReadKey();
        }
    }
}
