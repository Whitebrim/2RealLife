public class FeedBad : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Все съедает, но если в это время подойти - поцарапает.");
		var cat = entity as Cat;
		cat.mood.ChangeMood("Good");
	}
}