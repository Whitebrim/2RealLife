namespace Whitebrim.Actions
{
    public class KickCat : IAction
    {
        public void Execute(Entity sender, Entity victim)
        {
            (sender as Player).DoAction("Пнул кота.");
        }
    }
}
