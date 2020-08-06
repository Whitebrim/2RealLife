namespace Whitebrim.Actions
{
    public class FeedBad : IAction
    {
        public void Execute(Entity sender, Entity victim)
        {
            (sender as Cat).DoAction("Все съедает, но если в это время подойти - поцарапает.");
        }
    }
}
