public class Feed : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Накормил кошку.");
	}
}
public class FeedGreat : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Быстро все съедает.");
	}
}
public class FeedGood : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Быстро все съедает.");
		var cat = entity as Cat;
		cat.mood.ChangeMood("Great");
	}
}
public class FeedBad : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Все съедает, но если в это время подойти - поцарапает.");
		var cat = entity as Cat;
		cat.mood.ChangeMood("Good");
	}
}