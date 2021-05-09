using System;
using UnityEngine;

namespace DevourMono
{
	// Token: 0x02000002 RID: 2
	public class Loader
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static void Load()
		{
			Loader._Load = new GameObject();
			Loader._Load.AddComponent<Main>();
			UnityEngine.Object.DontDestroyOnLoad(Loader._Load);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002073 File Offset: 0x00000273
		public static void Unload()
		{
			UnityEngine.Object.Destroy(Loader._Load);
		}

		// Token: 0x04000001 RID: 1
		private static GameObject _Load;
	}
}
