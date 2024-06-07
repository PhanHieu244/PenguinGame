namespace Jackal
{
	using System;
	using UnityEngine;

	public abstract class AGroupForceAnim : AGroupAnim
	{
		protected abstract void ForceShow();

		private void Update()
		{
			if (!Input.GetMouseButtonDown(0) || IsComplete) return;
			IsComplete = true;
			ForceShow();
		}
	}
}