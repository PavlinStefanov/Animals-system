using AnimalsSupportSystem.Business.Domain;
using AnimalsSupportSystem.Business.Utils.Dto;
using AnimalsSupportSystem.Infrastucture.Context;
using log4net;
using System;
using System.Linq;

namespace AnimalsSupportSystem.Business.Commands
{
    public class CleanseByAdoptionCommand : IMedicalCommand
    {
        private readonly IAnimalSystemDbContextFactory<IAnimalSystemDbContext> _dbContextFactory;
        private readonly CleanseByAdoptionCenterMapper _cleanseCenter;
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CleanseByAdoptionCommand(IAnimalSystemDbContextFactory<IAnimalSystemDbContext> dbContextFactory, CleanseByAdoptionCenterMapper cleanseCenter)
        {
            _dbContextFactory = dbContextFactory;
            _cleanseCenter = cleanseCenter;
            IsCompleted = false;
        }
        public bool IsCompleted { get; set; }

        public void Execute()
        {
            try
            {
                using (var dbContext = _dbContextFactory.Create())
                {
                    var center = dbContext.CleanseCenters.FirstOrDefault(x => x.Name == _cleanseCenter.CleanseCenter);

                    center.Animals.Where(x => !x.IsCleansed && _cleanseCenter.Animals.Contains(x.ID))
                        .ToList()
                        .ForEach(animal =>
                        {
                            animal.IsCleansed = true;
                        });

                    dbContext.Commit();
                }

                IsCompleted = true;
                _log.Info("Animals by given adoption center was set to cleansed in the database.");
            }
            catch (Exception ex)
            {
                _log.Error("Unable to Cleanse animals by given adoptiob center in the database.", ex);
                throw new Exception("Unable to Cleanse animals by given adoptiob center.", ex);
            }
        }
    }
}
