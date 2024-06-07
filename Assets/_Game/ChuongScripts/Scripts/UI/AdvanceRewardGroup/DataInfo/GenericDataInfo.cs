using Scroller;

namespace Jackal
{
	using System;

	public abstract class GenericDataInfo<T> : ADataInfo where T : ICellData
	{
		public override string CellIdentifier       => typeof(T).Name;
		public override void   ShowAnim() { }
		public override void ShowInfo(ICellData data)
		{
			var tData = (T) data;

			if (tData != null)
			{
				ShowInfo(tData);
			}
		}

		public abstract void ShowInfo(T data);
	}
}