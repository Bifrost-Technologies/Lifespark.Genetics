namespace Lifespark.Genetics
{
    public class GeneCode : HashSet<string>
    {
        public GeneCode(HashSet<string> rawGenecode)
        {
            foreach (var molecule in rawGenecode)
                Add(molecule);
        }
    }
    /// <summary>
    /// DNA Nucleotide Bases
    /// </summary>
    public enum Nucleotide_Bases
    {
        B1 = 'A',
        B2 = 'C',
        B3 = 'G',
        B4 = 'T'
    }

    /// <summary>
    /// RNA Nucleotide Bases
    /// </summary>
    public enum rNucleotide_Bases
    {
        B1 = 'A',
        B2 = 'U',
        B3 = 'G',
        B4 = 'T'
    }

    /// <summary>
    /// Genetype enum
    /// </summary>
    public enum GenecodeType
    {
        RNA,
        DNA
    }

    /// <summary>
    /// Nucleotide pairs used to simulate the hydrogen bonds in DNA.
    /// </summary>
    public class Nucleotide_Pairs : Dictionary<char, char>
    {
        public Nucleotide_Pairs(GenecodeType gtype)
        {
            if (gtype == GenecodeType.DNA)
            {
                this.Add((char)Nucleotide_Bases.B1, (char)Nucleotide_Bases.B4); // A-T
                this.Add((char)Nucleotide_Bases.B2, (char)Nucleotide_Bases.B3); // C-G
                this.Add((char)Nucleotide_Bases.B3, (char)Nucleotide_Bases.B2); // G-C
                this.Add((char)Nucleotide_Bases.B4, (char)Nucleotide_Bases.B1); // T-A
            }
            else
            {
                this.Add((char)rNucleotide_Bases.B1, (char)rNucleotide_Bases.B4);
                this.Add((char)rNucleotide_Bases.B2, (char)rNucleotide_Bases.B3);
                this.Add((char)rNucleotide_Bases.B3, (char)rNucleotide_Bases.B2);
                this.Add((char)rNucleotide_Bases.B4, (char)rNucleotide_Bases.B1);
            }
        }
    }

    /// <summary>
    /// Codon Dictionary - Contains the codons and the characters they represent.
    /// Here, we map each codon to a unique character from a Base64 alphabet.
    /// </summary>
    public class Codons : List<Tuple<string, char>>
    {
        // The standard Base64 alphabet (64 unique characters).
        private readonly string Base64Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

        public Codons(string[] codons)
        {
            if (codons.Length != 64)
            {
                throw new ArgumentException("Codon permutations array must have 64 elements.");
            }

            // Map each codon (from the permutations array) to the corresponding Base64 character.
            for (int i = 0; i < codons.Length; i++)
            {
                Add(new Tuple<string, char>(codons[i], Base64Alphabet[i]));
            }
        }
    }

    public class Chromosome : List<Tuple<char, char>>
    {
        public Chromosome(string DNA_strand_data)
        {
            foreach (char c in DNA_strand_data)
            {
                Add(new Tuple<char, char>(c, DNA.bonds[c]));
            }
        }
    }
    public class Genome : List<Chromosome>
    {
        public Genome(string genome_data)
        {
            string breakcodon = DNA.codons.Last().Item1;
            string triplebreak = string.Concat(Enumerable.Repeat(breakcodon, 3));

            if (genome_data.Contains(triplebreak))
            {
                foreach (string item in DNA.Splicing(genome_data))
                {
                    Chromosome _DNA_Molecule = new Chromosome(item);
                    if (_DNA_Molecule != null)
                    {
                        Add(_DNA_Molecule);
                    }
                }

                return;
            }
            else
            {
                Chromosome _DNA_Molecule = new Chromosome(new GeneCode(new HashSet<string> { genome_data }).First());
                if (_DNA_Molecule != null)
                {
                    Add(_DNA_Molecule);
                }
            }
        }
    }
}
