using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiBa_Lib
{
    class Investasi
    {
        #region data members
        int idInvestasi;
        string jenisInvestasi;
        double nominalInvestasi;
        Pengguna idPengguna;


        #endregion

        #region constructors
        public Investasi(int idInvestasi, string jenisInvestasi, double nominalInvestasi, Pengguna idPengguna)
        {
            IdInvestasi = idInvestasi;
            JenisInvestasi = jenisInvestasi;
            NominalInvestasi = nominalInvestasi;
            IdPengguna = idPengguna;
        }

        public Investasi()
        {
            this.IdInvestasi = 0;
            this.JenisInvestasi = "";
            this.NominalInvestasi = 0.0;
            this.IdPengguna = null;
        }
        #endregion

        #region properties
        public int IdInvestasi { get => idInvestasi; set => idInvestasi = value; }
        public string JenisInvestasi { get => jenisInvestasi; set => jenisInvestasi = value; }
        public double NominalInvestasi { get => nominalInvestasi; set => nominalInvestasi = value; }
        public Pengguna IdPengguna { get => idPengguna; set => idPengguna = value; }
        #endregion

        #region methods

        #endregion
    }
}
