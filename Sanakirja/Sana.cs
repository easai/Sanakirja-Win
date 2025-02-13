namespace Sanakirja
{
    /// <summary>
    /// Represents a word with its English and Finnish translations.
    /// </summary>
    class Sana
    {
        /// <summary>
        /// Gets or sets the English translation of the word.
        /// </summary>
        public string En { get; set; }

        /// <summary>
        /// Gets or sets the Finnish translation of the word.
        /// </summary>
        public string Fi { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sana"/> class.
        /// </summary>
        public Sana() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sana"/> class with specified translations.
        /// </summary>
        /// <param name="fi">The Finnish translation of the word.</param>
        /// <param name="en">The English translation of the word.</param>
        public Sana(string fi, string en)
        {
            Fi = fi;
            En = en;
        }
    }
}