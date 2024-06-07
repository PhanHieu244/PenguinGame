using EnhancedUI;
using UnityEngine;

namespace Scroller
{
	public interface ICellView
	{
		string CellIdentifier { get; }
		Transform Transform { get; }
		float CellViewSize(ICellData data = null);
		void RefreshCellView();
		int cellIndex { get; set; }
		int dataIndex { get; set; }
		bool active { get; set; }
		void SetData(ref SmallList<ICellData> data, int startingIndex);
	}

	public interface ICellView<T> : ICellView where T : ICellData
	{
		float ICellView.CellViewSize(ICellData data)
		{
			if (data is not T trueData) return 0f;
			return CellViewSize(trueData);
		}

		float CellViewSize(T data);
	}
}