namespace Lifespark.Genetics
{
    /// <summary>
    /// DNA class defining the nucleotide data required to simulate the hydrogen bonds in the double helix
    /// </summary>
    public static class DNA
    {
        public static Nucleotide_Pairs bonds = new Nucleotide_Pairs(GenecodeType.DNA);

        // Generate all 64 codon combinations (e.g., AAA, AAC, ..., TTT)
        public static readonly string[] Codons = GenerateAllCodons();

        // Dictionary used to decode codons via mapping to Base64 characters
        public static Codons codons = new Codons(Codons);

        /// <summary>
        /// Construct a DNA molecule with genecode.
        /// </summary>
        /// <param name="genecode"></param>
        /// <returns></returns>
        public static Chromosome Construct_Molecule(string genecode)
        {
            return new Chromosome(genecode);
        }

        /// <summary>
        /// Used in the helicase enzyme and unique to DNA only.
        /// Splits the input genome_data based on nucleotide 'separators'.
        /// (Note: Adjust the separators as needed for your use case.)
        /// </summary>
        public static GeneCode Splicing(string genome_data)
        {
            // Get the last codon from DNA codons list
            string breakCodon = DNA.codons.Last().Item1;

            // Create a string representing the triple break codon (e.g., "AAA")
            string tripleBreakCodon = string.Concat(Enumerable.Repeat(breakCodon, 3));

            // Split genome_data using the triple break codon
            return new GeneCode(
                genome_data.Split(new string[] { tripleBreakCodon }, StringSplitOptions.RemoveEmptyEntries)
                .ToHashSet<string>());
        }


        /// <summary>
        /// Generates all 64 possible codon combinations (including repeats)
        /// from the nucleotide bases A, C, G, and T.
        /// </summary>
        private static string[] GenerateAllCodons()
        {
            char[] bases = { (char)Nucleotide_Bases.B1, (char)Nucleotide_Bases.B2, (char)Nucleotide_Bases.B3, (char)Nucleotide_Bases.B4 };
            // Using LINQ to generate the combinations in a concise manner.
            var codonList = from b1 in bases
                            from b2 in bases
                            from b3 in bases
                            select new string(new[] { b1, b2, b3 });

            return codonList.ToArray();

        }
    }
}
