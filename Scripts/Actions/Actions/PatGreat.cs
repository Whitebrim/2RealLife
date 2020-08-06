namespace Whitebrim.Actions
{
    public class PatGreat : IAction
    {
        public void Execute(Entity sender, Entity victim)
        {
            (sender as Cat).DoAction("Мурлычет и виляет хвостом.");
        }
    }
}
