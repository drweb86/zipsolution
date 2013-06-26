using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SevenZip;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var inFile = @"d:\temp\file1.txt";
            var outFile = @"d:\temp\2.txt";

            var result = new Dictionary<OutArchiveFormat, Dictionary<CompressionMethod, List<CompressionLevel>>>();

            foreach (OutArchiveFormat af in Enum.GetValues(typeof(SevenZip.OutArchiveFormat)))
            {
                var supported = new Dictionary<CompressionMethod, List<CompressionLevel>>(); 
                result.Add(af, supported);

                foreach (CompressionMethod cm in Enum.GetValues(typeof(SevenZip.CompressionMethod)))
                {
                    var allowed = new List<CompressionLevel>();
                    supported.Add(cm, allowed);

                    foreach (CompressionLevel cl in Enum.GetValues(typeof(SevenZip.CompressionLevel)))
                    {
                        SevenZip.SevenZipCompressor c = new SevenZipCompressor();
                        if (File.Exists(outFile))
                        {
                            File.Delete(outFile);
                        }
                        try
                        {
                            c.ArchiveFormat = af;
                            c.CompressionMethod = cm;
                            c.CompressionLevel = cl;
                            c.CompressFiles(outFile, inFile);
                            allowed.Add(cl);
                        }
                        catch
                        {

                        }
                    }
                }
            }

            // code gen
            foreach (var pair in result)
            {
                Console.WriteLine("            Add(OutArchiveFormat.{0},", pair.Key);
                Console.WriteLine("                \"???\",");

                if (pair.Value.Keys.Contains(CompressionMethod.Default))
                {
                    Console.WriteLine("                CompressionMethod.Default,");
                }
                else
                {
                    Console.WriteLine("                CompressionMethod.???,");
                }
/*
                new ArchiveMethod(
                    CompressionMethod.Copy, 
                    CompressionLevel.Ultra, 
                    CompressionLevel.Ultra
                   ));
*/
                foreach (var cmpPair in pair.Value)
                {
                    if (cmpPair.Value.Count == 0)
                    {
                        continue;
                    }

                    Console.WriteLine("                new ArchiveMethod(");
                    Console.WriteLine("                    CompressionMethod.{0}, ", cmpPair.Key);
                    if (cmpPair.Value.Contains(CompressionLevel.High))
                    {
                        Console.WriteLine("                    CompressionLevel.High, ");
                    }
                    else if (cmpPair.Value.Contains(CompressionLevel.Ultra))
                    {
                        Console.WriteLine("                    CompressionLevel.Ultra, ");
                    }
                    else
                    {
                        Console.WriteLine("                    CompressionLevel.?, ");
                    }

                    foreach (var val in cmpPair.Value)
                    {
                        if (val == cmpPair.Value[cmpPair.Value.Count-1])
                        {
                            Console.WriteLine("                    CompressionLevel.{0} ", val);
                        }
                        else
                        {
                            Console.WriteLine("                    CompressionLevel.{0}, ", val);
                        }
                        
                    }
                    if (pair.Value.Keys.Last() == cmpPair.Key)
                    {
                        Console.WriteLine("                   ));");
                    }
                    else
                    {
                        Console.WriteLine("                   ),");
                    }
                }
            }
        }
    }
}
