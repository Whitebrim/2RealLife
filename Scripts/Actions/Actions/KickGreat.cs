namespace Whitebrim.Actions
{
    public class KickGreat : IAction
    {
        public void Execute(Entity sender, Entity victim)
        {
            (sender as Cat).DoAction("Убегает в другую комнату.");
        }
    }
}
