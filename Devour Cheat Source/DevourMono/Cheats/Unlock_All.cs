using System;
using System.Reflection;
using UnityEngine;

namespace DevourMono.Cheats
{
	// Token: 0x02000006 RID: 6
	public class Unlock_All : MonoBehaviour
	{
		// Token: 0x06000021 RID: 33 RVA: 0x000045B8 File Offset: 0x000027B8
		public static void Unlock()
		{
			AchievementHelpers achievementHelpers = UnityEngine.Object.FindObjectOfType<AchievementHelpers>();
			string[] names = new string[]
			{
				"hasAchievedFusesUsed",
				"hasAchievedGasolineUsed",
				"hasAchievedNoKnockout",
				"hasCollectedAllPatches",
				"hasCollectedAllRoses",
				"hasCompletedHardAsylumGame",
				"hasCompletedHardGame",
				"hasCompletedNightmareAsylumGame",
				"hasCompletedNightmareGame",
				"hasCompletedNormalGame",
				"isStatsValid",
				"isStatsFetched"
			};
			object[] values = new object[]
			{
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true,
				true
			};
			Utility.ReplaceMultipleFields(achievementHelpers, names, values, BindingFlags.Instance | BindingFlags.NonPublic);
			string[] array = new string[]
			{
				"ACH_ALL_ROSES",
				"ACH_BURNT_GOAT",
				"ACH_SURVIVED_TO_3_GOATS",
				"ACH_SURVIVED_TO_5_GOATS",
				"ACH_SURVIVED_TO_7_GOATS",
				"ACH_WON_SP",
				"ACH_WON_COOP",
				"ACH_LOST",
				"ACH_LURED_20_GOATS",
				"ACH_REVIVED_20_PLAYERS",
				"ACH_ALL_NOTES_READ",
				"ACH_KNOCKED_OUT_BY_ANNA",
				"ACH_KNOCKOUT_OUT_BY_DEMON",
				"ACH_KNOCKED_OUT_20_TIMES",
				"ACH_NEVER_KNOCKED_OUT",
				"ACH_ONLY_ONE_KNOCKED_OUT",
				"ACH_UNLOCKED_CAGE",
				"ACH_UNLOCKED_ATTIC_CAGE",
				"ACH_BEAT_GAME_5_TIMES",
				"ACH_100_GASOLINE_USED",
				"ACH_FRIED_20_DEMONS",
				"ACH_STAGGERED_ANNA_20_TIMES",
				"ACH_CALMED_ANNA_10_TIMES",
				"ACH_CALMED_ANNA",
				"ACH_WIN_NIGHTMARE",
				"ACH_BEAT_GAME_5_TIMES_IN_NIGHTMARE_MODE",
				"ACH_WON_NO_KNOCKOUT_COOP",
				"ACH_WIN_NIGHTMARE_SP",
				"ACH_WON_HARD",
				"ACH_WON_HARD_SP",
				"ACH_100_FUSES_USED",
				"ACH_ALL_CLIPBOARDS_READ",
				"ACH_ALL_PATCHES",
				"ACH_FRIED_RAT",
				"ACH_FRIED_100_INMATES",
				"ACH_LURED_20_RATS",
				"ACH_STAGGERED_MOLLY_20_TIMES",
				"ACH_WON_MOLLY_SP",
				"ACH_WON_MOLLY_HARD_SP",
				"ACH_WON_MOLLY_NIGHTMARE_SP",
				"ACH_WON_MOLLY_COOP",
				"ACH_WON_MOLLY_HARD",
				"ACH_WON_MOLLY_NIGHTMARE",
				"ACH_20_TRASH_CANS_KICKED",
				"ACH_CALM_MOLLY_10_TIMES"
			};
			for (int i = 0; i < array.Length; i++)
			{
				achievementHelpers.Unlock(array[i], false);
			}
		}
	}
}
