using AnimalsSupportSystem.Infrastucture.Model;
using System;
using System.Data.Entity;

namespace AnimalsSupportSystem.Infrastucture.Context
{
    public interface IAnimalSystemDbContext : IDisposable
    {
        #region Entity Sets
        IDbSet<Reciever> Recievers { get; set; }
        IDbSet<Request> Requests { get; set; }
        IDbSet<RequestDetails> RequestDetails { get; set; }
        IDbSet<AnimalRegister> AnimalRegisters { get; set; }
        IDbSet<CleanseCenter> CleanseCenters { get; set; }
        IDbSet<AdoptionCenter> AdoptionCenters { get; set; }
        IDbSet<Desease> Deseases { get; set; }
        #endregion

        void Commit();
    }
}
