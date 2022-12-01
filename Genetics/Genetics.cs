namespace Bifrost.Genetics
{
    public class GeneCode : HashSet<string> { }
    public class Nucleotide_Bases : List<char>
    {
        //A C G T are the original Nucleotide bases found in reality
        //You can change this letters to what ever you want just make sure each one is unique. No duplicates
        public Nucleotide_Bases(char[] bases)
        {
            foreach (var _base in bases)
            {
                Add(_base);
            }
        }
    }
    public class Nucleotide_Pairs : Dictionary<char, char>
    {
        //A C G T are the original Nucleotide bases found in reality
        //You can change this letters to what ever you want just make sure each one is unique. No duplicates
        public Nucleotide_Pairs(Nucleotide_Bases bases)
        {
            int p = 0;
            var basesReversed = bases;
            basesReversed.Reverse();

            foreach (var baseNucleotide in bases)
            {
                this.Add(baseNucleotide, basesReversed[p]);
                p++;
            }
        }
    }
    public class Codons : Dictionary<string, char>
    {
        //Max storage of codons is 64
        //Classical Latin Alphabet corresponding to the 23 codons. The 24th codon is a break codon.
        char[] Alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'v', 'x', 'y', 'z', '|' };
        public Codons(string[] codonPermutations)
        {
            int count = 0;
            foreach (var codon in codonPermutations)
            {
                Add(codon, Alphabet[count]);
                count++;
            }
        }
    }
    public class DNA_Molecule : Dictionary<char, char>
    {
        public bool Stable { get; set; }
        public DNA_Molecule(string DNA_strand_data)
        {
            foreach (char pair in DNA_strand_data)
            {
                this.Add(pair, DNA.bonds[pair]);
            }
            Stable = Enzymes.PolymeraseCheck(this);
        }
    }
    public class Genome : HashSet<DNA_Molecule>
    {
        public Genome(string genome_data)
        {
            //Genome data consists of an array of DNA molecules. We separate them as raw gene code so they can undergo replication to form the double helix
            GeneCode raw_dna_molecules = DNA.Splicing(genome_data);

            foreach (var genecode in raw_dna_molecules)
            {
                //Autosomes and Allosomes are packed into double helix DNA - They undergo Primase, Polymerase, Ligase to form the double helix
                DNA_Molecule autosome = DNA.Construct_Molecule(genecode);
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