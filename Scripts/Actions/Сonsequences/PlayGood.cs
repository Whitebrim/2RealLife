public class PlayGood : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Медленно бегает за мячиком.");
		var cat = entity as Cat;
		cat.mood.ChangeMood("Great");
	}
}