
namespace AnimalsSupportSystem.Business.Domain
{
    public interface IMedicalCommand
    {
        bool IsCompleted { get; set; }
        void Execute();
    }
}
