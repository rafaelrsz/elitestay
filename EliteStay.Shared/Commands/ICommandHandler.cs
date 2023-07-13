namespace EliteStay.Shared.Commands
{
  public interface ICommandHandler<T> where T : ICommand
  {
    ICommandResult? Handle(T Command);
  }
}