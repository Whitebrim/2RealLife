namespace Whitebrim.Actions
{
    public class PlayBad : IAction
    {
        public void Execute(Entity sender, Entity victim)
        {
            (sender as Cat).DoAction("Сидит на месте.");
        }
    }
}
