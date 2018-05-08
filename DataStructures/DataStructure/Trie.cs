using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DataStructure
{
	/// <summary>
	/// It is a generic Trie DS.
	/// For using it as a dictionary, instanciate it with char as key
	/// </summary>
	/// <typeparam name="key"></typeparam>
	/// <typeparam name="value"></typeparam>
	public class Trie<key,value>
	{
		TrieNode _root = new TrieNode(default(key));

		/// <summary>
		/// Add the new pair of keys and value to Trie.
		/// If the key already exists, override the value.
		/// </summary>
		/// <param name="k"></param>
		/// <param name="v"></param>
		public void Add(IEnumerable<key> key, value value)
		{
			var n = _root;
			foreach (key k in key)
			{
				if (!n.Children.ContainsKey(k)) n.Children.Add(k, new TrieNode(k));
				n = n.Children[k];
			}
			n.Value = value;
		}

		public void Remove(IEnumerable<key> key)
		{
			FindNode(key, _root).ClearValue();
		}

		/// <summary>
		/// Find the value added exactly by provided key
		/// </summary>
		/// <param name="k">The key of the value. Ex. String of chars</param>
		/// <returns>Return the value or default/null if it is not avaiable</returns>
		public value Find(IEnumerable<key> key)
		{
			var result = FindNode(key, _root);
			if (result != null) return result.Value;
			return default(value);
		}

		private TrieNode FindNode(IEnumerable<key> key, TrieNode n)
		{
			foreach (key k in key)
			{
				if (n.Children.ContainsKey(k))
					n = n.Children[k];
				else
					return null;
			}
			return n;
		}

		public IEnumerable<value> FindAllStartingWith(IEnumerable<key> k)
		{
			var q = new Queue<TrieNode>();
			var result = new List<value>();
			var n = FindNode(k, _root);
			if (n == null) return result;

			q.Enqueue(n);
			do
			{
				n = q.Dequeue();
				if (n.IsValueNode) result.Add(n.Value);
				foreach (var ch in n.Children.Values)
				{
					q.Enqueue(ch);
				}
			} while (q.Count > 0);
			return result;
		}

		private class TrieNode
		{
			public TrieNode(key key) { _key = key; }

			private value _Value;
			public value Value
			{
				get { return _Value; }
				set {
					_Value = value;
					IsValueNode = true;
				}
			}

			public bool IsValueNode { get; set; }

			private key _key;
			public key Key { get { return _key; } }

			Dictionary<key, TrieNode> _children = new Dictionary<key, TrieNode>();
			public Dictionary<key, TrieNode> Children { get { return _children; } }

			public void ClearValue()
			{
				_Value = default(value);
				IsValueNode = false;
			}
		}
	}
}
