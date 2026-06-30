using TMPro; // TextMeshProを使うために必要
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections; // コルーチン（IEnumerator）を使うために必要

public class GameManager : MonoBehaviour
{
	// 外部からアクセスできるようにシングルトン（静的インスタンス）にする
	public static GameManager Instance { get; private set; }

	[SerializeField] private TextMeshProUGUI scoreText;
	[SerializeField] private TextMeshProUGUI timeText;
	[SerializeField] private float timeLimit = 30f; // 制限時間（秒）

	private int score = 0;
	private float timeRemaining;
	private bool isGameActive = true;

	void Awake()
	{
		// どこからでも GameManager.Instance で呼べるようにする設定
		if (Instance == null) Instance = this;
		else Destroy(gameObject);
	}

	void Start()
	{
		timeRemaining = timeLimit;
		UpdateScoreUI();
	}

	void Update()
	{
		if (!isGameActive) return;
			// 時間を減らす
			timeRemaining -= Time.deltaTime;

			if (timeRemaining <= 0f)
			{
				timeRemaining = 0f;
				isGameActive = false;
			StartCoroutine(GoToTitleAfterDelay(5f)); // 5秒待って遷移する
			}
		
		UpdateTimeUI();
	}

	// 修正ポイント：指定された秒数待機してからシーンを遷移させるコルーチン
	private IEnumerator GoToTitleAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene("TitleScene");
	}

	// スコアを増やすメソッド（他のスクリプトから呼ばれる）
	public void AddScore(int points)
	{
		if (!isGameActive) return; // ゲーム終了後は加算しない

		score += points;
		UpdateScoreUI();
	}

	void UpdateScoreUI()
	{
		scoreText.text = $"Score: {score}";
	}

	void UpdateTimeUI()
	{
		timeText.text = $"Time: {timeRemaining:F1}s"; // 小数点第1位まで表示
	}



	// ゲームが実行中かどうかを外部から判定するためのプロパティ
	public bool IsGameActive => isGameActive;
}

