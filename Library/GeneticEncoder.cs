using System.Text;

namespace Lifespark.Genetics
{
    public class GeneticEncoder : LifeSparkClient
    {

        /// <summary>
        /// Encodes a string into a Base64 string and writes it to DNA.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public new string WriteDNA(string text)
        {
            return LifeSparkClient.WriteDNA(Convert.ToBase64String(Encoding.UTF8.GetBytes(text)));
        }

        /// <summary>
        /// Ensures the Base64 string has the correct padding by appending '=' characters
        /// so its length is a multiple of 4.
        /// </summary>
        /// <param name="base64NoPadding">The Base64 string without padding.</param>
        /// <returns>The padded Base64 string.</returns>
        public string EnsureBase64Padding(string base64NoPadding)
        {
            int paddingNeeded = (4 - (base64NoPadding.Length % 4)) % 4;
            return base64NoPadding + new string('=', paddingNeeded);
        }

        /// <summary>
        /// Decodes a Base64 string from mDNA genecode and returns the original string.
        /// </summary>
        /// <param name="genetic_code"></param>
        /// <returns></returns>
        public string ReadDNA(string genetic_code)
        {
            Chromosome dna = new Chromosome(genetic_code);
            string raw_decoded_data = LifeSparkClient.ReadDNA(dna);
            byte[] raw_bytes = Convert.FromBase64String(EnsureBase64Padding(raw_decoded_data));
            string decoded_data = Encoding.UTF8.GetString(raw_bytes);
            return decoded_data;
        }

        /// <summary>
        /// Decodes a Base64 string from DNA and returns the original string.
        /// </summary>
        /// <param name="genetic_code"></param>
        /// <returns></returns>
        public new string ReadDNA(Chromosome dna)
        {
            string raw_decoded_data = LifeSparkClient.ReadDNA(dna);
            byte[] raw_bytes = Convert.FromBase64String(EnsureBase64Padding(raw_decoded_data));
            string decoded_data = Encoding.UTF8.GetString(raw_bytes);
            return decoded_data;
        }
    }
}
