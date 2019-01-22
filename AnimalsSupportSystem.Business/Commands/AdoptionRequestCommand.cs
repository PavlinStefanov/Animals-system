using AnimalsSupportSystem.Business.Domain;
using AnimalsSupportSystem.Infrastucture.Context;
using AnimalsSupportSystem.Business.Utils;
using System;
using AnimalsSupportSystem.Business.Utils.Dto;
using log4net;

namespace AnimalsSupportSystem.Business.Commands
{
    public class AdoptionRequestCommand : IMedicalCommand
    {
        private readonly IAnimalSystemDbContextFactory<IAnimalSystemDbContext> _dbContextFactory;
        private readonly RequestMapper _request;
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AdoptionRequestCommand(IAnimalSystemDbContextFactory<IAnimalSystemDbContext> dbContextFactory, RequestMapper request)
        {
            _dbContextFactory = dbContextFactory;
            _request = request;
            IsCompleted = false;
        }

        public bool IsCompleted { get; set; }

        public void Execute()
        {
            try
            {
                using (var dbContext = _dbContextFactory.Create())
                {
                    dbContext.Requests.Add(_request.ToEntity());
                    dbContext.Commit();
                }
                IsCompleted = true;
                _log.Info("Adoption Request was saved to the database.");
            }
            catch (Exception ex)
            {
                _log.Error($"Unable to create new Request for Customer " +
                    $"'{string.Concat(_request.Reciever.FirstName, " ", _request.Reciever.LastName)}' in the database", ex);

                throw new Exception($"Unable to create new Request for Customer " +
                    $"'{string.Concat(_request.Reciever.FirstName, " ", _request.Reciever.LastName)}'", ex);
            }
        }
    }
}
