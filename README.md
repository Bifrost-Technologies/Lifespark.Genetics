# Lifespark Genetics

## Overview

Lifespark Genetics is a biomimetic genetics library & encoder that can encode data in to synthetic genetic code. It maps codons (triplets of nucleotide bases: A, C, G, T) to **Base64 characters**, allowing efficient transformation between DNA sequences, Base64 encoding, and text or data.

### API Methods
- ```ConstructGenome(string genome_data)```
Constructs a Genome object from a string of genome data. This allows you to create a genome even with a single DNA molecule.
- ```ExportGenomeData(Genome _genome)```
Exports the raw genetic code by iterating over each Chromosome in the genome. It concatenates the DNA sequences of the molecules and appends the designated triple-break codons (the last codon from the codon mapping * 3) after each chromosome.
- ```RNAtoDNA(string _RNA)``` & ```DNAtoRNA(string _DNA)```
Provides conversion methods between RNA and DNA. Using enzyme translation (simulated by the Enzymes class), these methods convert messenger RNA (mRNA) to messenger DNA (mDNA) and vice versa.
- ```WriteDNA(string text)```
Encodes a text string into a DNA sequence. Each character (after trimming any padding) is mapped to its associated DNA codon based on the Base64-to-codon mapping.
- ```WriteRNA(string text)```
Similar to WriteDNA but for RNA. It maps each character (again trimming any padding) to its corresponding RNA codon.
- ```ReadDNA(Chromosome _DNA)``` & ```ReadRNA(string _RNA)```
Decodes a DNA (or RNA) sequence back into text using polymerase decoding logic.

This library enables the conversion:
- **String/Bytes → Base64 → DNA**
- **DNA → Base64 → String/Bytes**

By leveraging codons and mapping them to Base64 characters, we maintain a structured approach to encoding biological-like sequences while ensuring compatibility with standard data representations.

---

## Features

 **Codon-to-Base64 Mapping**  
Each possible DNA codon (64 combinations) is assigned a unique Base64 character for efficient encoding.

 **Base64 Encoding & Decoding with DNA Integration**  
Encodes strings into Base64 while mapping back into structured DNA sequences.

 **Reverse Decoding from DNA Sequences**  
Takes DNA-based sequences and converts them back into readable text.

 **Splicing & Codon Extraction**  
Includes methods for splitting genome data using break codons and nucleotide-based delimiters.


## Example
```
    using Lifespark.Genetics;
    
    //Encode text or data to mDNA
    var lifespark = new GeneticEncoder();
    string genetic_code = lifespark.WriteDNA("hello");
    Console.WriteLine("Genecode: "+genetic_code);
    
    //Form a chromosome with the mDNA and retrieve the DNA strand from it
    Chromosome dna = new Chromosome(genetic_code);
    string mDNA = "";
    dna.ForEach(molecule => mDNA += molecule.Item1);
    Console.WriteLine("Molecule: "+ mDNA);
    
    //mDNA to mRNA conversion
    string rna_genetic_code = lifespark.DNAtoRNA(genetic_code);
    
    //Decode genetic code back to text or bytes
    string decoded_message = lifespark.ReadDNA(dna);
    string decoded_message2 = lifespark.ReadRNA(rna_genetic_code);

    Console.WriteLine("Encoded Message: " + genetic_code);
    Console.WriteLine("Decoded DNA Message: " + decoded_message);
    Console.WriteLine("Decoded RNA Message: " + decoded_message2);

    //Construct a genome which contains an array of unique chromosomes
    Genome genome = new Genome(genetic_code);
    //View the genomes genecode
    Console.WriteLine("Encoded Genome: " + lifespark.ExportGenomeData(genome));
```
