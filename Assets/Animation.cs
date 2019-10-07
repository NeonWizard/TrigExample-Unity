using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation : MonoBehaviour {
	public Text angleText;
	public Text cosText;
	public Text sinText;

	int angle = 0;
	float cos;
	float sin;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		// -- Calculate cos and sin
		cos = Mathf.Cos(angle * Mathf.Deg2Rad);
		sin = Mathf.Sin(angle * Mathf.Deg2Rad);

		// -- Update text
		angleText.text = string.Format("θ<color=white>:</color> {0}°", angle);
		cosText.text = string.Format("cos(<color=#842525>θ</color>):  <color=#79F308>{0}</color>", cos.ToString("0.00"));
		sinText.text = string.Format("sin(<color=#842525>θ</color>):  <color=#3862C1>{0}</color>", sin.ToString("0.00"));

		// -- Axis lines
		float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
		Gizmos.DrawLine(new Vector2(-screenWidth, 0), new Vector2(screenWidth, 0), new Color(50/255f, 50/255f, 50/255f));
		Gizmos.DrawLine(new Vector2(0, -Camera.main.orthographicSize), new Vector2(0, Camera.main.orthographicSize), new Color(50/255f, 50/255f, 50/255f));

		// -- Draw internal lines
		Gizmos.DrawLine(Vector2.zero, new Vector2(cos * 7.85f/2, sin * 7.85f/2), Color.white);
		Gizmos.DrawLine(Vector2.zero, new Vector2(cos * 7.85f/2, 0), new Color(121/255f, 243, 8/255f)); // cosine
		Gizmos.DrawLine(new Vector2(cos * 7.85f/2, 0), new Vector2(cos * 7.85f/2, sin * 7.85f/2), new Color(56/255f, 98/255f, 193/255f)); // sine

		angle = (angle+1) % 360;
	}
}
