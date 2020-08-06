namespace Whitebrim.Actions
{
    public class KickGood : IAction
    {
        public void Execute(Entity sender, Entity victim)
        {
            (sender as Cat).DoAction("Убегает на ковер и справляет нужну.");
        }
    }
}
