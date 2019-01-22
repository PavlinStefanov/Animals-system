using AnimalsSupportSystem.Business.Utils.Dto;
using System.Linq;

namespace AnimalsSupportSystem.Business.Domain
{
    public class MedicalHandler : IMedicalHandler
    {
        private MedicalInvoker _medicalInvoker;
        private CommandsMapper _commands;
        private readonly ICommandFactory _commandFactory;

        public MedicalHandler(CommandsMapper commands, ICommandFactory commandFactory)
        {
            _medicalInvoker = new MedicalInvoker();
            _commands = commands;
            _commandFactory = commandFactory; 
        }

        /// <summary>
        /// 
        /// </summary>
        public void ProcessHandlers()
        {
            HandleCommands();
            _medicalInvoker.ProcessPendingCommands();
        }

        /// <summary>
        /// 
        /// </summary>
        private void HandleCommands()
        {
            HandleAdoptionRequest();
            HandleAssignToCleanseCenter();
            HandleCleanseByAdoptionCenter();
            HandleAdoptionCenterCreation();
            HandleCleanseCenterCreation();
            HandleAnimalCreation();
        }

        /// <summary>
        /// 
        /// </summary>
        private void HandleAdoptionRequest()
        {
            if (_commands.Requests.Any())
            {
                _commands.Requests.ToList()
                    .ForEach(request =>
                    {
                        _medicalInvoker.AddCommand(_commandFactory.CreateCommand(request));
                    });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void HandleAssignToCleanseCenter()
        {
            if(_commands.AssignToCleanse.Any())
            {
                _commands.AssignToCleanse.ToList()
                    .ForEach(assignment =>
                    {
                        _medicalInvoker.AddCommand(_commandFactory.CreateCommand(assignment));
                    });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void HandleCleanseByAdoptionCenter()
        {
            if(_commands.CleanseByAdoptionCenters.Any())
            {
                _commands.CleanseByAdoptionCenters.ToList()
                    .ForEach(cleanse =>
                    {
                        _medicalInvoker.AddCommand(_commandFactory.CreateCommand(cleanse));
                    });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void HandleAdoptionCenterCreation()
        {
            if (_commands.AdoptionCenters.Any())
            {
                _commands.AdoptionCenters.ToList()
                    .ForEach(newAdoptCenter =>
                    {
                        _medicalInvoker.AddCommand(_commandFactory.CreateCommand(newAdoptCenter));
                    });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void HandleCleanseCenterCreation()
        {
            if (_commands.CleanseCenters.Any())
            {
                _commands.CleanseCenters.ToList()
                    .ForEach(newCleanseCenter =>
                    {
                        _medicalInvoker.AddCommand(_commandFactory.CreateCommand(newCleanseCenter));
                    });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void HandleAnimalCreation()
        {
            if(_commands.AnimalsRegisters.Any())
            {
                _commands.AnimalsRegisters.ToList()
                    .ForEach(newAnimal =>
                    {
                        _medicalInvoker.AddCommand(_commandFactory.CreateCommand(newAnimal));
                    });
            }
        }
    }
}
