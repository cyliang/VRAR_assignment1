using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class TouchBtnScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public GameObject obj;
	public string perpose;

	bool pressing;

	// Use this for initialization
	void Start ()
	{
		pressing = false;
	}

	public void OnPointerDown(PointerEventData eventData) {
		pressing = true;
	}

	public void OnPointerUp(PointerEventData eventData) {
		pressing = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (pressing) {
			switch (perpose) {
			case "LookLeft":
				obj.SendMessage ("toLookLeft");
				break;

			case "LookRight":
				obj.SendMessage ("toLookRight");
				break;

			case "Stop":
				obj.SendMessage ("toStop");
				break;

			default:
				Debug.LogError ("Perpose error.");
				break;
			}
		}
	}
}

