public class Kick : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Пнул кошку.");
	}
}
public class KickGreat : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Убегает на ковер и писает.");
		var cat = entity as Cat;
		cat.mood.ChangeMood("Bad");
	}
}
public class KickGood : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Убегает в другую комнату.");
		var cat = entity as Cat;
		cat.mood.ChangeMood("Bad");
	}
}
public class KickBad : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Прыгает и кусает за правое ухо.");
	}
}