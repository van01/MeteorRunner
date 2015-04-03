using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoolTimeButton : MonoBehaviour {

	public Texture2D 	m_texture = null;
	public Color		m_color;
	private Texture2D	m_progTex;
	private float		m_progress = 0.0f;
	private float		m_oldProgress = -1;

	private bool 		m_isEnable			= true;
	private float		m_fCheckStartTime 	= 0.0f;
	private float		m_fDisableTime		= 0.0f;

	// Use this for initialization
	void Start () {
		m_progTex = ProgressUpdate(m_progress, m_color);
		setDisable (10.0f);
	}
	
	// Update is called once per frame
	void Update () {

		if (!m_isEnable)
		{
			float deltaTime = Time.time - m_fCheckStartTime;
			m_progress = deltaTime / m_fDisableTime;
		}


		if(m_oldProgress != m_progress){
			m_progTex = ProgressUpdate(m_progress, m_color);
			m_oldProgress = m_progress;
		}
	}

	void setDisable (float time)
	{
		m_isEnable = false;
		m_fCheckStartTime = Time.time;
		m_fDisableTime = time;
	}

	
	Texture2D ProgressUpdate(float progress, Color overlayColor){

		Texture2D thisTex = new Texture2D(m_texture.width, m_texture.height);

		Vector2 centre = new Vector2(Mathf.Ceil(thisTex.width/2), Mathf.Ceil(thisTex.height/2)); //find the centre pixel

		for(int y = 0; y < thisTex.height; y++){
			for(int x = 0; x < thisTex.width; x++){
				var angle = Mathf.Atan2(x-centre.x, y-centre.y)*Mathf.Rad2Deg; //find the angle between the centre and this pixel (between -180 and 180)
				if(angle < 0){
					angle += 360; //change angles to go from 0 to 360
				}
				Color pixColor = m_texture.GetPixel(x, y);
				if(angle <= progress*360.0)
				{ //if the angle is less than the progress angle blend the overlay colour
					pixColor = new Color(
						(pixColor.r*pixColor.a*(1-overlayColor.a))+(overlayColor.r*overlayColor.a),
						(pixColor.g*pixColor.a*(1-overlayColor.a))+(overlayColor.g*overlayColor.a),            
						(pixColor.b*pixColor.a*(1-overlayColor.a))+(overlayColor.b*overlayColor.a)            
						);
				}

				thisTex.SetPixel(x, y, pixColor);
			}
		}
		thisTex.Apply(); //apply the cahnges we made to the texture
		return thisTex;
	}

	void OnGUI(){
		GUIStyle guiStyle  = new GUIStyle("button");
		guiStyle.padding = new RectOffset(0, 0, 0, 0);
		GUI.Button(new Rect(10, 10, 32, 32), m_progTex, guiStyle);
	}

}
