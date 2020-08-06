namespace Whitebrim.Actions
{
    public class PatBad : IAction
    {
        public void Execute(Entity sender, Entity victim)
        {
            (sender as Cat).DoAction("Царапает.");
        }
    }
}
