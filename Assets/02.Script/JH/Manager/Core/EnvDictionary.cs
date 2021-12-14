using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Management.Core
{
	[System.Serializable]
	public class EnvDictionary : SerializableDictionary<Def.SceneName, EnvSetting>
	{

	}

	public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
	{
		[SerializeField]
		private List<TKey> keys = new List<TKey>();

		[SerializeField]
		private List<TValue> values = new List<TValue>();

		public void OnBeforeSerialize()
		{
			keys.Clear();
			values.Clear();
			foreach(KeyValuePair<TKey, TValue> pair in this)
			{
				keys.Add(pair.Key); values.Add(pair.Value);
			}
		}

		public void OnAfterDeserialize()
		{
			this.Clear();
			if (keys.Count > values.Count)
			{
				values.AddRange(new TValue[keys.Count - values.Count]);
			}
			else if (keys.Count == 0) return;
			else if (keys.Count != values.Count)
				throw new System.Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable"));

			for (int i = 0; i < keys.Count; i++)
			{
				this.Add(keys[i], values[i]);
			}
		}
	}
}
