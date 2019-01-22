using AnimalsSupportSystem.Business.Commands;
using AnimalsSupportSystem.Business.Utils.Dto;
using AnimalsSupportSystem.Infrastucture.Context;
using log4net;
using System;

namespace AnimalsSupportSystem.Business.Domain
{
    public  class CommandFactory : ICommandFactory
    {
        private readonly IAnimalSystemDbContextFactory<IAnimalSystemDbContext> _dbContextFactory;
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CommandFactory(IAnimalSystemDbContextFactory<IAnimalSystemDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public IMedicalCommand CreateCommand(object commandType)
        {
            string command = commandType.GetType().Name;
            switch (command)
            {
                case "RequestMapper":
                    LogCommand(command);
                    return new AdoptionRequestCommand(_dbContextFactory, (RequestMapper)commandType);
                case "CleanseAssignmentMapper":
                    LogCommand(command);
                    return new AssignToCleanseCommand(_dbContextFactory, (CleanseAssignmentMapper)commandType);
                case "CleanseByAdoptionCenterMapper":
                    LogCommand(command);
                    return new CleanseByAdoptionCommand(_dbContextFactory, (CleanseByAdoptionCenterMapper)commandType);
                case "AdoptionCenterMapper":
                    LogCommand(command);
                    return new CreateAdoptionCenterCommand(_dbContextFactory, (AdoptionCenterMapper)commandType);
                case "CleanseCenterMapper":
                    LogCommand(command);
                    return new CreateCleansingCenterCommand(_dbContextFactory, (CleanseCenterMapper)commandType);
                case "AnimalsRegisterMapper":
                    LogCommand(command);
                    return new RegisterAnimalCommand(_dbContextFactory, (AnimalsRegisterMapper)commandType);
                default:
                    _log.Error($"Unable to create new command of type '{command}'.");
                    throw new Exception($"Unable to create new command of type '{commandType}'.");
            }
        }
        private void LogCommand(string command)
        {
            _log.Info($"Created command of type: '{command}'");
        }
    }
}
