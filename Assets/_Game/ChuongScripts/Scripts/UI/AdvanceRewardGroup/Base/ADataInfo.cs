using Scroller;

namespace Jackal
{
	using UnityEngine;

	public abstract class ADataInfo : MonoBehaviour
	{
		public abstract string CellIdentifier { get; }

		public abstract void InitAnim();
		public abstract void ShowAnim();
		public abstract void ForceShow();
		public abstract void ShowInfo(ICellData data);
	}
}