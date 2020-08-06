namespace Whitebrim.Actions
{
    public class PlayWithCat : IAction
    {
        public void Execute(Entity sender, Entity victim)
        {
            (sender as Player).DoAction("Играет с котом.");
        }
    }
}