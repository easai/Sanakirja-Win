namespace Sanakirja
{
    class Sana
    {
        public string En { get; set; }
        public string Fi { get; set; }

        public Sana() { }

        public Sana(string fi, string en)
        {
            Fi = fi;
            En = en;
        }

    }
}
