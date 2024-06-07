namespace Jackal
{
	using System;
	using System.Collections;
	using UnityEngine;

	public class LinearGroupAnim : AGroupForceAnim
	{
		[SerializeField] private float _gapTime = 0.1f;

		private WaitForSeconds _gap;

		private void Start() { _gap = new WaitForSeconds(_gapTime); }

		public override void ShowAnim() { StartCoroutine(CoAnim()); }
		protected override void InitAnim()
		{
			var infos = _groupLayout.ActiveData;
			for (int i = 0; i < infos.Count; i++)
			{
				infos[i].InitAnim();
			}
		}

		private IEnumerator CoAnim()
		{
			var infos = _groupLayout.ActiveData;

			for (int i = 0; i < infos.Count; i++)
			{
				yield return _gap;
				infos[i].ShowAnim();
			}

			IsComplete = true;
		}
		protected override void ForceShow()
		{
			var infos = _groupLayout.ActiveData;
			for (int i = 0; i < infos.Count; i++)
			{
				infos[i].ForceShow();
			}
		}
	}
}