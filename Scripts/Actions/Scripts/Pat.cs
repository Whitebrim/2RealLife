public class Pat : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Погладил кошку.");
	}
}
public class PatGreat : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Мурлычет и виляет хвостом.");
	}
}
public class PatGood : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Мурлычит.");
		var cat = entity as Cat;
		cat.mood.ChangeMood("Great");
	}
}
public class PatBad : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Царапается.");
	}
}
