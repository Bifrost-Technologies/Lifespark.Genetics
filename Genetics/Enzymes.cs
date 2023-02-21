using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Genetics
{
    public class Enzymes
    {
        /// <summary>
        /// Enzyme used to fork an existing molecule for replication or other processes
        /// </summary>
        /// <param name="_DNA_Molecule"></param>
        /// <returns></returns>
        public static KeyValuePair<string, string> Helicase(DNA_Molecule _DNA_Molecule)
        {
            string A_strand = string.Empty;
            string Z_strand = string.Empty;
            foreach(var pair in _DNA_Molecule.ToList())
            {
                A_strand += pair.Item1;
                Z_strand += pair.Item2;
            }

            return new KeyValuePair<string, string>(A_strand, Z_strand);
        }

        /// <summary>
        /// Translates DNA to RNA
        /// </summary>
        /// <param name="_DNA"></param>
        /// <returns></returns>
        public static string PolymeraseRNAtranslation(string _DNA)
        {
            
            return _DNA.Replace((char)Nucleotide_Bases.B2, (char)rNucleotide_Bases.B2);
        }

        /// <summary>
        /// Translates RNA to DNA
        /// </summary>
        /// <param name="_RNA"></param>
        /// <returns></returns>
        public static string PolymeraseDNAtranslation(string _RNA)
        {
            return _RNA.Replace((char)rNucleotide_Bases.B2, (char)Nucleotide_Bases.B2);
        }

        /// <summary>
        /// Enzyme used to Read/Check DNA/RNA - Tuned for read only
        /// </summary>
        /// <param name="_DNA_Molecule"></param>
        /// <returns></returns>
        public static string PolymeraseDecode(DNA_Molecule _DNA_Molecule)
        {
            KeyValuePair<string, string> ForkedMolecule = Helicase(_DNA_Molecule);
            string DNA_strand = ForkedMolecule.Key;

                string _RNA = PolymeraseRNAtranslation(DNA_strand);
                const int codon_struct = 3;
                string codon = "";
                string decoded_GeneCode = "";
                //Rolling window codon decoding using codon dictionary to get the translation
                foreach (var pair in _RNA)
                {
                    codon += pair;
                    if (codon.Length == codon_struct)
                    { 
                       
                        decoded_GeneCode += RNA.codons.Single(e => e.Item1 == codon).Item2;
                        codon = "";
                       
                    }
                }
           
                return decoded_GeneCode;
      

        }

        /// <summary>
        /// RNA variant of dna polymerase enzyme
        /// </summary>
        /// <param name="_RNA"></param>
        /// <returns></returns>
        public static string PolymeraseDecode(string _RNA)
        {
            const int codon_struct = 3;
            string codon = "";
            string decoded_GeneCode = "";
            //Rolling window codon decoding using codon dictionary to get the translation
            foreach (var pair in _RNA)
            {
                codon += pair;
                if (codon.Length == codon_struct)
                {

                    decoded_GeneCode += RNA.codons.Single(e => e.Item1 == codon).Item2;
                    codon = "";

                }
            }

            return decoded_GeneCode;
        }
    }
}
