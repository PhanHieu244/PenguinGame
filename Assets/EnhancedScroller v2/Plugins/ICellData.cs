namespace Scroller
{

	public interface ICellData : IDetermine
	{

	}

	public interface IDetermine
	{
		string Identifier { get; }
	}
}