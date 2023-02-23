# Bifrost Genetics Library
Bifrost Genetics Library is a biomimetic genetic encoder utilizing the same biological processes found in DNA/RNA.

Utilizing four letters and classifying them as nucleotide bases allows us to simulate the hydrogen bond found in the nucleotide pairs of DNA. Using a rolling window against the gene code we can form codons by iterating every three char slots. There are only 24 permutation codons, but a total of 64 possible codons. For example: including AAA, GGG, TTT, and CCC as valid codons.

Ironically the classical Latin alphabet contains 23 letters, and the 24th one is a break codon enabling the ability to encode Latin or English text

## Example

    using Bifrost.Genetics;
    
    //Encode text to mDNA
    string genetic_code = LifeSpark.WriteDNA("hello");
    Console.WriteLine("Genecode: "+genetic_code);
    
    //Form a molecule with the mDNA and retrieve the DNA strand from it
    DNA_Molecule dna = new DNA_Molecule(genetic_code);
    string mDNA = "";
    dna.ForEach(molecule => DNA += molecule.Item1);
    Console.WriteLine("Molecule: "+ DNA);
    
    //mDNA to mRNA conversion
    string rna_genetic_code = LifeSpark.DNAtoRNA(genetic_code);
    
    //Decode genetic code back to english/latin
    string decoded_message = LifeSpark.ReadDNA(dna);
    string decoded_message2 = LifeSpark.ReadRNA(rna_genetic_code);

    Console.WriteLine("Encoded Message: " + genetic_code);
    Console.WriteLine("Decoded DNA Message: " + decoded_message);
    Console.WriteLine("Decoded RNA Message: " + decoded_message2);

    //Construct a genome which contains an array of unique molecules
    Genome genome = new Genome(genetic_code);
    //View the genomes genecode
    Console.WriteLine("Encoded Genome: " + LifeSpark.ExportGenomeData(genome));
