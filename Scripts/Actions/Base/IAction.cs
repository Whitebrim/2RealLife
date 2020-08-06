namespace Whitebrim
{
    public interface IAction
    {
        void Execute(Entity sender, Entity victim);
    }
}

