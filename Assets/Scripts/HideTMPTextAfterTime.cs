using TMPro;
using UnityEngine;

public class HideTMPTextAfterTime : MonoBehaviour
{
	[SerializeField] private float TimeToHide = 4;
	[SerializeField] private TMP_Text componentToHide;
	private void Awake()
	{
		componentToHide.enabled = true;
		Invoke(nameof(disableComponent), TimeToHide);
	}
	private void disableComponent()
	{
		componentToHide.enabled = false;
	}
}
