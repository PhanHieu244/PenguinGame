namespace Jackal
{
	using UnityEngine;
	using UnityEngine.UI;

	public class GroupLayout : AGroupLayout
	{
		[SerializeField] private int             _maxItemInRow = 5;
		[SerializeField] private GridLayoutGroup _gridLayoutGroup;

		protected override void Refresh(int rewardCount)
		{
			_gridLayoutGroup.constraintCount = _maxItemInRow;
		}
	}
}