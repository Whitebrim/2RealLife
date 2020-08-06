namespace Whitebrim.Actions
{
    public class PlayGreat : IAction
    {
        public void Execute(Entity sender, Entity victim)
        {
            (sender as Cat).DoAction("Носится как угорелая.");
        }
    }
}
