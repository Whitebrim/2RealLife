public class FeedGood : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Быстро все съедает.");
		var cat = entity as Cat;
		cat.mood.ChangeMood("Great");
	}
}