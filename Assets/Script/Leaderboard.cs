using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;

public class Leaderboard : MonoBehaviour
{
#if UNITY_IOS
	// we'll create some buttons in OnGui, allowing us to bump achievement and
	// score values for testing
		
	private double ach1 = 0;
	private double ach2 = 0;
	private double ach3 = 0;
	private double ach4 = 0;
		
	private long score1 = 1000;
	private long score2 = 200;
		
	private int buttonWidth = 120;
	private int buttonHeight = 50;
	private int buttonGap = 10;
		
	void Start ()
	{
		Social.localUser.Authenticate (HandleAuthenticated);
	}
		
	// authentication
		
	private void HandleAuthenticated (bool success)
	{
		Debug.Log ("*** HandleAuthenticated: success = " + success);
		if (success) {
			//Social.localUser.LoadFriends (HandleFriendsLoaded);
			//Social.LoadAchievements (HandleAchievementsLoaded);
			//Social.LoadAchievementDescriptions (HandleAchievementDescriptionsLoaded);
		}
	}
		
	private void HandleFriendsLoaded (bool success)
	{
		Debug.Log ("*** HandleFriendsLoaded: success = " + success);
		foreach (IUserProfile friend in Social.localUser.friends) {
			Debug.Log ("*   friend = " + friend.ToString ());
		}
	}
		
	private void HandleAchievementsLoaded (IAchievement[] achievements)
	{
		Debug.Log ("*** HandleAchievementsLoaded");
		foreach (IAchievement achievement in achievements) {
			Debug.Log ("*   achievement = " + achievement.ToString ());
		}
	}
		
	private void HandleAchievementDescriptionsLoaded (IAchievementDescription[] achievementDescriptions)
	{
		Debug.Log ("*** HandleAchievementDescriptionsLoaded");
		foreach (IAchievementDescription achievementDescription in achievementDescriptions) {
			Debug.Log ("*   achievementDescription = " + achievementDescription.ToString ());
		}
	}
		
	// achievements
		
	/*public void ReportProgress(string achievementId, double progress)
		{
			if (Social.localUser.authenticated) {
				Social.ReportProgress(achievementId, progress, HandleProgressReported);
			}
		}
		
		private void HandleProgressReported(bool success)
		{
			Debug.Log("*** HandleProgressReported: success = " + success);
		}
		
		public void ShowAchievements()
		{
			if (Social.localUser.authenticated) {
				Social.ShowAchievementsUI();
			}
		}*/
		
	// leaderboard
		
	public static void ReportScore (string leaderboardId, long score)
	{
		if (Social.localUser.authenticated) {
			Social.ReportScore (score, leaderboardId, HandleScoreReported);
		}
	}
		
	public static void HandleScoreReported (bool success)
	{
		Debug.Log ("*** HandleScoreReported: success = " + success);
	}
		
	public void ShowLeaderboard ()
	{
		if (Social.localUser.authenticated) {
			Social.ShowLeaderboardUI ();
		}
	}

	public void LoadUser (string[] userIDs)
	{
		if (Social.localUser.authenticated) {
			Social.LoadUsers (userIDs, HandleLoadUsers);
		}
	}
		
	private void HandleLoadUsers (IUserProfile[] useras)
	{
		Debug.Log ("*** HandleLoadUsers");
		string usernames = "";
		foreach (IUserProfile usera in useras) {
			usernames = usernames + "\n" + usera.userName + "\n" + usera.image;
			Debug.Log ("* userName = " + usera.userName);
			Debug.Log ("* userImage.width = " + usera.image.width);
			Debug.Log ("* userImage.height = " + usera.image.height);
			//GUI.DrawTexture(new Rect( Screen.width/2,Screen.height/2,256,256) ,usera.image);
			GameObject.Find("Game1BG").GetComponent<MeshRenderer>().material.mainTexture = usera.image;
		}
		TextMesh m_ani = GameObject.Find ("Score").GetComponent<TextMesh> ();
		m_ani.text = usernames;

	}

	// gui
	//public void OnGUI ()
	public void OnGUIButtons ()
	{
		// four buttons, allowing us to bump and test setting achievements
		int yDelta = buttonGap;
		/*if(GUI.Button(new Rect(buttonGap, yDelta, buttonWidth, buttonHeight), "Ach 1")) {
				ReportProgress("A0001", ach1);
				ach1 = (ach1 == 100) ? 0 : ach1 + 10;
			}
			yDelta += buttonHeight + buttonGap;
			if (GUI.Button(new Rect(buttonGap, yDelta, buttonWidth, buttonHeight), "Ach 2")) {
				ReportProgress("A0002", ach2);
				ach2 = (ach2 == 100) ? 0 : ach2 + 10;
			}
			yDelta += buttonHeight + buttonGap;
			if (GUI.Button(new Rect(buttonGap, yDelta, buttonWidth, buttonHeight), "Ach 3")) {
				ReportProgress("A0003", ach3);
				ach3 = (ach3 == 100) ? 0 : ach3 + 10;
			}
			yDelta += buttonHeight + buttonGap;
			if (GUI.Button(new Rect(buttonGap, yDelta, buttonWidth, buttonHeight), "Ach 4")) {
				ReportProgress("A0004", ach4);
				ach4 = (ach4 == 100) ? 0 : ach4 + 10;
			}
			// show achievements
			yDelta += buttonHeight + buttonGap;
			if (GUI.Button(new Rect(buttonGap, yDelta, buttonWidth, buttonHeight), "Show Achievements")) {
				ShowAchievements();
			}*/
			
		// two buttons, allowing us to bump and test setting high scores
		int xDelta = Screen.width - buttonWidth - buttonGap;
		//yDelta = buttonGap;
		/*if (GUI.Button(new Rect(xDelta, yDelta, buttonWidth, buttonHeight), "Score 1")) {
				ReportScore("1", score1);
				score1 += 500;
			}*/
		yDelta += buttonHeight + buttonGap;
		if (GUI.Button (new Rect (xDelta, yDelta, buttonWidth, buttonHeight), "Score 2")) {
			Social.LoadScores ("1", scores => {
				if (scores.Length > 0) {
					//Debug.Log ("Got " + scores.Length + " scores");
					string myScores = "Leaderboard:\n";
					string [] a = new string[scores.Length];
					int i = 0;
					foreach (IScore score in scores) {
						a [i] = score.userID;
							
						myScores += "\t" + score.formattedValue + " " + "\n";

						//TextMesh m_ani = GameObject.Find ("Score").GetComponent<TextMesh> ();
						//m_ani.text = myScores + a [i] + "\n";
						i++;
					}
					LoadUser (a);
					//Debug.Log (myScores);
				} else
					Debug.Log ("No scores loaded");
			});
		}
		// show leaderboard
		yDelta += buttonHeight + buttonGap;
		if (GUI.Button (new Rect (xDelta, yDelta, buttonWidth, buttonHeight), "Show Leaderboard")) {
			ShowLeaderboard ();
		}
	}
#endif
}