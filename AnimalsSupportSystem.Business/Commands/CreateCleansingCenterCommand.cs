using AnimalsSupportSystem.Business.Domain;
using AnimalsSupportSystem.Business.Utils.Dto;
using AnimalsSupportSystem.Business.Utils;
using AnimalsSupportSystem.Infrastucture.Context;
using log4net;
using System;

namespace AnimalsSupportSystem.Business.Commands
{
    public class CreateCleansingCenterCommand : IMedicalCommand
    {
        private readonly IAnimalSystemDbContextFactory<IAnimalSystemDbContext> _dbContextFactory;
        private readonly CleanseCenterMapper _cleanse;
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CreateCleansingCenterCommand(IAnimalSystemDbContextFactory<IAnimalSystemDbContext> dbContextFactory, CleanseCenterMapper cleanse)
        {
            _dbContextFactory = dbContextFactory;
            _cleanse = cleanse;
            IsCompleted = false;
        }
        public bool IsCompleted { get; set; }

        public void Execute()
        {
            try
            {
                using (var dbContext = _dbContextFactory.Create())
                {
                    dbContext.CleanseCenters.Add(_cleanse.ToEntity());
                    dbContext.Commit();
                }

                IsCompleted = true;
                _log.Info($"Created new Cleanse center: '{_cleanse.Name}' in the database.");
            }
            catch (Exception ex)
            {
                _log.Error($"Unable to create new Cleanse center for '{_cleanse.Name}' in the database.", ex);
                throw new Exception($"Unable to create new Cleanse center for '{_cleanse.Name}'.", ex);
            }
        }
    }
}
