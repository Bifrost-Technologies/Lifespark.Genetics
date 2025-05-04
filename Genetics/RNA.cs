namespace Lifespark.Genetics
{
    /// <summary>
    /// RNA class defining the nucleotide data required to convert DNA to RNA and back again
    /// </summary>
    public static class RNA
    {

        public static Nucleotide_Pairs bonds = new Nucleotide_Pairs(GenecodeType.RNA);

        // Generate all 64 codon combinations (e.g., AAA, AAC, ..., TTT)
        public static readonly string[] Codons = GenerateAllCodons();

        // Dictionary used to decode codons via mapping to Base64 characters
        public static Codons codons = new Codons(Codons);

        /// <summary>
        /// Generates all 64 possible codon combinations (including repeats)
        /// from the nucleotide bases A, C, G, and T.
        /// </summary>
        private static string[] GenerateAllCodons()
        {
            char[] bases = { (char)rNucleotide_Bases.B1, (char)rNucleotide_Bases.B2, (char)rNucleotide_Bases.B3, (char)rNucleotide_Bases.B4 };
            // Using LINQ to generate the combinations in a concise manner.
            var codonList = from b1 in bases
                            from b2 in bases
                            from b3 in bases
                            select new string(new[] { b1, b2, b3 });

            return codonList.ToArray();

        }
    }
}
