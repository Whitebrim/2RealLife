namespace Whitebrim.Actions
{
    public class PatCat : IAction
    {
        public void Execute(Entity sender, Entity victim)
        {
            (sender as Player).DoAction("Погладил кота.");
        }
    }
}
