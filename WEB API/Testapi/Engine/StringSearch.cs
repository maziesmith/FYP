using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testapi.Models;
using System.Collections;

namespace Testapi.Engine
{
    public class StringSearch
    {

        public static int nodeCount;
        /// <summary>
        /// Tree node representing character and its 
        /// transition and failure function
        /// </summary>
        public class TreeNode
        {

            #region Constructor & Methods

            /// <summary>
            /// Initialize tree node with specified character
            /// </summary>
            /// <param name="parent">Parent node</param>
            /// <param name="c">Character</param>
            public TreeNode(TreeNode parent, char c)
            {
                _char = c; _parent = parent;
                _results = new ArrayList();
                _resultsAr = new string[] { };

                _transitionsAr = new TreeNode[] { };
                _transHash = new Hashtable();
                state = nodeCount;
                nodeCount++;
            }


            /// <summary>
            /// Adds pattern ending in this node
            /// </summary>
            /// <param name="result">Pattern</param>
            public void AddResult(string result)
            {
                if (_results.Contains(result)) return;
                _results.Add(result);
                _resultsAr = (string[])_results.ToArray(typeof(string));
            }

            /// <summary>
            /// Adds trabsition node
            /// </summary>
            /// <param name="node">Node</param>
            public void AddTransition(TreeNode node)
            {
                _transHash.Add(node.Char, node);
                TreeNode[] ar = new TreeNode[_transHash.Values.Count];
                _transHash.Values.CopyTo(ar, 0);
                _transitionsAr = ar;
            }


            /// <summary>
            /// Returns transition to specified character (if exists)
            /// </summary>
            /// <param name="c">Character</param>
            /// <returns>Returns TreeNode or null</returns>
            public TreeNode GetTransition(char c)
            {
                return (TreeNode)_transHash[c];
            }


            /// <summary>
            /// Returns true if node contains transition to specified character
            /// </summary>
            /// <param name="c">Character</param>
            /// <returns>True if transition exists</returns>
            public bool ContainsTransition(char c)
            {
                return GetTransition(c) != null;
            }

            #endregion
            #region Properties

            private char _char;
            private TreeNode _parent;
            private TreeNode _failure;
            public ArrayList _results;
            private TreeNode[] _transitionsAr;
            public string[] _resultsAr;
            public Hashtable _transHash;

            public int state;
            /// <summary>
            /// Character
            /// </summary>
            public char Char
            {
                get { return _char; }
            }


            /// <summary>
            /// Parent tree node
            /// </summary>
            public TreeNode Parent
            {
                get { return _parent; }
            }


            /// <summary>
            /// Failure function - descendant node
            /// </summary>
            public TreeNode Failure
            {
                get { return _failure; }
                set { _failure = value; }
            }


            /// <summary>
            /// Transition function - list of descendant nodes
            /// </summary>
            public TreeNode[] Transitions
            {
                get { return _transitionsAr; }
            }


            /// <summary>
            /// Returns list of patterns ending by this letter
            /// </summary>
            public string[] Results
            {
                get { return _resultsAr; }
            }

            #endregion
        }


        //////////////////////////////////////////
        /// <summary>
        /// Root of keyword tree
        /// </summary>
        public TreeNode _root;

        /// <summary>
        /// Keywords to search for
        /// </summary>
        private string[] _keywords;





        /// <summary>
        /// Initialize search algorithm (Build keyword tree)
        /// </summary>
        /// <param name="keywords">Keywords to search for</param>
        public StringSearch(string[] keywords)
        {
            nodeCount = 0;
            Keywords = keywords;
            //keys = new List<string>();
            // nodeCount = 0;
        }


        /// <summary>
        /// Initialize search algorithm with no keywords
        /// (Use Keywords property)
        /// </summary>
        public StringSearch()
        { }



        /// <summary>
        /// Build tree from specified keywords
        /// </summary>
        void BuildTree()
        {
            // Build keyword tree and transition function
            _root = new TreeNode(null, ' ');
            foreach (string p in _keywords)
            {
                // add pattern to tree
                TreeNode nd = _root;
                foreach (char c in p)
                {
                    TreeNode ndNew = null;
                    foreach (TreeNode trans in nd.Transitions)
                        if (trans.Char == c) { ndNew = trans; break; }

                    if (ndNew == null)
                    {
                        ndNew = new TreeNode(nd, c);
                        nd.AddTransition(ndNew);
                    }
                    nd = ndNew;
                }
                nd.AddResult(p);
            }

            // Find failure functions
            ArrayList nodes = new ArrayList();
            // level 1 nodes - fail to root node
            foreach (TreeNode nd in _root.Transitions)
            {
                nd.Failure = _root;
                foreach (TreeNode trans in nd.Transitions) nodes.Add(trans);
            }
            // other nodes - using BFS
            while (nodes.Count != 0)
            {
                ArrayList newNodes = new ArrayList();
                foreach (TreeNode nd in nodes)
                {
                    TreeNode r = nd.Parent.Failure;
                    char c = nd.Char;

                    while (r != null && !r.ContainsTransition(c)) r = r.Failure;
                    if (r == null)
                        nd.Failure = _root;
                    else
                    {
                        nd.Failure = r.GetTransition(c);
                        foreach (string result in nd.Failure.Results)
                            nd.AddResult(result);
                    }

                    // add child nodes to BFS list 
                    foreach (TreeNode child in nd.Transitions)
                        newNodes.Add(child);
                }
                nodes = newNodes;
            }
            _root.Failure = _root;
        }





        /// <summary>
        /// Keywords to search for (setting this property is slow, because
        /// it requieres rebuilding of keyword tree)
        /// </summary>
        public string[] Keywords
        {
            get { return _keywords; }
            set
            {
                _keywords = value;
                BuildTree();
                keys = _keywords.ToList<string>();
            }
        }

        public List<string> keys;

        /// <summary>
        /// Searches passed text and returns all occurrences of any keyword
        /// </summary>
        /// <param name="text">Text to search</param>
        /// <returns>Array of occurrences</returns>
        public StringSearchResult[] FindAll(string text)
        {
            ArrayList ret = new ArrayList();
            TreeNode ptr = _root;
            int index = 0;

            while (index < text.Length)
            {
                TreeNode trans = null;
                while (trans == null)
                {
                    trans = ptr.GetTransition(text[index]);
                    if (ptr == _root) break;
                    if (trans == null) ptr = ptr.Failure;
                }
                if (trans != null) ptr = trans;

                foreach (string found in ptr.Results)
                    ret.Add(new StringSearchResult(index - found.Length + 1, found));
                index++;
            }
            return (StringSearchResult[])ret.ToArray(typeof(StringSearchResult));
        }

        public int[] FindAl(string text)
        {
            ArrayList ret = new ArrayList();
            TreeNode ptr = _root;
            int index = 0;
            int[] ans = new int[Keywords.Length];
            for (int k = 0; k < Keywords.Length; k++)
                ans[k] = 0;

            while (index < text.Length)
            {
                TreeNode trans = null;
                while (trans == null)
                {
                    trans = ptr.GetTransition(text[index]);
                    if (ptr == _root) break;
                    if (trans == null) ptr = ptr.Failure;
                }
                if (trans != null) ptr = trans;

                foreach (string found in ptr.Results)
                {
                    ans[keys.IndexOf(found)]++;
                }
                //ret.Add(new StringSearchResult(index - found.Length + 1, found));
                index++;
            }
            return (ans);
        }



        /// <summary>
        /// Searches passed text and returns first occurrence of any keyword
        /// </summary>
        /// <param name="text">Text to search</param>
        /// <returns>First occurrence of any keyword (or StringSearchResult.Empty if text doesn't contain any keyword)</returns>
        public StringSearchResult FindFirst(string text)
        {
            ArrayList ret = new ArrayList();
            TreeNode ptr = _root;
            int index = 0;

            while (index < text.Length)
            {
                TreeNode trans = null;
                while (trans == null)
                {
                    trans = ptr.GetTransition(text[index]);
                    if (ptr == _root) break;
                    if (trans == null) ptr = ptr.Failure;
                }
                if (trans != null) ptr = trans;

                foreach (string found in ptr.Results)
                    return new StringSearchResult(index - found.Length + 1, found);
                index++;
            }
            return StringSearchResult.Empty;
        }


        /// <summary>
        /// Searches passed text and returns true if text contains any keyword
        /// </summary>
        /// <param name="text">Text to search</param>
        /// <returns>True when text contains any keyword</returns>
        public bool ContainsAny(string text)
        {
            TreeNode ptr = _root;
            int index = 0;

            while (index < text.Length)
            {
                TreeNode trans = null;
                while (trans == null)
                {
                    trans = ptr.GetTransition(text[index]);
                    if (ptr == _root) break;
                    if (trans == null) ptr = ptr.Failure;
                }
                if (trans != null) ptr = trans;

                if (ptr.Results.Length > 0) return true;
                index++;
            }
            return false;
        }



        public void build_table(Hashtable[] tab, TreeNode node)
        {
            foreach (DictionaryEntry entry in node._transHash)
                tab[node.state].Add(entry.Key, ((TreeNode)entry.Value).state);

            foreach (DictionaryEntry entry in node._transHash)
                build_table(tab, (TreeNode)entry.Value);




        }

        public void build_table1(int[,] table1, TreeNode node)
        {
            foreach (DictionaryEntry entry in node._transHash)
                table1[node.state, (Convert.ToInt16(entry.Key) - Convert.ToInt16('A'))] = ((TreeNode)entry.Value).state;

            foreach (DictionaryEntry entry in node._transHash)
                build_table1(table1, (TreeNode)entry.Value);




        }


        public void build_tableO(int[] table1, TreeNode node)
        {
            foreach (DictionaryEntry entry in node._transHash)
            {
                if (((TreeNode)entry.Value)._results.Count > 0)
                {
                    foreach (string s in ((TreeNode)entry.Value)._resultsAr)
                    {
                        table1[((TreeNode)entry.Value).state] = keys.IndexOf(s) + 1;
                    }
                }
                else
                    table1[node.state] = 0;
            }


            foreach (DictionaryEntry entry in node._transHash)
                build_tableO(table1, (TreeNode)entry.Value);




        }









    }
}