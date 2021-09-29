// Decompiled with JetBrains decompiler
// Type: AudioGenetator.AboutBox
// Assembly: AudioGenetator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=beaa9c357ca987d8
// MVID: 47AA44B6-B43A-45ED-BE9C-D6D0B391B2BF
// Assembly location: C:\Users\user\AppData\Local\Apps\2.0\2D48149K.0WA\KDWBYXGE.CGT\audi..tion_f923b6c0b495be75_0001.0000_aa06e220d98a2a45\AudioGenetator.exe

using AudioGenetator.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace AudioGenetator
{
  internal class AboutBox : Form
  {
    private IContainer components = (IContainer) null;
    private TableLayoutPanel tableLayoutPanel;
    private PictureBox logoPictureBox;
    private Label labelProductName;
    private Label labelVersion;
    private Label labelCopyright;
    private Label labelCompanyName;
    private TextBox textBoxDescription;
    private Button okButton;

    public AboutBox()
    {
      this.InitializeComponent();
      this.Text = string.Format("Acerca de {0}", (object) this.AssemblyTitle);
      this.labelProductName.Text = this.AssemblyProduct;
      this.labelVersion.Text = string.Format("Versión {0}", (object) this.AssemblyVersion);
      this.textBoxDescription.Text = this.AssemblyDescription;
    }

    public string AssemblyTitle
    {
      get
      {
        object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyTitleAttribute), false);
        if ((uint) customAttributes.Length > 0U)
        {
          AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute) customAttributes[0];
          if (assemblyTitleAttribute.Title != "")
            return assemblyTitleAttribute.Title;
        }
        return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
      }
    }

    public string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

    public string AssemblyDescription
    {
      get
      {
        object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyDescriptionAttribute), false);
        return customAttributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute) customAttributes[0]).Description;
      }
    }

    public string AssemblyProduct
    {
      get
      {
        object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyProductAttribute), false);
        return customAttributes.Length == 0 ? "" : ((AssemblyProductAttribute) customAttributes[0]).Product;
      }
    }

    public string AssemblyCopyright
    {
      get
      {
        object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCopyrightAttribute), false);
        return customAttributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute) customAttributes[0]).Copyright;
      }
    }

    public string AssemblyCompany
    {
      get
      {
        object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCompanyAttribute), false);
        return customAttributes.Length == 0 ? "" : ((AssemblyCompanyAttribute) customAttributes[0]).Company;
      }
    }

    private void okButton_Click(object sender, EventArgs e) => this.Hide();

    private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
    {
    }

    private void labelCompanyName_Click(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.tableLayoutPanel = new TableLayoutPanel();
      this.logoPictureBox = new PictureBox();
      this.labelProductName = new Label();
      this.labelVersion = new Label();
      this.labelCopyright = new Label();
      this.labelCompanyName = new Label();
      this.textBoxDescription = new TextBox();
      this.okButton = new Button();
      this.tableLayoutPanel.SuspendLayout();
      ((ISupportInitialize) this.logoPictureBox).BeginInit();
      this.SuspendLayout();
      this.tableLayoutPanel.ColumnCount = 2;
      this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56.65467f));
      this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43.34533f));
      this.tableLayoutPanel.Controls.Add((Control) this.logoPictureBox, 0, 0);
      this.tableLayoutPanel.Controls.Add((Control) this.labelProductName, 1, 0);
      this.tableLayoutPanel.Controls.Add((Control) this.labelVersion, 1, 1);
      this.tableLayoutPanel.Controls.Add((Control) this.labelCopyright, 1, 2);
      this.tableLayoutPanel.Controls.Add((Control) this.labelCompanyName, 1, 3);
      this.tableLayoutPanel.Controls.Add((Control) this.textBoxDescription, 1, 4);
      this.tableLayoutPanel.Controls.Add((Control) this.okButton, 1, 5);
      this.tableLayoutPanel.Dock = DockStyle.Fill;
      this.tableLayoutPanel.Location = new Point(12, 11);
      this.tableLayoutPanel.Margin = new Padding(4, 4, 4, 4);
      this.tableLayoutPanel.Name = "tableLayoutPanel";
      this.tableLayoutPanel.RowCount = 6;
      this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
      this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
      this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
      this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 30.90909f));
      this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 19.54545f));
      this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 19.09091f));
      this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel.Size = new Size(876, 220);
      this.tableLayoutPanel.TabIndex = 0;
      this.tableLayoutPanel.Paint += new PaintEventHandler(this.tableLayoutPanel_Paint);
      this.logoPictureBox.Dock = DockStyle.Fill;
      this.logoPictureBox.Image = (Image) Resources.Logo_Np;
      this.logoPictureBox.Location = new Point(4, 4);
      this.logoPictureBox.Margin = new Padding(4, 4, 4, 4);
      this.logoPictureBox.Name = "logoPictureBox";
      this.tableLayoutPanel.SetRowSpan((Control) this.logoPictureBox, 6);
      this.logoPictureBox.Size = new Size(488, 212);
      this.logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
      this.logoPictureBox.TabIndex = 12;
      this.logoPictureBox.TabStop = false;
      this.labelProductName.Dock = DockStyle.Fill;
      this.labelProductName.Font = new Font("Microsoft Tai Le", 10.2f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelProductName.Location = new Point(504, 0);
      this.labelProductName.Margin = new Padding(8, 0, 4, 0);
      this.labelProductName.MaximumSize = new Size(0, 21);
      this.labelProductName.Name = "labelProductName";
      this.labelProductName.Size = new Size(368, 21);
      this.labelProductName.TabIndex = 19;
      this.labelProductName.Text = "AudioGenerator";
      this.labelProductName.TextAlign = ContentAlignment.MiddleLeft;
      this.labelVersion.Dock = DockStyle.Fill;
      this.labelVersion.Font = new Font("Microsoft Tai Le", 10.2f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelVersion.Location = new Point(504, 22);
      this.labelVersion.Margin = new Padding(8, 0, 4, 0);
      this.labelVersion.MaximumSize = new Size(0, 21);
      this.labelVersion.Name = "labelVersion";
      this.labelVersion.Size = new Size(368, 21);
      this.labelVersion.TabIndex = 0;
      this.labelVersion.Text = "Versión 1.2";
      this.labelVersion.TextAlign = ContentAlignment.MiddleLeft;
      this.labelCopyright.Dock = DockStyle.Fill;
      this.labelCopyright.Font = new Font("Microsoft Tai Le", 10.2f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelCopyright.Location = new Point(504, 44);
      this.labelCopyright.Margin = new Padding(8, 0, 4, 0);
      this.labelCopyright.MaximumSize = new Size(0, 21);
      this.labelCopyright.Name = "labelCopyright";
      this.labelCopyright.Size = new Size(368, 21);
      this.labelCopyright.TabIndex = 21;
      this.labelCopyright.Text = "Copyright nipusan @2021";
      this.labelCopyright.TextAlign = ContentAlignment.MiddleLeft;
      this.labelCompanyName.Dock = DockStyle.Fill;
      this.labelCompanyName.Font = new Font("Microsoft Tai Le", 10.2f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelCompanyName.ForeColor = SystemColors.ActiveCaptionText;
      this.labelCompanyName.Location = new Point(504, 66);
      this.labelCompanyName.Margin = new Padding(8, 0, 4, 0);
      this.labelCompanyName.MaximumSize = new Size(0, 21);
      this.labelCompanyName.Name = "labelCompanyName";
      this.labelCompanyName.Size = new Size(368, 21);
      this.labelCompanyName.TabIndex = 22;
      this.labelCompanyName.Text = "By: Nixon Sanchez";
      this.labelCompanyName.TextAlign = ContentAlignment.MiddleLeft;
      this.labelCompanyName.Click += new EventHandler(this.labelCompanyName_Click);
      this.textBoxDescription.Dock = DockStyle.Fill;
      this.textBoxDescription.Font = new Font("Microsoft Tai Le", 10.2f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBoxDescription.Location = new Point(504, 138);
      this.textBoxDescription.Margin = new Padding(8, 4, 4, 4);
      this.textBoxDescription.Multiline = true;
      this.textBoxDescription.Name = "textBoxDescription";
      this.textBoxDescription.ReadOnly = true;
      this.textBoxDescription.ScrollBars = ScrollBars.Both;
      this.textBoxDescription.Size = new Size(368, 35);
      this.textBoxDescription.TabIndex = 23;
      this.textBoxDescription.TabStop = false;
      this.textBoxDescription.Text = "By:\r\n\r\nNixon Sanchez";
      this.okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.okButton.DialogResult = DialogResult.Cancel;
      this.okButton.Location = new Point(772, 188);
      this.okButton.Margin = new Padding(4, 4, 4, 4);
      this.okButton.Name = "okButton";
      this.okButton.Size = new Size(100, 28);
      this.okButton.TabIndex = 24;
      this.okButton.Text = "&Aceptar";
      this.okButton.Click += new EventHandler(this.okButton_Click);
      this.AcceptButton = (IButtonControl) this.okButton;
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(900, 242);
      this.Controls.Add((Control) this.tableLayoutPanel);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Margin = new Padding(4, 4, 4, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (AboutBox);
      this.Padding = new Padding(12, 11, 12, 11);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (AboutBox);
      this.tableLayoutPanel.ResumeLayout(false);
      this.tableLayoutPanel.PerformLayout();
      ((ISupportInitialize) this.logoPictureBox).EndInit();
      this.ResumeLayout(false);
    }
  }
}
