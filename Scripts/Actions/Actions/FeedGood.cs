namespace Whitebrim.Actions
{
    public class FeedGood : IAction
    {
        public void Execute(Entity sender, Entity victim)
        {
            (sender as Cat).DoAction("Быстро все съедает.");
        }
    }
}
