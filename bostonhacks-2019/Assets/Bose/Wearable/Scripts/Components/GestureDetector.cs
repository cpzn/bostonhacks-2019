﻿using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

using WebApplication1;

namespace Bose.Wearable
{
    /// <summary>
    /// Automatically fires an event if the selected gesture is detected.
    /// </summary>
    [AddComponentMenu("Bose/Wearable/GestureDetector")]
	public class GestureDetector : MonoBehaviour
	{
        //public GameObject cube = GameObject.Find("Cube");
		/// <summary>
		/// The gesture that will be detected.
		/// </summary>
		public GestureId Gesture
		{
			get { return _gesture; }
			set
			{
				Assert.IsFalse(value == GestureId.None, string.Format(WearableConstants.NONE_IS_INVALID_GESTURE, GetType()));
			
				if (isActiveAndEnabled &&
				    _requirement != null &&
				    _gesture != value &&
				    _gesture != GestureId.None)
				{
					_requirement.DisableGesture(_gesture);
				}

				_gesture = value;

				if (isActiveAndEnabled &&
				    _requirement != null)
				{
					_requirement.EnableGesture(_gesture);
				}
			}
		}

		[SerializeField]
		private GestureId _gesture;

		[SerializeField]
		private UnityEvent _onGestureDetected;

		private WearableControl _wearableControl;
		private WearableRequirement _requirement;

		private void Awake()
		{
			_wearableControl = WearableControl.Instance;

			// Establish a requirement for the referenced gesture.
			_requirement = gameObject.AddComponent<WearableRequirement>();
		}

		private void OnEnable()
		{
			_wearableControl.GestureDetected += GestureDetected;
			
			if (_gesture != GestureId.None)
			{
				_requirement.EnableGesture(_gesture);
			}
		}

		private void OnDisable()
		{
			_wearableControl.GestureDetected -= GestureDetected;
			
			if (_gesture != GestureId.None && _requirement != null)
			{
				_requirement.DisableGesture(_gesture);
			}
		}

		private void GestureDetected(GestureId gesture)
		{
			if (gesture != _gesture)
			{
				return;
			}

			_onGestureDetected.Invoke();
            Debug.Log("hoy");
            var x = new WebApplication1.TextMe();


            //cube.GetComponent<AudioSource>().Play();
		}
	}
}
