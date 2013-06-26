using System;
using System.Collections.ObjectModel;
using System.IO;

namespace ZipSolution.Core.Tree.Nodes
{
    /// <summary>
    /// Item element.
    /// </summary>
    public abstract class Element : ICloneable
    {
        #region Fields

        private readonly string _fullName;
		private readonly string _name;
		private readonly Collection<Element> _childs = new Collection<Element>();

        #endregion

        #region Abstract Properties

        public abstract Kind Kind { get; }

        #endregion

        #region Public Properties

        public ElementStatus CheckStatus { get; set; }
		
		public string FullName
		{
			get { return _fullName; }
		}
			
		public string Name
		{
			get { return _name; }
		}
			
		public ReadOnlyCollection<Element> ChildNodes
		{
			get { return new ReadOnlyCollection<Element> (_childs); }
		}

        #endregion

        #region Public Methods

        public void DeleteChilds()
		{
			_childs.Clear();
		}
		
		public Element AppendChild(Element child)
		{
			if (child == null)
			{
				throw new ArgumentNullException("child");
			}
			
			_childs.Add(child);
			
			return child;
		}

        #endregion

        #region Constructors

        protected Element(string fullName)
		{
			if (string.IsNullOrEmpty(fullName))
				throw new ArgumentNullException("fullName");
			
			_fullName = fullName;
			
			if (_fullName.EndsWith(":", StringComparison.OrdinalIgnoreCase))
			{
				_fullName = _fullName + Path.DirectorySeparatorChar;
			}			
			
			_name = Path.GetFileName(fullName);
			
			if (string.IsNullOrEmpty(_name))
			{
				_name = fullName;
			}
			
			if (_name.EndsWith(":", StringComparison.OrdinalIgnoreCase))
			{
				_name = _name + Path.DirectorySeparatorChar;
			}
			
			CheckStatus = ElementStatus.Default;
		}

        #endregion

        #region Cloning

        public object Clone()
		{
			if (Kind == Kind.File)
			{
				return new FileElement(_fullName);
			}
			else if (Kind == Kind.Folder)
			{
				return new DirectoryElement(_fullName);
			}
			else
			{
			    throw new NotSupportedException(Kind.ToString());
			}
        }

        #endregion
    }
}
