using System;
using System.Collections.Generic;
using DevourMono.Cheats;
using Horror;
using Opsive.UltimateCharacterController.Character;
using UnityEngine;

namespace DevourMono
{
	// Token: 0x02000003 RID: 3
	public class Main : MonoBehaviour
	{
		// Token: 0x06000004 RID: 4 RVA: 0x0000208A File Offset: 0x0000028A
		public void Start()
		{
			Utility.InitDrawing();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002094 File Offset: 0x00000294
		public void Update()
		{
			bool keyDown = Input.GetKeyDown(Settings.MenuKey);
			if (keyDown)
			{
				Settings.Menu = !Settings.Menu;
			}
			bool keyDown2 = Input.GetKeyDown(Settings.ExitKey);
			if (keyDown2)
			{
				Loader.Unload();
			}
			bool keyDown3 = Input.GetKeyDown(KeyCode.Keypad0);
			if (keyDown3)
			{
				Unlock_All.Unlock();
			}
			bool keyDown4 = Input.GetKeyDown(KeyCode.Keypad1);
			if (keyDown4)
			{
				foreach (DoorBehaviour doorBehaviour in UnityEngine.Object.FindObjectsOfType<DoorBehaviour>())
				{
					doorBehaviour.Unlock();
				}
			}
			bool keyDown5 = Input.GetKeyDown(KeyCode.Keypad2);
			if (keyDown5)
			{
				Settings.Flashlight = !Settings.Flashlight;
				Light flashlightSpot = Main.LocalPlayerNolan.flashlightSpot;
				bool flashlight = Settings.Flashlight;
				if (flashlight)
				{
					flashlightSpot.intensity = 4f;
					flashlightSpot.range = 60f;
				}
				else
				{
					flashlightSpot.intensity = 1.5f;
					flashlightSpot.range = 9f;
				}
			}
			bool keyDown6 = Input.GetKeyDown(KeyCode.Keypad3);
			if (keyDown6)
			{
				foreach (KeyBehaviour keyBehaviour in UnityEngine.Object.FindObjectsOfType<KeyBehaviour>())
				{
					bool flag = keyBehaviour == null;
					if (flag)
					{
						return;
					}
					keyBehaviour.transform.position = Main.LocalPlayerNolan.transform.position + Main.LocalPlayerNolan.transform.forward * 2.5f;
				}
			}
			bool keyDown7 = Input.GetKeyDown(KeyCode.Keypad4);
			if (keyDown7)
			{
				foreach (GameObject gameObject in Main.Goats)
				{
					UltimateCharacterLocomotion component = gameObject.GetComponent<UltimateCharacterLocomotion>();
					component.SetPosition(Main.LocalPlayerNolan.transform.position + Main.LocalPlayerNolan.transform.forward * 2.5f);
				}
			}
			bool keyDown8 = Input.GetKeyDown(KeyCode.Keypad5);
			if (keyDown8)
			{
				Main.LocalPlayerUCL.SetPosition(Main.LocalPlayerNolan.transform.position + Main.LocalPlayerNolan.transform.forward * 2.5f);
			}
			bool keyDown9 = Input.GetKeyDown(KeyCode.Keypad6);
			if (keyDown9)
			{
				Settings.Speed = !Settings.Speed;
				bool speed = Settings.Speed;
				if (speed)
				{
					Main.LocalPlayerUCL.TimeScale = 5f;
				}
				else
				{
					Main.LocalPlayerUCL.TimeScale = 1f;
				}
			}
			bool keyDown10 = Input.GetKeyDown(KeyCode.Keypad7);
			if (keyDown10)
			{
				foreach (SurvivalDemonBehaviour survivalDemonBehaviour in UnityEngine.Object.FindObjectsOfType<SurvivalDemonBehaviour>())
				{
					survivalDemonBehaviour.Despawn();
				}
			}
			bool flag2 = Time.time > this.t;
			if (flag2)
			{
				Main.Cam = Camera.main;
				Utility.Clear();
				foreach (GameObject gameObject2 in UnityEngine.Object.FindObjectsOfType<GameObject>())
				{
					bool flag3 = gameObject2.tag == "Player" && !Main.Players.Contains(gameObject2);
					if (flag3)
					{
						Main.Players.Add(gameObject2);
					}
					else
					{
						bool flag4 = gameObject2.GetComponent<SurvivalInteractable>() != null && !Main.Items.Contains(gameObject2);
						if (flag4)
						{
							Main.Items.Add(gameObject2);
						}
						else
						{
							bool flag5 = gameObject2.GetComponent<SurvivalAnnaBehaviour>() != null;
							if (flag5)
							{
								this.Anna = gameObject2;
							}
							else
							{
								bool flag6 = gameObject2.name == "SM_RitualBowl";
								if (flag6)
								{
									this.RitualBowl = gameObject2;
								}
							}
						}
					}
				}
				foreach (SurvivalDemonBehaviour survivalDemonBehaviour2 in UnityEngine.Object.FindObjectsOfType<SurvivalDemonBehaviour>())
				{
					bool flag7 = !Main.Demons.Contains(survivalDemonBehaviour2.gameObject);
					if (flag7)
					{
						Main.Demons.Add(survivalDemonBehaviour2.gameObject);
					}
				}
				foreach (GoatBehaviour goatBehaviour in UnityEngine.Object.FindObjectsOfType<GoatBehaviour>())
				{
					bool flag8 = !Main.Goats.Contains(goatBehaviour.gameObject);
					if (flag8)
					{
						Main.Goats.Add(goatBehaviour.gameObject);
					}
				}
				foreach (KeyBehaviour keyBehaviour2 in UnityEngine.Object.FindObjectsOfType<KeyBehaviour>())
				{
					bool flag9 = !Main.Keys.Contains(keyBehaviour2.gameObject);
					if (flag9)
					{
						Main.Keys.Add(keyBehaviour2.gameObject);
					}
				}
				foreach (CollectableInteractable collectableInteractable in UnityEngine.Object.FindObjectsOfType<CollectableInteractable>())
				{
					bool flag10 = !Main.Collectibles.Contains(collectableInteractable.gameObject);
					if (flag10)
					{
						Main.Collectibles.Add(collectableInteractable.gameObject);
					}
				}
				foreach (NoteInteractable noteInteractable in UnityEngine.Object.FindObjectsOfType<NoteInteractable>())
				{
					bool flag11 = !Main.Collectibles.Contains(noteInteractable.gameObject);
					if (flag11)
					{
						Main.Collectibles.Add(noteInteractable.gameObject);
					}
				}
				foreach (GameObject gameObject3 in Main.Players)
				{
					bool flag12 = Vector3.Distance(gameObject3.transform.position, Main.Cam.transform.position) < 2f;
					if (flag12)
					{
						Main.LocalPlayer = gameObject3;
						Main.LocalPlayerNolan = Main.LocalPlayer.GetComponent<NolanBehaviour>();
						Main.LocalPlayerUCL = Main.LocalPlayer.GetComponent<UltimateCharacterLocomotion>();
					}
				}
				foreach (GameObject gameObject4 in Main.Items)
				{
					bool flag13 = gameObject4.name == "SurvivalHay(Clone)";
					if (flag13)
					{
						Main.Map = "Farm";
					}
					else
					{
						bool flag14 = gameObject4.name == "SurvivalFuse(Clone)";
						if (flag14)
						{
							Main.Map = "Asylum";
						}
					}
				}
				bool flag15 = Main.Players.Count > 0;
				if (flag15)
				{
					for (int num4 = 0; num4 < Main.Players.Count; num4++)
					{
						Main.dl[num4] = Main.Players[num4].name;
					}
				}
				this.t = Time.time + this.ti;
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002788 File Offset: 0x00000988
		public void OnGUI()
		{
			GUI.Label(new Rect((float)(Screen.width - 150), 0f, 350f, 100f), "Press INS to open/close");
			GUI.Label(new Rect((float)(Screen.width - 150), 15f, 350f, 100f), "Press DEL to exit");
			GUI.Label(new Rect((float)(Screen.width - 150), 30f, 350f, 100f), string.Format("Anna Spawned? {0}", this.Anna != null && this.Anna.transform.position != new Vector3(0f, 0f, 0f)));
			bool menu = Settings.Menu;
			if (menu)
			{
				bool visuals = Settings.Visuals;
				if (visuals)
				{
					GUI.Window(0, new Rect(0f, 0f, 350f, 300f), new GUI.WindowFunction(this.SwitchWindow), "Visuals [Hi :)]");
				}
				else
				{
					bool playerEditor = Settings.PlayerEditor;
					if (playerEditor)
					{
						GUI.Window(1, new Rect(0f, 0f, 350f, 300f), new GUI.WindowFunction(this.SwitchWindow), "Player Editor [Hi :)] - Idk if works");
					}
				}
			}
			foreach (GameObject gameObject in Main.Players)
			{
				bool flag = gameObject != Main.LocalPlayer && Settings.PlayerEsp;
				if (flag)
				{
					Utility.RenderObj(gameObject, Color.cyan, "Player", true, true, Utility.GetBone(gameObject, HumanBodyBones.RightFoot), Utility.GetBone(gameObject, HumanBodyBones.Head));
					Utility.DrawBones(gameObject, Utility.GetBones(gameObject), Color.cyan);
				}
			}
			foreach (GameObject g in Main.Demons)
			{
				bool demonEsp = Settings.DemonEsp;
				if (demonEsp)
				{
					Utility.RenderObj(g, Color.red, "Demon", true, true, Utility.GetBone(g, HumanBodyBones.RightFoot), Utility.GetBone(g, HumanBodyBones.Head));
					Utility.DrawBones(g, Utility.GetBones(g), Color.red);
				}
			}
			foreach (GameObject g2 in Main.Goats)
			{
				bool goatEsp = Settings.GoatEsp;
				if (goatEsp)
				{
					Utility.RenderObj(g2, Color.green, "", true, false, null, null);
				}
			}
			foreach (GameObject g3 in Main.Items)
			{
				bool itemEsp = Settings.ItemEsp;
				if (itemEsp)
				{
					Utility.RenderObj(g3, Color.yellow, "", false, false, null, null);
				}
			}
			foreach (GameObject gameObject2 in Main.Keys)
			{
				bool flag2 = Settings.KeyEsp && Vector3.Distance(gameObject2.transform.position, Main.Cam.transform.position) < 420f;
				if (flag2)
				{
					bool flag3 = gameObject2.name != "Key(Clone)";
					if (flag3)
					{
						Utility.RenderObj(gameObject2, Color.blue, gameObject2.name, false, false, null, null);
					}
					else
					{
						Utility.RenderObj(gameObject2, Color.blue, "", false, false, null, null);
					}
				}
			}
			foreach (GameObject gameObject3 in Main.Collectibles)
			{
				bool collectibleEsp = Settings.CollectibleEsp;
				if (collectibleEsp)
				{
					Utility.RenderObj(gameObject3, Color.magenta, gameObject3.name, false, false, null, null);
				}
			}
			bool flag4 = Settings.RitualEsp && Main.Map == "Farm";
			if (flag4)
			{
				Utility.RenderObj(this.RitualBowl, Color.red, "Ritual Bowl", false, false, null, null);
			}
			bool annaEsp = Settings.AnnaEsp;
			if (annaEsp)
			{
				Utility.RenderObj(this.Anna, Color.red, "Anna", true, true, Utility.GetBone(this.Anna, HumanBodyBones.RightFoot), Utility.GetBone(this.Anna, HumanBodyBones.Head));
				Utility.DrawBones(this.Anna, Utility.GetBones(this.Anna), Color.red);
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002C84 File Offset: 0x00000E84
		private void SwitchWindow(int id)
		{
			bool flag = GUI.Button(new Rect(1f, 20f, 175f, 25f), "Visuals [Hi :)]");
			if (flag)
			{
				Settings.Visuals = this.AllFalse();
			}
			bool flag2 = GUI.Button(new Rect(175f, 20f, 175f, 25f), "Player Editor [Hi :)]");
			if (flag2)
			{
				Settings.PlayerEditor = this.AllFalse();
			}
			bool flag3 = id == 0;
			if (flag3)
			{
				Settings.AnnaEsp = GUI.Toggle(new Rect(5f, 45f, 150f, 25f), Settings.AnnaEsp, "Anna Esp");
				Settings.PlayerEsp = GUI.Toggle(new Rect(5f, 70f, 150f, 25f), Settings.PlayerEsp, "Player Esp");
				Settings.DemonEsp = GUI.Toggle(new Rect(5f, 95f, 150f, 25f), Settings.DemonEsp, "Demon Esp");
				Settings.GoatEsp = GUI.Toggle(new Rect(5f, 120f, 150f, 25f), Settings.GoatEsp, "Goat Esp");
				Settings.ItemEsp = GUI.Toggle(new Rect(5f, 145f, 150f, 25f), Settings.ItemEsp, "Item Esp");
				Settings.KeyEsp = GUI.Toggle(new Rect(5f, 170f, 150f, 25f), Settings.KeyEsp, "Key Esp");
				Settings.CollectibleEsp = GUI.Toggle(new Rect(5f, 195f, 150f, 25f), Settings.CollectibleEsp, "Collectible Esp");
				Settings.RitualEsp = GUI.Toggle(new Rect(5f, 220f, 150f, 25f), Settings.RitualEsp, "Ritual Bowl Esp");
				GUI.Label(new Rect(150f, 45f, 200f, 100f), "Numpad0-Unlock Robes & Ach.");
				GUI.Label(new Rect(150f, 60f, 200f, 100f), "Numpad1-Unlock Doors");
				GUI.Label(new Rect(150f, 75f, 200f, 100f), "Numpad2-Good Flashlight");
				GUI.Label(new Rect(150f, 90f, 200f, 100f), "Numpad3-Tp Keys 2.5m Ahead");
				GUI.Label(new Rect(150f, 105f, 200f, 100f), "Numpad4-Tp Goats 2.5m Ahead");
				GUI.Label(new Rect(150f, 120f, 200f, 100f), "Numpad5-Tp 2.5m Ahead");
				GUI.Label(new Rect(150f, 135f, 200f, 100f), "Numpad6-5x Speed");
				GUI.Label(new Rect(150f, 150f, 200f, 100f), "Numpad7-Kill Demons");
			}
			else
			{
				bool flag4 = id == 1;
				if (flag4)
				{
					GUI.Label(new Rect(5f, 50f, 250f, 100f), "Player Selector:");
					bool flag5 = GUI.Button(new Rect(this.dr.x, this.dr.y, this.dr.width, 25f), "");
					if (flag5)
					{
						this.show = !this.show;
					}
					bool flag6 = this.show;
					if (flag6)
					{
						GUI.Box(new Rect(this.dr.x, this.dr.y + 25f, this.dr.width, (float)(Main.dl.Length * 25)), "");
						for (int i = 0; i < Main.dl.Length; i++)
						{
							bool flag7 = GUI.Button(new Rect(new Rect(this.dr.x, this.dr.y + 25f + (float)(i * 25), this.dr.width, 25f)), "");
							if (flag7)
							{
								this.show = false;
								this.index = i;
							}
							GUI.Label(new Rect(this.dr.x + 5f, this.dr.y + 25f + (float)(i * 25), this.dr.width, 100f), Main.dl[i]);
						}
					}
					else
					{
						GUI.Label(new Rect(this.dr.x + 5f, this.dr.y, this.dr.width, 100f), Main.dl[this.index]);
					}
					Main.selectedPlayer = null;
					foreach (GameObject gameObject in Main.Players)
					{
						bool flag8 = gameObject.name == Main.dl[this.index];
						if (flag8)
						{
							Main.selectedPlayer = gameObject;
							Main.selectedPlayerNolan = Main.selectedPlayer.GetComponent<NolanBehaviour>();
							Main.selectedPlayerUCL = Main.selectedPlayer.GetComponent<UltimateCharacterLocomotion>();
						}
					}
					bool flag9 = !this.show;
					if (flag9)
					{
						GUI.Label(new Rect(5f, 85f, 250f, 100f), "Name: " + Main.selectedPlayer.GetComponent<UltimateCharacterLocomotion>().name);
						GUI.Label(new Rect(5f, 100f, 250f, 100f), string.Format("Pos: [{0}, {1}, {2}]", (int)Main.selectedPlayer.transform.position.x, (int)Main.selectedPlayer.transform.position.y, (int)Main.selectedPlayer.transform.position.z));
						GUI.Label(new Rect(5f, 115f, 250f, 100f), string.Format("Is Me? {0}", Main.selectedPlayer == Main.LocalPlayer));
						GUI.Label(new Rect(5f, 130f, 250f, 100f), string.Format("Distance From Me: {0}m", Vector3.Distance(Main.Cam.transform.position, Main.selectedPlayer.transform.position)));
						bool flag10 = this.Anna != null;
						if (flag10)
						{
							GUI.Label(new Rect(5f, 145f, 250f, 100f), string.Format("Distance From Anna: {0}m", (int)Vector3.Distance(Main.selectedPlayer.transform.position, this.Anna.transform.position)));
						}
						else
						{
							GUI.Label(new Rect(5f, 145f, 250f, 100f), "Distance From Anna: Anna Not Spawned");
						}
						bool flag11 = GUI.Button(new Rect(5f, 170f, 150f, 25f), "Tp To Player");
						if (flag11)
						{
							Vector3 position = Main.selectedPlayerNolan.transform.position;
							Main.LocalPlayerUCL.SetPosition(new Vector3(position.x + 1f, position.y, position.z));
						}
						bool flag12 = GUI.Button(new Rect(5f, 195f, 150f, 25f), "Tp Player To Me");
						if (flag12)
						{
							Vector3 position2 = Main.LocalPlayerNolan.transform.position;
							Main.selectedPlayerUCL.SetPosition(new Vector3(position2.x + 1f, position2.y, position2.z));
						}
						bool flag13 = GUI.Button(new Rect(5f, 220f, 150f, 25f), "Tp Player To Anna");
						if (flag13)
						{
							Vector3 position3 = this.Anna.transform.position;
							Main.selectedPlayerUCL.SetPosition(new Vector3(position3.x + 1f, position3.y, position3.z));
						}
						bool flag14 = GUI.Button(new Rect(5f, 245f, 150f, 25f), "Strong Flashlight");
						if (flag14)
						{
							Light flashlightSpot = Main.selectedPlayerNolan.flashlightSpot;
							bool flag15 = flashlightSpot.intensity == 4f;
							if (flag15)
							{
								flashlightSpot.intensity = 1.5f;
								flashlightSpot.range = 9f;
							}
							else
							{
								flashlightSpot.intensity = 4f;
								flashlightSpot.range = 60f;
							}
						}
						bool flag16 = GUI.Button(new Rect(5f, 270f, 150f, 25f), "Tp Goats To Player");
						if (flag16)
						{
							foreach (GameObject gameObject2 in Main.Goats)
							{
								gameObject2.GetComponent<UltimateCharacterLocomotion>().SetPosition(Main.selectedPlayerNolan.transform.position + Main.selectedPlayerNolan.transform.forward * 2.5f);
							}
						}
						bool flag17 = GUI.Button(new Rect(200f, 50f, 150f, 25f), "Tp Keys To Player");
						if (flag17)
						{
							foreach (GameObject gameObject3 in Main.Keys)
							{
								gameObject3.GetComponent<UltimateCharacterLocomotion>().SetPosition(Main.selectedPlayerNolan.transform.position + Main.selectedPlayerNolan.transform.forward * 2.5f);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000036EC File Offset: 0x000018EC
		private bool AllFalse()
		{
			Settings.Visuals = false;
			Settings.PlayerEditor = false;
			return true;
		}

		// Token: 0x04000002 RID: 2
		public static GameObject LocalPlayer = null;

		// Token: 0x04000003 RID: 3
		public static NolanBehaviour LocalPlayerNolan = null;

		// Token: 0x04000004 RID: 4
		public static UltimateCharacterLocomotion LocalPlayerUCL = null;

		// Token: 0x04000005 RID: 5
		public static Camera Cam = null;

		// Token: 0x04000006 RID: 6
		public static string Map = "Farm";

		// Token: 0x04000007 RID: 7
		public static List<GameObject> Players = new List<GameObject>();

		// Token: 0x04000008 RID: 8
		public static List<GameObject> Demons = new List<GameObject>();

		// Token: 0x04000009 RID: 9
		public static List<GameObject> Goats = new List<GameObject>();

		// Token: 0x0400000A RID: 10
		public static List<GameObject> Items = new List<GameObject>();

		// Token: 0x0400000B RID: 11
		public static List<GameObject> Keys = new List<GameObject>();

		// Token: 0x0400000C RID: 12
		public static List<GameObject> Collectibles = new List<GameObject>();

		// Token: 0x0400000D RID: 13
		private GameObject Anna = new GameObject();

		// Token: 0x0400000E RID: 14
		private GameObject RitualBowl = new GameObject();

		// Token: 0x0400000F RID: 15
		public Rect dr = new Rect(5f, 65f, 150f, 300f);

		// Token: 0x04000010 RID: 16
		public static string[] dl;

		// Token: 0x04000011 RID: 17
		private int index;

		// Token: 0x04000012 RID: 18
		private bool show = false;

		// Token: 0x04000013 RID: 19
		public static GameObject selectedPlayer = null;

		// Token: 0x04000014 RID: 20
		public static NolanBehaviour selectedPlayerNolan = null;

		// Token: 0x04000015 RID: 21
		public static UltimateCharacterLocomotion selectedPlayerUCL = null;

		// Token: 0x04000016 RID: 22
		private float t;

		// Token: 0x04000017 RID: 23
		private float ti = 4f;
	}
}
