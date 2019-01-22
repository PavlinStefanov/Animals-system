using AnimalsSupportSystem.Business.Domain;
using AnimalsSupportSystem.Business.Utils.Dto;
using AnimalsSupportSystem.Infrastucture.Context;
using log4net;
using System;
using System.Linq;

namespace AnimalsSupportSystem.Business.Commands
{
    public class AssignToCleanseCommand : IMedicalCommand
    {
        private readonly CleanseAssignmentMapper _assignment;
        private readonly IAnimalSystemDbContextFactory<IAnimalSystemDbContext> _dbContextFactory;
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AssignToCleanseCommand(IAnimalSystemDbContextFactory<IAnimalSystemDbContext> dbContextFactory, CleanseAssignmentMapper assignment)
        {
            _dbContextFactory = dbContextFactory;
            _assignment = assignment;
            IsCompleted = false;
        }

        public bool IsCompleted { get; set; }

        public void Execute()
        {
            try
            {
                using (var dbContext = _dbContextFactory.Create())
                {
                    var cleanseCenter = dbContext.CleanseCenters.FirstOrDefault(x => x.Name == _assignment.CleanseCenter);
                    var animals = dbContext.AnimalRegisters.Where(x => _assignment.Animals.Contains(x.ID));

                    animals.ToList().ForEach(x =>
                    {
                        x.CleanseCenterID = cleanseCenter.ID;
                    });

                    dbContext.Commit();
                }

                IsCompleted = true;
                _log.Info($"Animals was assigned to the Cleanse center: '{_assignment.CleanseCenter}' in the database.");
            }
            catch (Exception ex)
            {
                _log.Error($"Unable to Assign animals to cleanse center '{_assignment.CleanseCenter}' in the database", ex);
                throw new Exception($"Unable to Assign animals to cleanse center '{_assignment.CleanseCenter}'", ex);
            }
        }
    }
}
