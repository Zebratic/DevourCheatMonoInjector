using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace DevourMono
{
	// Token: 0x02000005 RID: 5
	public class Utility : Main
	{
		// Token: 0x0600000D RID: 13 RVA: 0x00003898 File Offset: 0x00001A98
		public static void InitDrawing()
		{
			Utility.lineTex = new Texture2D(1, 1, TextureFormat.ARGB32, false);
			Utility.lineTex.SetPixel(0, 1, Color.white);
			Utility.lineTex.Apply();
			Utility.blitMat = (Material)typeof(GUI).GetMethod("get_blitMaterial", BindingFlags.Static | BindingFlags.NonPublic).Invoke(null, null);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000038F8 File Offset: 0x00001AF8
		public static void DrawLine(Vector2 start, Vector2 end, Color color, float width)
		{
			float num = end.x - start.x;
			float num2 = end.y - start.y;
			float num3 = Mathf.Sqrt(num * num + num2 * num2);
			bool flag = num3 < 0.001f;
			if (!flag)
			{
				Texture2D image = Utility.lineTex;
				Material material = Utility.blitMat;
				float num4 = width * num2 / num3;
				float num5 = width * num / num3;
				Matrix4x4 identity = Matrix4x4.identity;
				identity.m00 = num;
				identity.m01 = -num4;
				identity.m03 = start.x + 0.5f * num4;
				identity.m10 = num2;
				identity.m11 = num5;
				identity.m13 = start.y - 0.5f * num5;
				GL.PushMatrix();
				GL.MultMatrix(identity);
				GUI.color = color;
				GUI.DrawTexture(Utility.lineRect, image);
				GL.PopMatrix();
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000039DA File Offset: 0x00001BDA
		public static void RectFilled(float x, float y, float width, float height, Texture2D text)
		{
			GUI.DrawTexture(new Rect(x, y, width, height), text);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000039F0 File Offset: 0x00001BF0
		public static void RectOutlined(float x, float y, float width, float height, Texture2D text, float thickness = 1f)
		{
			Utility.RectFilled(x, y, thickness, height, text);
			Utility.RectFilled(x + width - thickness, y, thickness, height, text);
			Utility.RectFilled(x + thickness, y, width - thickness * 2f, thickness, text);
			Utility.RectFilled(x + thickness, y + height - thickness, width - thickness * 2f, thickness, text);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00003A54 File Offset: 0x00001C54
		public static void DrawBox(float x, float y, float width, float height, Texture2D text, float thickness = 1f)
		{
			Utility.RectOutlined(x - width / 2f, y - height, width, height, text, thickness);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00003A70 File Offset: 0x00001C70
		public static void RenderObj(GameObject g, Color color, string name = "", bool drawLine = false, bool drawBox = false, Transform footBone = null, Transform headBone = null)
		{
			GUI.color = color;
			Vector3 vector = Main.Cam.WorldToScreenPoint(g.transform.position);
			Vector3 vector2 = Vector3.zero;
			bool flag = footBone != null;
			if (flag)
			{
				vector = Main.Cam.WorldToScreenPoint(new Vector3(headBone.position.x, footBone.position.y, headBone.position.z));
			}
			bool flag2 = headBone != null;
			if (flag2)
			{
				vector2 = Main.Cam.WorldToScreenPoint(headBone.position);
			}
			float f = Vector3.Distance(Main.Cam.transform.position, g.transform.position);
			string str = string.Format("[{0}]", Mathf.Round(f));
			bool flag3 = vector.z > 0f;
			if (flag3)
			{
				string text = g.name;
				text = text.Replace("(Clone)", "");
				text = text.Replace("Survival", "");
				if (drawLine)
				{
					Utility.DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(vector.x, (float)Screen.height - vector.y), color, 2f);
				}
				float num = Mathf.Abs(vector.y - vector2.y);
				if (drawBox)
				{
					Utility.DrawBox(vector.x, (float)Screen.height - vector.y, num / 1.8f, num, Utility.CreateTexture2D(color), 1f);
				}
				bool flag4 = name == "" || name == null;
				if (flag4)
				{
					GUI.Label(new Rect(vector.x, (float)Screen.height - vector.y, 200f, 200f), text + " " + str);
				}
				else
				{
					GUI.Label(new Rect(vector.x, (float)Screen.height - vector.y, 200f, 200f), name + " " + str);
				}
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00003C94 File Offset: 0x00001E94
		public static void RenderBone(Transform bone1, Transform bone2, Color color)
		{
			Vector3 vector = Main.Cam.WorldToScreenPoint(bone1.position);
			Vector3 vector2 = Main.Cam.WorldToScreenPoint(bone2.position);
			bool flag = vector.z > 0f;
			if (flag)
			{
				Utility.DrawLine(new Vector2(vector.x, (float)Screen.height - vector.y), new Vector2(vector2.x, (float)Screen.height - vector2.y), color, 2f);
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00003D14 File Offset: 0x00001F14
		public static void ReplaceMultipleFields(object obj, string[] names, object[] values, BindingFlags bf)
		{
			for (int i = 0; i < names.Length; i++)
			{
				FieldInfo field = Utility.GetField(obj, names[i], bf);
				Utility.SetValue(field, obj, values[i]);
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003D4C File Offset: 0x00001F4C
		public static void ReplaceField(object obj, string name, object value, BindingFlags bf)
		{
			FieldInfo field = Utility.GetField(obj, name, bf);
			Utility.SetValue(field, obj, value);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003D6C File Offset: 0x00001F6C
		public static FieldInfo GetField(object obj, string fieldName, BindingFlags bf)
		{
			return obj.GetType().GetField(fieldName, bf);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00003D8C File Offset: 0x00001F8C
		public static MethodInfo GetMethod(object obj, string methodName, BindingFlags bf)
		{
			return obj.GetType().GetMethod(methodName, bf);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003DAC File Offset: 0x00001FAC
		public static object GetValue(FieldInfo fi, object obj)
		{
			return fi.GetValue(obj);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003DC5 File Offset: 0x00001FC5
		public static void SetValue(FieldInfo fi, object obj, object value)
		{
			fi.SetValue(obj, value);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00003DD4 File Offset: 0x00001FD4
		public static Transform GetBone(GameObject g, HumanBodyBones bone)
		{
			return g.GetComponent<Animator>().GetBoneTransform(bone);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00003DF4 File Offset: 0x00001FF4
		public static List<Transform> GetBones(GameObject g)
		{
			List<Transform> list = new List<Transform>();
			bool flag = g.name == "SurvivalKai(Clone)";
			List<Transform> result;
			if (flag)
			{
				list.Add(Utility.GetBone(g, HumanBodyBones.Head));
				list.Add(Utility.GetBone(g, HumanBodyBones.Neck));
				list.Add(Utility.GetBone(g, HumanBodyBones.Spine));
				list.Add(Utility.GetBone(g, HumanBodyBones.LeftShoulder));
				list.Add(Utility.GetBone(g, HumanBodyBones.LeftUpperArm));
				list.Add(Utility.GetBone(g, HumanBodyBones.LeftLowerArm));
				list.Add(Utility.GetBone(g, HumanBodyBones.LeftHand));
				list.Add(Utility.GetBone(g, HumanBodyBones.RightShoulder));
				list.Add(Utility.GetBone(g, HumanBodyBones.RightUpperArm));
				list.Add(Utility.GetBone(g, HumanBodyBones.RightLowerArm));
				list.Add(Utility.GetBone(g, HumanBodyBones.RightHand));
				list.Add(Utility.GetBone(g, HumanBodyBones.Hips));
				list.Add(Utility.GetBone(g, HumanBodyBones.LeftUpperLeg));
				list.Add(Utility.GetBone(g, HumanBodyBones.LeftLowerLeg));
				list.Add(Utility.GetBone(g, HumanBodyBones.LeftFoot));
				list.Add(Utility.GetBone(g, HumanBodyBones.RightUpperLeg));
				list.Add(Utility.GetBone(g, HumanBodyBones.RightLowerLeg));
				list.Add(Utility.GetBone(g, HumanBodyBones.RightFoot));
				result = list;
			}
			else
			{
				list.Add(Utility.GetBone(g, HumanBodyBones.Head));
				list.Add(Utility.GetBone(g, HumanBodyBones.Neck));
				list.Add(Utility.GetBone(g, HumanBodyBones.Spine));
				list.Add(Utility.GetBone(g, HumanBodyBones.Chest));
				list.Add(Utility.GetBone(g, HumanBodyBones.UpperChest));
				list.Add(Utility.GetBone(g, HumanBodyBones.LeftShoulder));
				list.Add(Utility.GetBone(g, HumanBodyBones.LeftUpperArm));
				list.Add(Utility.GetBone(g, HumanBodyBones.LeftLowerArm));
				list.Add(Utility.GetBone(g, HumanBodyBones.LeftHand));
				list.Add(Utility.GetBone(g, HumanBodyBones.RightShoulder));
				list.Add(Utility.GetBone(g, HumanBodyBones.RightUpperArm));
				list.Add(Utility.GetBone(g, HumanBodyBones.RightLowerArm));
				list.Add(Utility.GetBone(g, HumanBodyBones.RightHand));
				list.Add(Utility.GetBone(g, HumanBodyBones.Hips));
				list.Add(Utility.GetBone(g, HumanBodyBones.LeftUpperLeg));
				list.Add(Utility.GetBone(g, HumanBodyBones.LeftFoot));
				list.Add(Utility.GetBone(g, HumanBodyBones.LeftLowerLeg));
				list.Add(Utility.GetBone(g, HumanBodyBones.RightUpperLeg));
				list.Add(Utility.GetBone(g, HumanBodyBones.RightLowerLeg));
				list.Add(Utility.GetBone(g, HumanBodyBones.RightFoot));
				result = list;
			}
			return result;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00004058 File Offset: 0x00002258
		public static void DrawBones(GameObject g, List<Transform> bones, Color color)
		{
			bool flag = g.name == "SurvivalKai(Clone)";
			if (flag)
			{
				Utility.RenderBone(bones[0], bones[1], color);
				Utility.RenderBone(bones[1], bones[2], color);
				Utility.RenderBone(bones[2], bones[11], color);
				Utility.RenderBone(bones[2], bones[3], color);
				Utility.RenderBone(bones[3], bones[4], color);
				Utility.RenderBone(bones[4], bones[5], color);
				Utility.RenderBone(bones[5], bones[6], color);
				Utility.RenderBone(bones[2], bones[7], color);
				Utility.RenderBone(bones[7], bones[8], color);
				Utility.RenderBone(bones[8], bones[9], color);
				Utility.RenderBone(bones[9], bones[10], color);
				bool flag2 = Main.Map == "Farm";
				if (flag2)
				{
					Utility.RenderBone(bones[11], bones[12], color);
				}
				else
				{
					bool flag3 = Main.Map == "Asylum";
					if (flag3)
					{
						Utility.RenderBone(bones[2], bones[12], color);
					}
				}
				Utility.RenderBone(bones[12], bones[13], color);
				Utility.RenderBone(bones[13], bones[14], color);
				bool flag4 = Main.Map == "Farm";
				if (flag4)
				{
					Utility.RenderBone(bones[11], bones[15], color);
				}
				else
				{
					bool flag5 = Main.Map == "Asylum";
					if (flag5)
					{
						Utility.RenderBone(bones[2], bones[15], color);
					}
				}
				Utility.RenderBone(bones[15], bones[16], color);
				Utility.RenderBone(bones[16], bones[17], color);
			}
			else
			{
				Utility.RenderBone(bones[0], bones[1], color);
				Utility.RenderBone(bones[1], bones[4], color);
				Utility.RenderBone(bones[2], bones[3], color);
				Utility.RenderBone(bones[3], bones[4], color);
				bool flag6 = Main.Map == "Farm" || Main.Players.Contains(g);
				if (flag6)
				{
					Utility.RenderBone(bones[2], bones[13], color);
				}
				Utility.RenderBone(bones[4], bones[5], color);
				Utility.RenderBone(bones[5], bones[6], color);
				Utility.RenderBone(bones[6], bones[7], color);
				Utility.RenderBone(bones[7], bones[8], color);
				Utility.RenderBone(bones[4], bones[9], color);
				Utility.RenderBone(bones[9], bones[10], color);
				Utility.RenderBone(bones[10], bones[11], color);
				Utility.RenderBone(bones[11], bones[12], color);
				bool flag7 = Main.Map == "Farm" || Main.Players.Contains(g);
				if (flag7)
				{
					Utility.RenderBone(bones[13], bones[14], color);
				}
				else
				{
					bool flag8 = Main.Map == "Asylum";
					if (flag8)
					{
						Utility.RenderBone(bones[2], bones[14], color);
					}
				}
				Utility.RenderBone(bones[14], bones[15], color);
				bool flag9 = Main.Map == "Farm" || Main.Players.Contains(g);
				if (flag9)
				{
					Utility.RenderBone(bones[13], bones[17], color);
				}
				else
				{
					bool flag10 = Main.Map == "Asylum";
					if (flag10)
					{
						Utility.RenderBone(bones[2], bones[17], color);
					}
				}
				Utility.RenderBone(bones[17], bones[18], color);
				Utility.RenderBone(bones[18], bones[19], color);
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000044D0 File Offset: 0x000026D0
		public static Texture2D CreateTexture2D(Color color)
		{
			Texture2D texture2D = new Texture2D(1, 1, TextureFormat.ARGB32, false);
			texture2D.SetPixel(1, 0, color);
			texture2D.SetPixel(0, 1, color);
			texture2D.SetPixel(1, 1, color);
			texture2D.Apply();
			return texture2D;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00004514 File Offset: 0x00002714
		public static void Clear()
		{
			Main.Players.Clear();
			Main.Demons.Clear();
			Main.Goats.Clear();
			Main.Items.Clear();
			Main.Keys.Clear();
			Main.Collectibles.Clear();
			Main.dl = new string[]
			{
				"Null",
				"Null",
				"Null",
				"Null"
			};
		}

		// Token: 0x0400002D RID: 45
		public static Texture2D lineTex;

		// Token: 0x0400002E RID: 46
		public static Material blitMat;

		// Token: 0x0400002F RID: 47
		public static Rect lineRect = new Rect(0f, 0f, 1f, 1f);
	}
}
