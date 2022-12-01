using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Genetics
{
    public class Enzymes
    {
        //Enzyme used to fork an existing molecule for replication or other processes
        public static KeyValuePair<string, string> Helicase(Dictionary<char, char> _DNA_Molecule)
        {
            string A_strand = string.Concat(_DNA_Molecule.Keys);
            string Z_strand = string.Concat(_DNA_Molecule.Values);
            return new KeyValuePair<string, string>(A_strand, Z_strand);
        }

        //Enzyme used to Read/Check DNA/RNA - Tuned for check only
        public static bool PolymeraseCheck(Dictionary<char, char> _DNA_Molecule)
        {
            //Both sides (of the helix get split - Similar process to the Helicase enzyme
            KeyValuePair<string, string> ForkedMolecule = Helicase(_DNA_Molecule);
            string A_strand = ForkedMolecule.Key;
            string Z_strand = ForkedMolecule.Value;

            //The Z side is reversed to compare authenticity of the DNA molecule
            Z_strand.Reverse();

            //If both strands match than the genetic code is authentic and can be replicated
            if (A_strand == Z_strand)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static string PolymeraseRNAtranslation(string _DNA)
        {
            return _DNA.Replace(DNA.nBase[1], RNA.nBase[1]);
        }
        public static string PolymeraseDNAtranslation(string _RNA)
        {
            return _RNA.Replace(RNA.nBase[1], DNA.nBase[1]);
        }
        //Enzyme used to Read/Check DNA/RNA - Tuned for read only
        public static string PolymeraseDecode(Dictionary<char, char> _DNA_Molecule)
        {
            //Both sides (of the helix get split - Similar process to the Helicase enzyme
            KeyValuePair<string, string> ForkedMolecule = Helicase(_DNA_Molecule);
            string A_strand = ForkedMolecule.Key;
            string Z_strand = ForkedMolecule.Value;

            //The Z side is reversed to compare authenticity of the DNA molecule
            Z_strand.Reverse();

            //If both strands match we begin decyphering the RNA
            if (A_strand == Z_strand)
            {
                //transistion occurs to RNA
                string _RNA = ForkedMolecule.Key.Replace('C', 'U');
                const int codon_struct = 3;
                int codon_count = 0;
                string codon = "";
                string decoded_GeneCode = "";
                //Rolling window codon decoding using codon dictionary to get the translation
                foreach (var pair in _RNA)
                {
                    if (codon.Length == codon_struct)
                    {
                        decoded_GeneCode += RNA.codons[codon];
                        codon = String.Empty;
                        codon_count = 0;
                    }
                    else
                    {
                        codon += pair;
                        codon_count++;
                    }
                }

                return decoded_GeneCode;
            }
            else
            {
                return String.Empty;
            }

        }
        //RNA variant of dna polymerase enzyme
        public static string PolymeraseDecode(string _RNA)
        {
            const int codon_struct = 3;
            int codon_count = 0;
            string codon = "";
            string decoded_GeneCode = "";
            //Rolling window codon decoding using codon dictionary to get the translation
            foreach (var pair in _RNA)
            {
                if (codon.Length == codon_struct)
                {
                    decoded_GeneCode = decoded_GeneCode + DNA.codons[codon];
                    codon = "";
                    codon_count = 0;
                }
                else
                {
                    codon = codon + pair;
                    codon_count++;
                }
            }

            return decoded_GeneCode;
        }
    }
}
