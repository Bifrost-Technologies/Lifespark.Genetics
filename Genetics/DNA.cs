using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Genetics
{
    /// <summary>
    /// DNA class defining the nucleotide data required to simulate the hydrogen bonds in the double helix
    /// </summary>
    public static class DNA
    {
        public static Nucleotide_Pairs bonds = new Nucleotide_Pairs(GenecodeType.DNA);
        //Looks complicated but it translates to the 24 codon permutations "ACT", "ACG", "ATC", "ATG", "AGC", "AGT", "CAT", "CAG", "CTA", "CTG", "CGA", "CGT", "TAC", "TAG", "TCA", "TCG", "TGA", "TGC", "GAC", "GAT", "GCA", "GCT", "GTA", "GTC" coded dynamically based on pairs provided
        public static readonly string[] CodonPermutations = {
            string.Concat((char)Nucleotide_Bases.B1, (char)Nucleotide_Bases.B2, (char)Nucleotide_Bases.B3),
            string.Concat((char)Nucleotide_Bases.B1, (char)Nucleotide_Bases.B3, (char)Nucleotide_Bases.B2),
            string.Concat((char)Nucleotide_Bases.B1, (char)Nucleotide_Bases.B2, (char)Nucleotide_Bases.B4),
            string.Concat((char)Nucleotide_Bases.B1, (char)Nucleotide_Bases.B4, (char)Nucleotide_Bases.B2),
            string.Concat((char)Nucleotide_Bases.B1, (char)Nucleotide_Bases.B3, (char)Nucleotide_Bases.B4),
            string.Concat((char)Nucleotide_Bases.B1, (char)Nucleotide_Bases.B4, (char)Nucleotide_Bases.B3),
            string.Concat((char)Nucleotide_Bases.B2, (char)Nucleotide_Bases.B1, (char)Nucleotide_Bases.B3),
            string.Concat((char)Nucleotide_Bases.B2, (char)Nucleotide_Bases.B3, (char)Nucleotide_Bases.B1),
            string.Concat((char)Nucleotide_Bases.B2, (char)Nucleotide_Bases.B1, (char)Nucleotide_Bases.B4),
            string.Concat((char)Nucleotide_Bases.B2, (char)Nucleotide_Bases.B4, (char)Nucleotide_Bases.B1),
            string.Concat((char)Nucleotide_Bases.B2, (char)Nucleotide_Bases.B3, (char)Nucleotide_Bases.B4),
            string.Concat((char)Nucleotide_Bases.B2, (char)Nucleotide_Bases.B4, (char)Nucleotide_Bases.B3),
            string.Concat((char)Nucleotide_Bases.B3, (char)Nucleotide_Bases.B1, (char)Nucleotide_Bases.B2),
            string.Concat((char)Nucleotide_Bases.B3, (char)Nucleotide_Bases.B2, (char)Nucleotide_Bases.B1),
            string.Concat((char)Nucleotide_Bases.B3, (char)Nucleotide_Bases.B1, (char)Nucleotide_Bases.B4),
            string.Concat((char)Nucleotide_Bases.B3, (char)Nucleotide_Bases.B4, (char)Nucleotide_Bases.B1),
            string.Concat((char)Nucleotide_Bases.B3, (char)Nucleotide_Bases.B2, (char)Nucleotide_Bases.B4),
            string.Concat((char)Nucleotide_Bases.B3, (char)Nucleotide_Bases.B4, (char)Nucleotide_Bases.B2),
            string.Concat((char)Nucleotide_Bases.B4, (char)Nucleotide_Bases.B1, (char)Nucleotide_Bases.B2),
            string.Concat((char)Nucleotide_Bases.B4, (char)Nucleotide_Bases.B2, (char)Nucleotide_Bases.B1),
            string.Concat((char)Nucleotide_Bases.B4, (char)Nucleotide_Bases.B1, (char)Nucleotide_Bases.B3),
            string.Concat((char)Nucleotide_Bases.B4, (char)Nucleotide_Bases.B3, (char)Nucleotide_Bases.B1),
            string.Concat((char)Nucleotide_Bases.B4, (char)Nucleotide_Bases.B2, (char)Nucleotide_Bases.B3),
            string.Concat((char)Nucleotide_Bases.B4, (char)Nucleotide_Bases.B3, (char)Nucleotide_Bases.B1)};

        //Dictionary used to decode codons to text format
        public static Codons codons = new Codons(CodonPermutations);

        /// <summary>
        /// Used in the helicase enzyme and unique to DNA only
        /// </summary>
        /// <param name="genome_data"></param>
        /// <returns></returns>
        public static GeneCode Splicing(string genome_data)
        {
            return new GeneCode(genome_data.Split((char)Nucleotide_Bases.B3, (char)Nucleotide_Bases.B4, (char)Nucleotide_Bases.B2).ToHashSet<string>());
        }

    }
}
