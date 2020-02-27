public class KickGreat : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Убегает на ковер и писает.");
		var cat = entity as Cat;
		cat.mood.ChangeMood("Bad");
	}
}