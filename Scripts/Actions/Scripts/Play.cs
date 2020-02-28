public class Play : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Поиграл с кошкой.");
	}
}
public class PlayGreat : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Носится, как угорелая.");
	}
}
public class PlayGood : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Медленно бегает за мячиком.");
		var cat = entity as Cat;
		cat.mood.ChangeMood("Great");
	}
}
public class PlayBad : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Сидит на месте.");
	}
}