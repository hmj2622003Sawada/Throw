using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MoveSceneRule : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{
		if (Keyboard.current.spaceKey.wasPressedThisFrame)
		{
			SceneManager.LoadScene("GameScene");
		}
	}
}