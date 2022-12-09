using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiBa_Lib
{
    class Deposito
    {
        #region data members
        int idDeposito;
        Tabungan noRekening;
        string jatuhTempo;
        double nominal;
        double bunga;
        string status;
        DateTime tglBuat;
        DateTime tglPerubahan;
        Employee verivikatorBuka;
        Employee verivikatorCair;   
        #endregion

        #region constructors
        public Deposito(int idDeposito, Tabungan noRekening, string jatuhTempo, double nominal, double bunga, string status, DateTime tglBuat, DateTime tglPerubahan, Employee verivikatorBuka, Employee verivikatorCair)
        {
            IdDeposito = idDeposito;
            NoRekening = noRekening;
            JatuhTempo = jatuhTempo;
            Nominal = nominal;
            Bunga = bunga;
            Status = status;
            TglBuat = tglBuat;
            TglPerubahan = tglPerubahan;
            VerivikatorBuka = verivikatorBuka;
            VerivikatorCair = verivikatorCair;
        }

        public Deposito()
        {
            this.IdDeposito = 0;
            this.NoRekening = null;
            this.JatuhTempo = "";
            this.Nominal = 0.0;
            this.Bunga = 0.0;
            this.Status = "";
            this.TglBuat = DateTime.Now;
            this.TglPerubahan = DateTime.Now;
            this.VerivikatorBuka = null;
            this.VerivikatorCair = null;
        }
        #endregion

        #region properties
        public int IdDeposito { get => idDeposito; set => idDeposito = value; }
        public Tabungan NoRekening { get => noRekening; set => noRekening = value; }
        public string JatuhTempo { get => jatuhTempo; set => jatuhTempo = value; }
        public double Nominal { get => nominal; set => nominal = value; }
        public double Bunga { get => bunga; set => bunga = value; }
        public string Status { get => status; set => status = value; }
        public DateTime TglBuat { get => tglBuat; set => tglBuat = value; }
        public DateTime TglPerubahan { get => tglPerubahan; set => tglPerubahan = value; }
        public Employee VerivikatorBuka { get => verivikatorBuka; set => verivikatorBuka = value; }
        public Employee VerivikatorCair { get => verivikatorCair; set => verivikatorCair = value; }
        #endregion
    }
}
