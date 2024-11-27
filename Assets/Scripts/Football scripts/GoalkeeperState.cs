// State Pattern para el Goalkeeper
public abstract class GoalkeeperState
{
    public abstract void Handle(Goalkeeper goalkeeper);
}

public class ActiveGoalkeeperState : GoalkeeperState
{
    public override void Handle(Goalkeeper goalkeeper)
    {
        goalkeeper.Move();
    }
}

public class InactiveGoalkeeperState : GoalkeeperState
{
    public override void Handle(Goalkeeper goalkeeper)
    {
        // No realiza ninguna acción
    }
}
