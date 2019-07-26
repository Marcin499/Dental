using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfDental
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę interfejsu „IDentalService” w kodzie i pliku konfiguracji.
    [ServiceContract]
    public interface IDentalService
    {
        #region Pacjent
        [OperationContract]
        List<PacjentWCF> GetPacjentList();

        [OperationContract]
        Pacjent GetPacjentByID(int id);

        [OperationContract]
        bool PacjentInsert(Pacjent pacjent);

        [OperationContract]
        bool PacjentUpdate(Pacjent pacjent);

        [OperationContract]
        bool PacjentDelete(int id);
        #endregion

        #region Adres
        [OperationContract]
        List<Adres> GetAdresList();
        [OperationContract]
        Adres GetAdresByID(int id);
        [OperationContract]
        bool AdresInsert(Adres adres);
        [OperationContract]
        bool AdresUpdate(Adres adres);
        [OperationContract]
        bool AdresDelete(int id);
        #endregion

    }


    [DataContract]
    public class PacjentWCF
    {
        #region Pacjent
        [DataMember]
        public int PacjentID { get; set; }
        [DataMember]
        public string Imie { get; set; }
        [DataMember]
        public string Nazwisko { get; set; }
        [DataMember]
        public string PESEL { get; set; }
        [DataMember]
        public int Telefon { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Typ { get; set; }
        [DataMember]
        public string Haslo { get; set; }
        [DataMember]
        public string PowtorzHaslo { get; set; }
        #endregion
    }
    public class Adres
    {

        #region Adres
        [DataMember]
        public int AdresID { get; set; }
        [DataMember]
        public string Miasto { get; set; }
        [DataMember]
        public string Wojewodztwo { get; set; }
        [DataMember]
        public string Ulica { get; set; }
        [DataMember]
        public string Numer { get; set; }
        [DataMember]
        public string Kod { get; set; }
        #endregion
    }
}

