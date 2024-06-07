using System.Collections.Generic;
using Scroller;
using UnityEngine;

namespace Jackal
{
	using System;

	[RequireComponent(typeof(AGroupAnim))]
	[RequireComponent(typeof(AGroupLayout))]
	public class AdvanceGroup : MonoBehaviour
	{
		[SerializeField] private AGroupAnim   _groupAnim;
		[SerializeField] private AGroupLayout _groupLayout;

#if UNITY_EDITOR
		private void OnValidate()
		{
			_groupAnim   = GetComponent<AGroupAnim>();
			_groupLayout = GetComponent<AGroupLayout>();
		}
#endif
		
		private void Awake() { _groupAnim.SetGroupLayout(_groupLayout); }

		public void ShowRewards(List<ICellData> groupInfo)
		{
			_groupLayout.ShowGroupInfo(groupInfo);
		}
		
		public void InitAnim()
		{
			_groupAnim.Init();
		}
		
		public void ShowAnim()
		{
			_groupAnim.ShowAnim();
		}

		public void SetCompleteAction(Action action)
		{
			_groupAnim.CompleteAction = action;
		}
	}
}