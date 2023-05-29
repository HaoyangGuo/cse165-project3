/******************************************************************************
 * File: GazeHoverOverride.cs
 * Copyright (c) 2022 Qualcomm Technologies, Inc. and/or its subsidiaries. All rights reserved.
 *
 ******************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace Qualcomm.Snapdragon.Spaces.Samples
{
	public class GazeHoverOverride : MonoBehaviour
	{
		public float GazeTimerDuration;
		public bool ContinuousClick;

		private Button _button;

		private void Start()
		{
			_button = GetComponent<Button>();
		}

		public void Click()
		{
			_button.onClick.Invoke();
		}

		private void Update()
		{
			if (ContinuousClick)
			{
				Click();
			}
		}

		public void SetContinuousClick(bool isContinuousClickEnable)
		{
			ContinuousClick = isContinuousClickEnable;
		}
	}
}
