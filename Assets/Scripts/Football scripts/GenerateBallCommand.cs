public class GenerateBallCommand : ICommand
{
    private readonly IBallGenerator _generator;

    public GenerateBallCommand(IBallGenerator generator)
    {
        _generator = generator;
    }

    public void Execute()
    {
        _generator.GenerateBall();
    }
}
