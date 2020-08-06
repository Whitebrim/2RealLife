namespace Whitebrim.Actions
{
    public class KickBad : IAction
    {
        public void Execute(Entity sender, Entity victim)
        {
            (sender as Cat).DoAction("Прыгает и кусает за правое ухо.");
            //(victim as Player).DoAction("Лишается правого уха");
        }
    }
}
