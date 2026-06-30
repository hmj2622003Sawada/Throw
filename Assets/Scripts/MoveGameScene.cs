using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Rendering;

public class MoveGameScene : MonoBehaviour
{
	[SerializeField] private float FinishTimer = 35f;

	private float Timer;

	private void Start()
	{
		Timer = FinishTimer;
	}

	// Update is called once per frame
	void Update()
    {
		Timer -= 1f;

		if (Timer <= 0f)
		{	
				SceneManager.LoadScene("TitleScene");	
		}
    }
}
