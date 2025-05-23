﻿namespace Lifespark.Genetics
{
    /// <summary>
    /// Lifespark Genetics Client
    /// </summary>
    public class LifeSparkClient
    {
        /// <summary>
        /// Construct a genome with genome_data. A genome can be constructed with a single DNA molecule too
        /// </summary>
        /// <param name="genome_data"></param>
        /// <returns></returns>
        public static Genome ConstructGenome(string genome_data)
        {
            return new Genome(genome_data);
        }
        /// <summary>
        /// Export Genome data as raw genetic code with DNA bases
        /// </summary>
        /// <param name="_genome"></param>
        /// <returns></returns>
        public static string ExportGenomeData(Genome _genome)
        {
            string genomeData = string.Empty;
            foreach (Chromosome molecule in _genome)
            {
                string breakcodon = DNA.codons.Last().Item1;
                string triplebreak = string.Concat(Enumerable.Repeat(breakcodon, 3));
                string rawDNA = String.Empty;
                molecule.ForEach(molecule => rawDNA += molecule.Item1);

                genomeData += rawDNA + triplebreak;
            }
            return genomeData;
        }
        /// <summary>
        /// Convert mRNA to mDNA
        /// </summary>
        /// <param name="_RNA"></param>
        /// <returns></returns>
        public static Chromosome RNAtoDNA(string _RNA)
        {
            //mDNA
            return new Chromosome(Enzymes.PolymeraseDNAtranslation(_RNA));
        }
        /// <summary>
        /// Convert mDNA to mRNA
        /// </summary>
        /// <param name="_DNA"></param>
        /// <returns></returns>
        public static string DNAtoRNA(string _DNA)
        {
            //mRNA
            return Enzymes.PolymeraseRNAtranslation(_DNA);
        }

        /// <summary>
        /// Write text to mDNA
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string WriteDNA(string text)
        {
            string encodedDNA = String.Empty;

            foreach (char letter in text.Trim('='))
            {
                encodedDNA += DNA.codons.Single(e => e.Item2 == letter).Item1;
            }
            return encodedDNA;
        }

        /// <summary>
        /// Write text to mRNA
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string WriteRNA(string text)
        {
            string encodedRNA = String.Empty;
            foreach (char letter in text.Trim('='))
            {
                encodedRNA += RNA.codons.Single(e => e.Item2 == letter).Item1;
            }
            return encodedRNA;
        }

        /// <summary>
        /// Read the DNA as english text
        /// </summary>
        /// <param name="_DNA"></param>
        /// <returns></returns>
        public static string ReadDNA(Chromosome _DNA)
        {
            return Enzymes.PolymeraseDecode(_DNA);
        }

        /// <summary>
        /// Read the RNA as english text
        /// </summary>
        /// <param name="_RNA"></param>
        /// <returns></returns>
        public static string ReadRNA(string _RNA)
        {
            return Enzymes.PolymeraseDecode(_RNA);
        }
    }
}
