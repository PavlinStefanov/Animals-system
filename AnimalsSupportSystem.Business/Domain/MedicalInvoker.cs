using log4net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalsSupportSystem.Business.Domain
{
    public class MedicalInvoker
    {
        private readonly ICollection<IMedicalCommand> _commands;
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MedicalInvoker()
        {
            _commands = new List<IMedicalCommand>();
        }

        public bool HasPendingCommands
        {
            get{ return _commands.Any(command => !command.IsCompleted); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        public void AddCommand(IMedicalCommand command)
        {
            try
            {
                _commands.Add(command);
                _log.Info($"Added command of type: '{command.GetType().Name}' to Medical Invoker.");
            }
            catch (Exception ex)
            {
                _log.Error($"Unable to add command '{command.GetType().Name}' to Medical Invoker.", ex);
                throw new Exception($"Unable to add command '{typeof(IMedicalCommand)}'.", ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ProcessPendingCommands()
        {
            try
            {
                _commands.Where(c => !c.IsCompleted)
                    .ToList()
                    .ForEach(command =>
                    {
                        command.Execute();
                        _log.Info($"Command '{command}' was executed.");
                    });
            }
            catch (Exception ex)
            {
                _log.Error("Unable to process pending commands.", ex);
                throw new Exception("Unable to process pending commands.", ex);
            }
        }
    }
}
