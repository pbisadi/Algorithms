﻿using System;
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
		protected TrieNode _root = new TrieNode(default(key));

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
				n.AddChile(k);	// do not adds it if alrady exists
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

		protected TrieNode FindNode(IEnumerable<key> key, TrieNode n)
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

		public int CountAllStartingWith(IEnumerable<key> k)
		{
			var n = FindNode(k, _root);
			if (n == null) return 0;
			return n.SubTreeValueCount;
		}

		protected class TrieNode
		{
			public TrieNode(key key) { _key = key; }

			private value _Value;
			public value Value
			{
				get { return _Value; }
				set {
					_Value = value;
					if (!IsValueNode)
					{
						UpdateCountToTop(1);
						IsValueNode = true;
					}
				}
			}

			public bool IsValueNode { get; set; }

			private key _key;
			public key Key { get { return _key; } }

			Dictionary<key, TrieNode> _children = new Dictionary<key, TrieNode>();
			public Dictionary<key, TrieNode> Children { get { return _children; } }

			public int SubTreeValueCount { get; internal set; }

			public TrieNode Parent { get; internal set; }

			public void ClearValue()
			{
				_Value = default(value);
				UpdateCountToTop(-1);
				IsValueNode = false;
			}

			/// <summary>
			/// Do not adds it if alrady exists
			/// </summary>
			/// <param name="k">Key</param>
			public void AddChile(key k)
			{
				if (!_children.ContainsKey(k))
				{
					var n = new TrieNode(k);
					_children.Add(k, n);
					n.Parent = this;
				}
			}

			private void UpdateCountToTop(int i)
			{
				var n = this;
				while (n != null)
				{
					n.SubTreeValueCount += i;
					n = n.Parent;
				}
			}
		}
	}
}
