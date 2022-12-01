using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Genetics
{
    public class DNA
    {
        //4 letters. 2 pairs. A C T G. A-T C-G. Position of each letter in the array is important. 0 & 2 and 1 & 3. Introducing a new letter creates RNA and shuffling the letters positions allows you to fold the gene code from "amino acids" to "proteins"
        public static Nucleotide_Bases nBase = new Nucleotide_Bases(new char[] { 'A', 'C', 'G', 'T' });
        public static Nucleotide_Pairs bonds = new Nucleotide_Pairs(nBase);
        //Looks complicated but it translates to the 24 codon permutations "ACT", "ACG", "ATC", "ATG", "AGC", "AGT", "CAT", "CAG", "CTA", "CTG", "CGA", "CGT", "TAC", "TAG", "TCA", "TCG", "TGA", "TGC", "GAC", "GAT", "GCA", "GCT", "GTA", "GTC" coded dynamically based on pairs provided
        public static readonly string[] CodonPermutations = {
            string.Concat(nBase[0], nBase[1] + nBase[3]),
            string.Concat(nBase[0], nBase[1], nBase[2]),
            string.Concat(nBase[0], nBase[3], nBase[1]),
            string.Concat(nBase[0], nBase[3], nBase[2]),
            string.Concat(nBase[0], nBase[2], nBase[1]),
            string.Concat(nBase[0], nBase[2], nBase[3]),
            string.Concat(nBase[1], nBase[0], nBase[3]),
            string.Concat(nBase[1], nBase[0], nBase[2]),
            string.Concat(nBase[1], nBase[3], nBase[0]),
            string.Concat(nBase[1], nBase[3], nBase[2]),
            string.Concat(nBase[1], nBase[2], nBase[0]),
            string.Concat(nBase[1], nBase[2], nBase[3]),
            string.Concat(nBase[3], nBase[0], nBase[1]),
            string.Concat(nBase[3], nBase[0], nBase[2]),
            string.Concat(nBase[3], nBase[1], nBase[0]),
            string.Concat(nBase[3], nBase[1], nBase[2]),
            string.Concat(nBase[3], nBase[2], nBase[0]),
            string.Concat(nBase[3], nBase[2], nBase[1]),
            string.Concat(nBase[2], nBase[0], nBase[1]),
            string.Concat(nBase[2], nBase[0], nBase[3]),
            string.Concat(nBase[2], nBase[1], nBase[0]),
            string.Concat(nBase[2], nBase[1], nBase[3]),
            string.Concat(nBase[2], nBase[3], nBase[0]),
            string.Concat(nBase[2], nBase[3], nBase[1]) };

        //Dictionary use to decode codons to text format
        public static Codons codons = new Codons(CodonPermutations);

        public static DNA_Molecule Construct_Molecule(string genecode)
        {
            return new DNA_Molecule(genecode);
        }
        public static GeneCode Splicing(string genome_data)
        {
            return (GeneCode)genome_data.Split(nBase[2], nBase[3], nBase[1]).ToHashSet<string>();
        }

    }
}
