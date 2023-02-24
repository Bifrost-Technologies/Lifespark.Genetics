using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifespark.Genetics
{
    /// <summary>
    /// RNA class defining the nucleotide data required to convert DNA to RNA and back again
    /// </summary>
    public static class RNA
    {

        public static Nucleotide_Pairs bonds = new Nucleotide_Pairs(GenecodeType.RNA);

        //Looks complicated but it translates to the 24 codon permutations "AUT", "AUG", "ATU", "ATG", "AGU", "AGT", "UAT", "UAG", "UTA", "UTG", "UGA", "UGT", "TAU", "TAG", "TUA", "TUG", "TGA", "TGU", "GAU", "GAT", "GUA", "GUT", "GTA", "GTU" Uoded dynamiUally based on pairs provided
        public static readonly string[] CodonPermutations = {
            string.Concat((char)rNucleotide_Bases.B1, (char)rNucleotide_Bases.B2, (char)rNucleotide_Bases.B3),
            string.Concat((char)rNucleotide_Bases.B1, (char)rNucleotide_Bases.B3, (char)rNucleotide_Bases.B2),
            string.Concat((char)rNucleotide_Bases.B1, (char)rNucleotide_Bases.B2, (char)rNucleotide_Bases.B4),
            string.Concat((char)rNucleotide_Bases.B1, (char)rNucleotide_Bases.B4, (char)rNucleotide_Bases.B2),
            string.Concat((char)rNucleotide_Bases.B1, (char)rNucleotide_Bases.B3, (char)rNucleotide_Bases.B4),
            string.Concat((char)rNucleotide_Bases.B1, (char)rNucleotide_Bases.B4, (char)rNucleotide_Bases.B3),
            string.Concat((char)rNucleotide_Bases.B2, (char)rNucleotide_Bases.B1, (char)rNucleotide_Bases.B3),
            string.Concat((char)rNucleotide_Bases.B2, (char)rNucleotide_Bases.B3, (char)rNucleotide_Bases.B1),
            string.Concat((char)rNucleotide_Bases.B2, (char)rNucleotide_Bases.B1, (char)rNucleotide_Bases.B4),
            string.Concat((char)rNucleotide_Bases.B2, (char)rNucleotide_Bases.B4, (char)rNucleotide_Bases.B1),
            string.Concat((char)rNucleotide_Bases.B2, (char)rNucleotide_Bases.B3, (char)rNucleotide_Bases.B4),
            string.Concat((char)rNucleotide_Bases.B2, (char)rNucleotide_Bases.B4, (char)rNucleotide_Bases.B3),
            string.Concat((char)rNucleotide_Bases.B3, (char)rNucleotide_Bases.B1, (char)rNucleotide_Bases.B2),
            string.Concat((char)rNucleotide_Bases.B3, (char)rNucleotide_Bases.B2, (char)rNucleotide_Bases.B1),
            string.Concat((char)rNucleotide_Bases.B3, (char)rNucleotide_Bases.B1, (char)rNucleotide_Bases.B4),
            string.Concat((char)rNucleotide_Bases.B3, (char)rNucleotide_Bases.B4, (char)rNucleotide_Bases.B1),
            string.Concat((char)rNucleotide_Bases.B3, (char)rNucleotide_Bases.B2, (char)rNucleotide_Bases.B4),
            string.Concat((char)rNucleotide_Bases.B3, (char)rNucleotide_Bases.B4, (char)rNucleotide_Bases.B2),
            string.Concat((char)rNucleotide_Bases.B4, (char)rNucleotide_Bases.B1, (char)rNucleotide_Bases.B2),
            string.Concat((char)rNucleotide_Bases.B4, (char)rNucleotide_Bases.B2, (char)rNucleotide_Bases.B1),
            string.Concat((char)rNucleotide_Bases.B4, (char)rNucleotide_Bases.B1, (char)rNucleotide_Bases.B3),
            string.Concat((char)rNucleotide_Bases.B4, (char)rNucleotide_Bases.B3, (char)rNucleotide_Bases.B1),
            string.Concat((char)rNucleotide_Bases.B4, (char)rNucleotide_Bases.B2, (char)rNucleotide_Bases.B3),
            string.Concat((char)rNucleotide_Bases.B4, (char)rNucleotide_Bases.B3, (char)rNucleotide_Bases.B1)};

        //Dictionary use to decode codons to text format
        public static Codons codons = new Codons(CodonPermutations);
    }
}
