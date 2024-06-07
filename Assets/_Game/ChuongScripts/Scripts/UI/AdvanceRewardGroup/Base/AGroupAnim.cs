namespace Jackal
{
	using System;
	using UnityEngine;

	public abstract class AGroupAnim : MonoBehaviour
	{
		public Action CompleteAction;

		private bool _isComplete;

		protected AGroupLayout _groupLayout;

		protected bool IsComplete
		{
			get => _isComplete;
			set
			{
				_isComplete = value;
				if (_isComplete)
				{
					CompleteAction?.Invoke();
				}
			}
		}

		public void SetGroupLayout(AGroupLayout groupLayout) { _groupLayout = groupLayout; }
		public void Init()
		{
			IsComplete = false;
			InitAnim();
		}

		/// <summary>
		/// Must set _isComplete = true end.
		/// </summary>
		public abstract void ShowAnim();
		protected abstract void InitAnim();
	}
}