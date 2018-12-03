using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adt
{
    public class ClubMember
    {
        public int Nr;
        public string FNavn;
        public string LNavn;
        public int Alder;

        public ClubMember(int nr, string fNavn, string lNavn, int alder)
        {
            Nr = nr;
            FNavn = fNavn;
            LNavn = lNavn;
            Alder = alder;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3}", Nr, FNavn, LNavn, Alder);
        }
    }
}
