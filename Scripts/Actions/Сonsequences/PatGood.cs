public class PatGood : ActionScript
{
	public override void Execute(Entity entity)
	{
		entity.DoAction("Мурлычит.");
		var cat = entity as Cat;
		cat.mood.ChangeMood("Great");
	}
}