using System.Linq;
using Scroller;

namespace Jackal
{
	using System.Collections.Generic;
	using UnityEngine;

	public abstract class AGroupLayout : MonoBehaviour
	{
		[SerializeField] private ADataInfo[] _prefabToSpawn;

		/// <summary>
		/// Cached reference to the container that holds the recycled cell views
		/// </summary>
		[SerializeField] private RectTransform _recycledCellViewContainer;

		/// <summary>
		/// Cached reference to the active cell view container
		/// </summary>
		[SerializeField] private RectTransform _container;

		private List<ADataInfo> _activeCellViews = new List<ADataInfo>();

		private List<ADataInfo> _recycledCellViews =
			new List<ADataInfo>();

		public List<ADataInfo> ActiveData => _activeCellViews;

		public void ShowGroupInfo(List<ICellData> info)
		{
			var count = info.Count;

			SpawnRewardItemSlot(info);
			Refresh(count);
		}

		private ADataInfo GetCellPrefab(ICellData data)
		{
			return _prefabToSpawn.ToList().Find(cellView => cellView.CellIdentifier == data.Identifier);
		}

		public void SpawnRewardItemSlot(List<ICellData> info)
		{
			var count = info.Count;

			RecycleAllCells();


			for (int i = 0; i < count; i++)
			{
				AddCellView(info[i]);
				_activeCellViews[i].ShowInfo(info[i]);
			}
		}

		private void RecycleAllCells()
		{
			while (_activeCellViews.Count > 0) _RecycleCell(_activeCellViews[0]);
		}

		private void _RecycleCell(ADataInfo cellView)
		{
			// remove the cell view from the active list
			_activeCellViews.Remove(cellView);

			// add the cell view to the recycled list
			_recycledCellViews.Add(cellView);

			// move the GameObject to the recycled container
			cellView.transform.SetParent(_recycledCellViewContainer);
		}

		private void AddCellView(ICellData data)
		{
			// add the cell view to the active container
			var cellView = GetRecycledCellView(data);
			if (cellView == null)
			{
				var prefab = GetCellPrefab(data);
				var go     = Instantiate(prefab.gameObject);

				cellView = go.GetComponent<ADataInfo>();
			}
			
			cellView.transform.SetParent(_container);
			cellView.transform.SetAsLastSibling();
			cellView.transform.localScale = Vector3.one;

			_activeCellViews.Add(cellView);
		}

		private ADataInfo GetRecycledCellView(ICellData data)
		{
			for (var i = 0; i < _recycledCellViews.Count; i++)
			{
				if (_recycledCellViews[i].CellIdentifier == data.Identifier)
				{
					// the cell view was found, so we use this recycled one.
					// we also remove it from the recycled list
					var cellView = _recycledCellViews[i];

					_recycledCellViews.RemoveAt(i);

					return cellView;
				}
			}

			return null;
		}

		protected abstract void Refresh(int rewardCount);
	}
}