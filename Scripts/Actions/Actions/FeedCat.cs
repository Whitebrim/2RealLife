namespace Whitebrim.Actions
{
    public class FeedCat : IAction
    {
        public void Execute(Entity sender, Entity victim)
        {
            (sender as Player).DoAction("Покормил кота.");
        }
    }
}
