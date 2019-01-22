
using AnimalsSupportSystem.Business.Domain;

namespace AnimalsSupportSystem.Business
{
    public interface IMedicalInvoker
    {
        bool HasPendingCommands { get; }
        void AddCommand(IMedicalCommand command);
        void ProcessPendingCommands();
    }
}
