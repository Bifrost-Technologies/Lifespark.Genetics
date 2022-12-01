using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Genetics
{
    public class LifeSpark
    {
        public static Genome ConstructGenome(string genome_data)
        {
            return new Genome(genome_data);
        }
        public static string ExportGenomeData(Genome _genome)
        {
            string genomeData = string.Empty;
            foreach (var molecule in _genome)
            {
                genomeData += molecule.Keys + DNA.codons.Last().Key;
            }
            return genomeData;
        }
        public static DNA_Molecule RNAtoDNA(string _RNA)
        {
            //mDNA
            return new DNA_Molecule(Enzymes.PolymeraseDNAtranslation(_RNA));
        }
        public static string DNAtoRNA(string _DNA)
        {
            //mRNA
            return Enzymes.PolymeraseRNAtranslation(_DNA);
        }
        public static string WriteDNA(string text)
        {
            string decodedRNA = String.Empty;
            foreach (char letter in text)
            {
                decodedRNA += DNA.codons.Where(e => e.Value == letter).Single().Key;
            }
            return decodedRNA;
        }
        public static string WriteRNA(string text)
        {
            string decodedRNA = String.Empty;
            foreach (char letter in text)
            {
                decodedRNA += RNA.codons.Where(e => e.Value == letter).Single().Key;
            }
            return decodedRNA;
        }
        public static string ReadDNA(DNA_Molecule _DNA)
        {
            return Enzymes.PolymeraseDecode(_DNA);
        }
        public static string ReadRNA(string _RNA)
        {
            return Enzymes.PolymeraseDecode(_RNA);
        }
    }
}
