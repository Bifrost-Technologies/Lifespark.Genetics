namespace Bifrost.Genetics
{
    public class GeneCode : HashSet<string> 
    {
        public GeneCode(HashSet<string> rawGenecode) 
        {
            foreach(var molecule in rawGenecode)
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
    /// Nucleotide pairs used to simulate the hydrogen bonds in DNA
    /// </summary>
    public class Nucleotide_Pairs : Dictionary<char, char>
    {
        public Nucleotide_Pairs(GenecodeType gtype)
        {
            if (gtype == GenecodeType.DNA)
            {
                this.Add((char)Nucleotide_Bases.B1, (char)Nucleotide_Bases.B4);
                this.Add((char)Nucleotide_Bases.B2, (char)Nucleotide_Bases.B3);
                this.Add((char)Nucleotide_Bases.B3, (char)Nucleotide_Bases.B2);
                this.Add((char)Nucleotide_Bases.B4, (char)Nucleotide_Bases.B1);
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
    /// Codon Dictionary - Contains the codons and the letters they represents
    /// </summary>
    public class Codons : List<Tuple<string, char>>
    {
        //Max storage of codons is 64
        //Classical Latin Alphabet corresponding to the 23 codons. The 24th codon is a break codon.
        char[] Alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'v', 'x', 'y', 'z', '|' };
        public Codons(string[] codonPermutations)
        {
            int count = 0;
            foreach (var codon in codonPermutations)
            {
                Add(new Tuple<string, char>(codon, Alphabet[count]));
                count++;
            }
        }
    }

    /// <summary>
    /// DNA Molecule object containing a double "helix"
    /// </summary>
    public class DNA_Molecule : List<Tuple<char, char>>
    {
        public DNA_Molecule(string DNA_strand_data)
        {
            foreach (char pair in DNA_strand_data)
            {
                this.Add(new Tuple<char, char>(pair, DNA.bonds[pair]));
            }
        }
    }

    /// <summary>
    /// Genome object contains DNA molecules seperated by break codons
    /// </summary>
    public class Genome : List<DNA_Molecule>
    {
        public Genome(string genome_data)
        {
            //Genome data consists of an array of DNA molecules. We separate them as raw gene code so they can undergo replication to form the double helix
            if (genome_data.Contains(DNA.codons.Last().Item2))
            {
                GeneCode raw_dna_molecules = DNA.Splicing(genome_data);

                foreach (var genecode in raw_dna_molecules)
                {
                    //Autosomes and Allosomes are packed into double helix DNA - They undergo Primase, Polymerase, Ligase to form the double helix
                    DNA_Molecule autosome = new (genecode);
                    //If the DNA molecule returns null than it was not authentic DNA & could not be replicated
                    if (autosome != null)
                    {
                        //If the DNA molecule successfully passes Polymerase it will be added to the genome
                        this.Add(autosome);
                    }
                }
            }
            else
            {
                GeneCode raw_single_molecule = new GeneCode(new HashSet<string> { genome_data });
                //Autosomes and Allosomes are packed into double helix DNA - They undergo Primase, Polymerase, Ligase to form the double helix
                DNA_Molecule autosome = new (raw_single_molecule.First());
                //If the DNA molecule returns null than it was not authentic DNA & could not be replicated
                if (autosome != null)
                {
                    //If the DNA molecule successfully passes Polymerase it will be added to the genome
                    this.Add(autosome);
                }
            }
        }
    }
  
   
}