using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Sound3DTest {
	public class SoundSourceController : MonoBehaviour {
		private GameObject pivot;
		private GameObject audioSourceObj;
		private AudioSource audioSource;
		private Slider rotationSlider;
		private Slider distanceSlider;
		private Slider heightSlider;
		private Toggle spatializeToggle;
		// Use this for initialization
		void Start () {
			this.pivot = GameObject.Find ("RotatePivot");
			this.audioSourceObj = GameObject.Find ("AudioSource");
			this.audioSource = audioSourceObj.GetComponent<AudioSource> ();
			this.rotationSlider = GameObject.Find("RotationSlider").GetComponent<Slider>();
			this.distanceSlider = GameObject.Find("DistanceSlider").GetComponent<Slider>();
			this.heightSlider = GameObject.Find("HeightSlider").GetComponent<Slider>();
			this.spatializeToggle = GameObject.Find("SpatializeToggle").GetComponent<Toggle>();
		}
		
		// Update is called once per frame
		void Update () {
			if (this.pivot && this.rotationSlider && this.distanceSlider && this.audioSourceObj && this.heightSlider) {
				float val = this.rotationSlider.value;
				this.pivot.transform.rotation = Quaternion.Euler (0, val, 0);


				float val2 = this.distanceSlider.value;
				float val3 = this.heightSlider.value;
				this.audioSourceObj.transform.localPosition = new Vector3(0, val3, val2);

				this.audioSource.spatialize = spatializeToggle.isOn;
			}
		}
	}
}