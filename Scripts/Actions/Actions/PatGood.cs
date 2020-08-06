namespace Whitebrim.Actions
{
    public class PatGood : IAction
    {
        public void Execute(Entity sender, Entity victim)
        {
            (sender as Cat).DoAction("Мурлычет.");
        }
    }
}
