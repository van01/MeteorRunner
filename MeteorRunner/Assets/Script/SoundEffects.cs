using UnityEngine;
using System.Collections;

/// <summary>
/// Creating instance of sounds from code with no effort
/// </summary>
public class SoundEffects : MonoBehaviour
{	
	/// <summary>
	/// Singleton
	/// </summary>
	public static SoundEffects Instance;

	public AudioClip Button;
	public AudioClip ObjectDrop;
	public AudioClip Damage;
	
	void Awake()
	{
		// Register the singleton
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of SoundEffectsHelper!");
		}
		Instance = this;
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
	
	/// <summary>
	/// Play a given sound
	/// </summary>
	/// <param name="originalClip"></param>
	private void MakeSound(AudioClip originalClip)
	{
		// As it is not 3D audio clip, position doesn't matter.
		AudioSource.PlayClipAtPoint(originalClip, transform.position);
	}
}
