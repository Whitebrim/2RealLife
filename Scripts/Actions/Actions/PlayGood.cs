namespace Whitebrim.Actions
{
    public class PlayGood : IAction
    {
        public void Execute(Entity sender, Entity victim)
        {
            (sender as Cat).DoAction("Медленно бегает за мячиком.");
        }
    }
}
