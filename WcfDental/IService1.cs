using DAL.Model;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfDental
{
    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        List<Pacjent> GetPacjentList();

        [OperationContract]
        Pacjent GetPacjentByID(int id);

        [OperationContract]
        void PacjentInsert(Pacjent pacjent);

        [OperationContract]
        void PacjentUpdate(Pacjent pacjent);

        [OperationContract]
        void PacjentDelete(int id);


    }

    [DataContract]
    public class Contract
    {
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
        public string Typ { get; set; } = null;
        [DataMember]
        public string Haslo { get; set; }
        [DataMember]
        public string PowtorzHaslo { get; set; }
    }
}
