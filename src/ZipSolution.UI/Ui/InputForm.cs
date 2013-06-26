using System;
using System.Drawing;
using BULocalization;
using System.Windows.Forms;

namespace ZipSolution.UI
{
	/// <summary>
	/// Provides basic input possibilities
	/// </summary>
	internal sealed partial class InputForm : Form
	{
		#region Properties
		
		/// <summary>
		/// The value user input
		/// </summary>
		public string InputValue
		{
			get {return inputBoxTextBox.Text;}
		}
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// The default constructor
		/// </summary>
		/// <param name="caption">The caption of a form</param>
		/// <param name="description">The input description</param>
		/// <param name="defaultValue">The default value to show</param>
		public InputForm(string caption, string description, string defaultValue)
		{
			InitializeComponent();
			
			this.Text = caption;
			descriptionLabel.Text = description;
			inputBoxTextBox.Text = defaultValue;
			
			inputBoxTextBoxTextChanged(this, null);
			cancelButton.Text = Translation.Current[17];
		}
		
		#endregion
		
		#region Private Methods
		
		void inputBoxTextBoxTextChanged(object sender, EventArgs e)
		{
			okButton.Enabled = !string.IsNullOrEmpty(inputBoxTextBox.Text);
		}
		
		#endregion
	}
}
