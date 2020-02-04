using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using IronOcr;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Threading;

namespace ImageToText
{
    class Program
    {
        public static List<Rectangle> areas = new List<Rectangle>();

        [STAThread]
        public static void Main(string[] args)
        {
            string ImageFilePath = string.Empty;

            Console.WriteLine("OUTPUT FILE NAME (WITH EXT.):");
            string OutputTextPath = Console.ReadLine();
            Thread.Sleep(1000);
            Console.Clear();


            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                var path = fbd.SelectedPath;
                CenterWriteLine($"YOU SELECTED PATH: {path}"); // full path

                foreach (string file in Directory.GetFiles(path))
                {
                    if (Path.GetFileName(file) == "Crop_Areas.txt")
                    {
                        for (int i = 0; i < File.ReadAllLines(file).Length; i++)
                        {
                            if (i == 0)
                            {
                                ImageFilePath = File.ReadAllLines(file)[i].TrimEnd(':');
                                CenterWriteLine($"IMAGE PATH: {ImageFilePath}");
                            }
                            else
                            {
                                areas.Add(GetRectangleFromString(File.ReadAllLines(file)[i]));
                            }
                        }
                    }
                }

                Console.WriteLine();
                CenterWriteLine("================================================");
                CenterWriteLine("PROCESSING IMAGE... PLEASE WAIT!");
                CenterWriteLine("================================================");
                string alltext = string.Empty;

                foreach (Rectangle r in areas)
                {
                    var Ocr = new AdvancedOcr()
                    {
                        CleanBackgroundNoise = false,
                        EnhanceContrast = true,
                        EnhanceResolution = false,
                        Language = IronOcr.Languages.English.OcrLanguagePack,
                        Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced,
                        ColorSpace = AdvancedOcr.OcrColorSpace.Color,
                        DetectWhiteTextOnDarkBackgrounds = false,
                        InputImageType = AdvancedOcr.InputTypes.Document,
                        RotateAndStraighten = false,
                        ReadBarCodes = false,
                        ColorDepth = 4
                    };

                    var Results = Ocr.Read(ImageFilePath, r);

                    alltext += Results.Text + Environment.NewLine;
                }

                Console.WriteLine();
                CenterWriteLine("================================================");
                CenterWriteLine("PROCESSING IMAGE DONE!");
                CenterWriteLine("================================================");

                Thread.Sleep(500);

                Console.WriteLine();
                CenterWriteLine("================================================");
                CenterWriteLine("TEXT FORMATING STRATED!");
                CenterWriteLine("================================================");

                string[] lines = alltext.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                string final_text = string.Empty;

                foreach (string line in lines)
                {
                    if(!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
                    {
                        final_text += line + Environment.NewLine;
                    }
                }

                Console.WriteLine();
                CenterWriteLine("================================================");
                CenterWriteLine("TEXT FORMATING DONE!");
                CenterWriteLine($"SAVING IMAGE TO FILE (IN BASE DIRECTORY): {OutputTextPath}");
                CenterWriteLine("================================================");

                File.WriteAllText(Path.Combine(path, OutputTextPath), final_text);
            }
            else
            {
                Console.WriteLine("PATH NOT SELECTED!");
            }

            Console.ReadLine();
        }

        public static Rectangle GetRectangleFromString(string s)
        {
            string[] ss = s.Split(':');
            
            return new Rectangle { X = int.Parse(ss[0]), Y = int.Parse(ss[1]), Width = int.Parse(ss[2]), Height = int.Parse(ss[3]) };
        }

        public static void CenterWriteLine(string text)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }
    }
}
