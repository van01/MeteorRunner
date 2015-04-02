using UnityEngine;
using System.Collections;

public enum BGM {
	NONE,
	LOBBY,
	INGAME,
	GAMEOVER
};

public class SoundEffects : Singleton<SoundEffects>
{	
	public AudioSource 	m_bgmAudio;
	private BGM			m_bgmType = BGM.NONE;
	

	public AudioClip Button;
	public AudioClip ObjectDrop;
	public AudioClip Damage;
	public AudioClip BackStep;

	public AudioClip BGM_Lobby;
	public AudioClip BGM_InGame;
	public AudioClip BGM_GameOver;

	public void Start()
	{

	}

	public void Awake()
	{
		Debug.Log ("SoundEffects : Awake");
		DontDestroyOnLoad(this.gameObject);
	}
	
	public void setBGM (BGM bgm)
	{
		if (m_bgmType == bgm)
		{
			return;
		}

		Debug.Log (m_bgmType + " > " + bgm);

		if (m_bgmAudio == null)
			return;

		m_bgmAudio.Stop ();
		switch (bgm)
		{
		case BGM.NONE:
			break;
		case BGM.LOBBY:
			MakeBGM(BGM_Lobby);
			break;
		case BGM.INGAME:
			MakeBGM(BGM_InGame);
			break;
		case BGM.GAMEOVER:
			MakeBGM(BGM_GameOver);
			break;
		}

		switch (bgm)
		{
		case BGM.NONE:
			break;
		case BGM.LOBBY:
			MakeBGM(BGM_Lobby);
			break;
		case BGM.INGAME:
			MakeBGM(BGM_InGame);
			break;
		case BGM.GAMEOVER:
			MakeBGM(BGM_GameOver);
			break;
		}

		m_bgmType = bgm;
	}


	private void MakeBGM(AudioClip originalClip)
	{
		m_bgmAudio.transform.position = transform.position;
		m_bgmAudio.PlayOneShot (originalClip);
		m_bgmAudio.loop = true;
	}
	

	public void MakeSound_Button()
	{
		MakeSound(Button);
	}
	
	public void MakeSound_PObjectDrop()
	{
		MakeSound(ObjectDrop);
	}
	
	public void MakeSound_Damage()
	{
		MakeSound(Damage);
	}

	public void MakeSound_BackStep()
	{
		MakeSound (BackStep);
	}
	
	/// <summary>
	/// Play a given sound
	/// </summary>
	/// <param name="originalClip"></param>
	private void MakeSound(AudioClip originalClip)
	{
		if (originalClip == null)
			return;

		AudioSource.PlayClipAtPoint(originalClip, transform.position);
	}
}
