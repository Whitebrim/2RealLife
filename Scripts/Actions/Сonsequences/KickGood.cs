public class KickGood : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Убегает в другую комнату.");
		var cat = entity as Cat;
		cat.mood.ChangeMood("Bad");
	}
}