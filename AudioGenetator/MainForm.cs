// Decompiled with JetBrains decompiler
// Type: AudioGenetator.Form1
// Assembly: AudioGenetator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=beaa9c357ca987d8
// MVID: 47AA44B6-B43A-45ED-BE9C-D6D0B391B2BF
// Assembly location: C:\Users\user\AppData\Local\Apps\2.0\2D48149K.0WA\KDWBYXGE.CGT\audi..tion_f923b6c0b495be75_0001.0000_aa06e220d98a2a45\AudioGenetator.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Media;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.Xml;

namespace AudioGenetator
{
    public class MainForm : Form
    {
        private SpeechSynthesizer _ss = new SpeechSynthesizer();
        private string voicesSelected = "";
        private IContainer components = (IContainer)null;
        private Button btn_cargarXML;
        private TextBox tb_url;
        private Label label1;
        private Button btn_buscar;
        private Button btn_clear;
        private Label label2;
        private TextBox tb_salida;
        private Button btn_seleccionarSalida;
        private ComboBox vozSelectCB;
        private Label label3;
        private CheckBox cargarXmlCheckBox;
        private TabControl inPutOutOutText_tabControl;
        private TabPage tabPage_input;
        private TabPage tabPage_output;
        private TextBox tb_output;
        private TextBox tb_input;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem asercaDeToolStripMenuItem;

        private int create = 0, count = 0;

        public MainForm()
        {
            this.InitializeComponent();
            this.tb_url.Enabled = false;
            this.btn_buscar.Enabled = false;
            this.tb_input.ReadOnly = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.tb_output.ScrollBars = ScrollBars.Both;
            this.btn_buscar.Focus();
            using (SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer())
            {
                Console.WriteLine("Installed voices for the en-US locale:");
                foreach (InstalledVoice installedVoice in speechSynthesizer.GetInstalledVoices(new CultureInfo("en-US")))
                    MainForm.OutputVoiceInfo(installedVoice.VoiceInfo);
                Console.WriteLine();
                Console.WriteLine("Current voice:");
                MainForm.OutputVoiceInfo(speechSynthesizer.Voice);
            }
            using (SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer())
            {
                Console.WriteLine("Installed voices -");
                foreach (InstalledVoice installedVoice in speechSynthesizer.GetInstalledVoices())
                {
                    VoiceInfo voiceInfo = installedVoice.VoiceInfo;
                    string str1 = "";
                    foreach (SpeechAudioFormatInfo supportedAudioFormat in voiceInfo.SupportedAudioFormats)
                        str1 += string.Format("{0}", (object)supportedAudioFormat.EncodingFormat.ToString());
                    this.vozSelectCB.Items.Add((object)voiceInfo.Name);
                    Console.WriteLine(" Name:          " + voiceInfo.Name);
                    Console.WriteLine(" Culture:       " + (object)voiceInfo.Culture);
                    Console.WriteLine(" Age:           " + (object)voiceInfo.Age);
                    Console.WriteLine(" Gender:        " + (object)voiceInfo.Gender);
                    Console.WriteLine(" Description:   " + voiceInfo.Description);
                    Console.WriteLine(" ID:            " + voiceInfo.Id);
                    Console.WriteLine(" Enabled:       " + installedVoice.Enabled.ToString());
                    if ((uint)voiceInfo.SupportedAudioFormats.Count > 0U)
                        Console.WriteLine(" Audio formats: " + str1);
                    else
                        Console.WriteLine(" No supported audio formats found");
                    string str2 = "";
                    foreach (string key in (IEnumerable<string>)voiceInfo.AdditionalInfo.Keys)
                        str2 += string.Format("  {0}: {1}", (object)key, (object)voiceInfo.AdditionalInfo[key]);
                    Console.WriteLine(" Additional Info - " + str2);
                    Console.WriteLine();
                }
            }
        }

        private static void OutputVoiceInfo(VoiceInfo info)
        {
            Console.WriteLine("  Name: {0}, culture: {1}, gender: {2}, age: {3}.", new object[4]
            {
        (object) info.Name,
        (object) info.Culture,
        (object) info.Gender,
        (object) info.Age
            });
            Console.WriteLine("    Description: {0}", (object)info.Description);
        }

        public void crearAudio(string nombre, string texto)
        {
            try
            {
                SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                speechSynthesizer.SelectVoice(this.voicesSelected);
                speechSynthesizer.SetOutputToWaveFile(this.tb_salida.Text + "\\" + nombre, new SpeechAudioFormatInfo(8000, AudioBitsPerSample.Eight, AudioChannel.Mono));
                speechSynthesizer.Speak(texto);
                PromptBuilder promptBuilder = new PromptBuilder();
                promptBuilder.AppendText(texto);
                speechSynthesizer.SpeakAsync(promptBuilder);
                Console.WriteLine();
                Console.WriteLine("proceso finalizado...");
                speechSynthesizer.Dispose();
                this.tb_output.Text += string.Format("{1} => {2}{0}", (object)Environment.NewLine, (object)DateTime.Now.ToString("G"), (object)nombre);
                this.tb_output.Text += string.Format("{1} => {2}{0}", (object)Environment.NewLine, (object)DateTime.Now.ToString("G"), (object)texto);
                this.tb_output.Text += string.Format("{1} => {2}{0}", (object)Environment.NewLine, (object)DateTime.Now.ToString("G"), (object)"Audio Generado");
                this.create++;
            }
            catch (ArgumentException ex)
            {
                this.tb_output.Text += string.Format("{1} => {2}{0}", (object)Environment.NewLine, (object)DateTime.Now.ToString("G"), (object)ex.Message.ToString());
            }
            catch (Exception ex)
            {
                this.tb_output.Text += string.Format("{1} => {2}{0}", (object)Environment.NewLine, (object)DateTime.Now.ToString("G"), (object)ex.Message.ToString());
            }
            finally
            {
                this.tb_output.SelectionStart = this.tb_output.TextLength;
                this.tb_output.ScrollToCaret();
            }
            
        }

        private static void synth_SpeakCompleted(object sender, SpeakCompletedEventArgs e) => new SoundPlayer("Sample.wav").Play();

        private void bloquearControles(bool estado)
        {
            this.btn_buscar.Enabled = estado;
            this.btn_cargarXML.Enabled = estado;
            this.btn_clear.Enabled = estado;
            this.btn_seleccionarSalida.Enabled = estado;
            this.tb_url.Enabled = estado;
            // this.tb_salida.Enabled = estado;
        }

        private void btn_cargarXML_Click(object sender, EventArgs e)
        {
            this.tb_output.Text = "";

            if (!this.cargarXmlCheckBox.Checked)
            {
                this.inPutOutOutText_tabControl.SelectedTab = this.tabPage_output;
                TextBox tbOutput1 = this.tb_output;
                string text1 = tbOutput1.Text;
                string newLine1 = Environment.NewLine;
                DateTime now = DateTime.Now;
                string str1 = now.ToString("G");
                string str2 = string.Format("{1} => {2}{0}", (object)newLine1, (object)str1, (object)"Proceso Iniciado");
                tbOutput1.Text = text1 + str2;
                this.leerLineasTextBox();
                TextBox tbOutput2 = this.tb_output;
                string text2 = tbOutput2.Text;
                string newLine2 = Environment.NewLine;
                now = DateTime.Now;
                string str3 = now.ToString("G");
                string str4 = string.Format("{1} => {2}{0}", (object)newLine2, (object)str3, (object)"Proceso finalizado");
                tbOutput2.Text = text2 + str4;
            }
            else
            {
                this.inPutOutOutText_tabControl.SelectedTab = this.tabPage_output;
                if (this.tb_salida.Text.Equals(""))
                    this.tb_salida.Text = "C:\\";

                XmlTextReader xmlTextReader = null, xtr = null;


                try
                {
                    this.bloquearControles(false);
                    this.tb_output.Text += string.Format("{1} => {2}{0}", (object)Environment.NewLine, (object)DateTime.Now.ToString("G"), (object)"Proceso Iniciado");

                    xmlTextReader = new XmlTextReader(this.tb_url.Text);
                    xtr = new XmlTextReader(this.tb_url.Text);
                    string str = "", nombre = "", texto = "";
                    count = 0;

                    while (xtr.Read())
                    {
                        if (xtr.NodeType == XmlNodeType.Element &&
                            xtr.Name.Equals("audios"))
                            count++;
                    }

                    this.create = 0;

                    while (xmlTextReader.Read())
                    {
                        if (xmlTextReader.NodeType == XmlNodeType.Element)
                            str = xmlTextReader.Name;
                        else if (xmlTextReader.NodeType == XmlNodeType.Text)
                        {
                            if (str.Equals("nombreAudio"))
                                nombre = xmlTextReader.ReadContentAsString();
                            if (str.Equals("textoAudio"))
                                texto = xmlTextReader.ReadContentAsString();
                            if (!nombre.Equals("") && !texto.Equals(""))
                            {
                                nombre.Replace('"', ' ');
                                texto.Replace('"', ' ');
                                this.crearAudio(nombre, texto);
                                nombre = "";
                                texto = "";
                            }
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    this.tb_output.Text += string.Format("{1} => {2}{0}", (object)Environment.NewLine, (object)DateTime.Now.ToString("G"), (object)ex.Message.ToString());
                }
                catch (Exception ex)
                {
                    this.tb_output.Text += string.Format("{1} => {2}{0}", (object)Environment.NewLine, (object)DateTime.Now.ToString("G"), (object)ex.Message.ToString());
                }
                finally
                {
                    this.tb_output.Text += string.Format("{1} => {2}{0}", (object)Environment.NewLine, (object)DateTime.Now.ToString("G"), (object)"Proceso finalizado");
                    this.tb_output.SelectionStart = this.tb_output.TextLength;
                    this.tb_output.ScrollToCaret();
                    this.bloquearControles(true);
                    MessageBox.Show(this.create + "/" + count + " Audios generados", "Proceso Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (xmlTextReader != null)
                    {
                        xmlTextReader.Close();
                    }
                    if (xtr != null)
                    {
                        xtr.Close();
                    }
                }
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = " Archivos xml(*.xml)|*.xml";
            openFileDialog.Title = "Archivos xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.tb_url.Text = openFileDialog.FileName;
            openFileDialog.Dispose();
        }

        private void btn_clear_Click(object sender, EventArgs e) => this.tb_output.Text = "";

        private void btn_seleccionarSalida_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;
            this.tb_salida.Text = folderBrowserDialog.SelectedPath;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) => this.voicesSelected = this.vozSelectCB.Text.ToString();

        private void cargarXmlCheckBox_CheckedChanged(object sender, EventArgs e) => this.cargarXmlEnabledDisabled();

        private void cargarXmlEnabledDisabled()
        {
            if (this.cargarXmlCheckBox.Checked)
            {
                this.tb_url.Enabled = true;
                this.tb_url.Focus();
                this.btn_buscar.Enabled = true;
                this.tb_input.ReadOnly = true;
            }
            else
            {
                this.tb_url.Enabled = false;
                this.btn_buscar.Enabled = false;
                this.tb_input.ReadOnly = false;
            }
        }

        public void leerLineasTextBox()
        {
            bool flag = true;
            int num = 0;
            string nombre = "";
            string texto = "";
            try
            {
                if (this.tb_input.Text == "")
                    throw new Exception("El texto no tiene la estructura requerida para generar el audio");
                foreach (string line in this.tb_input.Lines)
                {
                    string str = "";
                    if (!line.Contains("//") && line != "")
                    {
                        if (flag)
                        {
                            nombre = line.Contains(".wav") ? line : throw new Exception("El formato del audio definido en el titulo no es válido (verifique que sea .wav en minúscula)");
                            flag = false;
                        }
                        else
                        {
                            texto = line.ToLower();
                            flag = true;
                        }
                        ++num;
                        if (num == 2)
                        {
                            num = 0;
                            if (nombre.Equals(""))
                                throw new Exception("Audio '" + str + "'descartado");
                            this.crearAudio(nombre, texto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.tb_output.Text += string.Format("{1} => {2}{0}", (object)Environment.NewLine, (object)DateTime.Now.ToString("G"), (object)ex.Message);
            }
        }

        private void tb_cargado_TextChanged(object sender, EventArgs e)
        {
        }

        private void asercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.MdiParent = this.MdiParent;
            aboutBox.Show();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MainForm));
            this.btn_cargarXML = new Button();
            this.tb_url = new TextBox();
            this.label1 = new Label();
            this.btn_buscar = new Button();
            this.btn_clear = new Button();
            this.label2 = new Label();
            this.tb_salida = new TextBox();
            this.btn_seleccionarSalida = new Button();
            this.vozSelectCB = new ComboBox();
            this.label3 = new Label();
            this.cargarXmlCheckBox = new CheckBox();
            this.inPutOutOutText_tabControl = new TabControl();
            this.tabPage_input = new TabPage();
            this.tabPage_output = new TabPage();
            this.tb_output = new TextBox();
            this.tb_input = new TextBox();
            this.menuStrip1 = new MenuStrip();
            this.archivoToolStripMenuItem = new ToolStripMenuItem();
            this.asercaDeToolStripMenuItem = new ToolStripMenuItem();
            this.inPutOutOutText_tabControl.SuspendLayout();
            this.tabPage_input.SuspendLayout();
            this.tabPage_output.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            this.btn_cargarXML.Location = new Point(475, 163);
            this.btn_cargarXML.Margin = new Padding(4);
            this.btn_cargarXML.Name = "btn_cargarXML";
            this.btn_cargarXML.Size = new Size(97, 28);
            this.btn_cargarXML.TabIndex = 5;
            this.btn_cargarXML.Text = "Generar";
            this.btn_cargarXML.UseVisualStyleBackColor = true;
            this.btn_cargarXML.Click += new EventHandler(this.btn_cargarXML_Click);
            this.tb_url.Location = new Point(121, 62);
            this.tb_url.Margin = new Padding(4);
            this.tb_url.Name = "tb_url";
            this.tb_url.Size = new Size(452, 22);
            this.tb_url.TabIndex = 0;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(13, 66);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(102, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ubicación XML";
            this.btn_buscar.Location = new Point(584, 60);
            this.btn_buscar.Margin = new Padding(4);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new Size(100, 28);
            this.btn_buscar.TabIndex = 1;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new EventHandler(this.btn_buscar_Click);
            this.btn_clear.Location = new Point(584, 164);
            this.btn_clear.Margin = new Padding(4);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new Size(100, 28);
            this.btn_clear.TabIndex = 6;
            this.btn_clear.Text = "Limpiar";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new EventHandler(this.btn_clear_Click);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(13, 115);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(47, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Salida";
            this.tb_salida.Location = new Point(121, 112);
            this.tb_salida.Margin = new Padding(4);
            this.tb_salida.Name = "tb_salida";
            this.tb_salida.Size = new Size(452, 22);
            this.tb_salida.TabIndex = 2;
            this.btn_seleccionarSalida.Location = new Point(584, 109);
            this.btn_seleccionarSalida.Margin = new Padding(4);
            this.btn_seleccionarSalida.Name = "btn_seleccionarSalida";
            this.btn_seleccionarSalida.Size = new Size(100, 28);
            this.btn_seleccionarSalida.TabIndex = 3;
            this.btn_seleccionarSalida.Text = "Seleccionar";
            this.btn_seleccionarSalida.UseVisualStyleBackColor = true;
            this.btn_seleccionarSalida.Click += new EventHandler(this.btn_seleccionarSalida_Click);
            this.vozSelectCB.FormattingEnabled = true;
            this.vozSelectCB.IntegralHeight = false;
            this.vozSelectCB.Location = new Point(121, 163);
            this.vozSelectCB.Name = "vozSelectCB";
            this.vozSelectCB.Size = new Size(226, 24);
            this.vozSelectCB.TabIndex = 4;
            this.vozSelectCB.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(13, 170);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(75, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Voz Select";
            this.cargarXmlCheckBox.AutoSize = true;
            this.cargarXmlCheckBox.Location = new Point(16, 35);
            this.cargarXmlCheckBox.Name = "cargarXmlCheckBox";
            this.cargarXmlCheckBox.Size = new Size(105, 21);
            this.cargarXmlCheckBox.TabIndex = 8;
            this.cargarXmlCheckBox.Text = "Cargar XML";
            this.cargarXmlCheckBox.UseVisualStyleBackColor = true;
            this.cargarXmlCheckBox.CheckedChanged += new EventHandler(this.cargarXmlCheckBox_CheckedChanged);
            this.inPutOutOutText_tabControl.Controls.Add((Control)this.tabPage_input);
            this.inPutOutOutText_tabControl.Controls.Add((Control)this.tabPage_output);
            this.inPutOutOutText_tabControl.Location = new Point(16, 210);
            this.inPutOutOutText_tabControl.Name = "inPutOutOutText_tabControl";
            this.inPutOutOutText_tabControl.SelectedIndex = 0;
            this.inPutOutOutText_tabControl.Size = new Size(668, 267);
            this.inPutOutOutText_tabControl.TabIndex = 9;
            this.tabPage_input.Controls.Add((Control)this.tb_input);
            this.tabPage_input.Location = new Point(4, 25);
            this.tabPage_input.Name = "tabPage_input";
            this.tabPage_input.Padding = new Padding(3);
            this.tabPage_input.Size = new Size(660, 238);
            this.tabPage_input.TabIndex = 0;
            this.tabPage_input.Text = "Input";
            this.tabPage_input.UseVisualStyleBackColor = true;
            this.tabPage_output.Controls.Add((Control)this.tb_output);
            this.tabPage_output.Location = new Point(4, 25);
            this.tabPage_output.Name = "tabPage_output";
            this.tabPage_output.Padding = new Padding(3);
            this.tabPage_output.Size = new Size(660, 238);
            this.tabPage_output.TabIndex = 1;
            this.tabPage_output.Text = "Output";
            this.tabPage_output.UseVisualStyleBackColor = true;
            this.tb_output.Location = new Point(7, 7);
            this.tb_output.Margin = new Padding(4);
            this.tb_output.Multiline = true;
            this.tb_output.Name = "tb_output";
            this.tb_output.ReadOnly = true;
            this.tb_output.Size = new Size(646, 224);
            this.tb_output.TabIndex = 8;
            this.tb_input.Location = new Point(7, 7);
            this.tb_input.Margin = new Padding(4);
            this.tb_input.Multiline = true;
            this.tb_input.Name = "tb_input";
            this.tb_input.ReadOnly = true;
            this.tb_input.Size = new Size(646, 224);
            this.tb_input.TabIndex = 9;
            this.menuStrip1.ImageScalingSize = new Size(20, 20);
            this.menuStrip1.Items.AddRange(new ToolStripItem[2]
            {
        (ToolStripItem) this.archivoToolStripMenuItem,
        (ToolStripItem) this.asercaDeToolStripMenuItem
            });
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(703, 28);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new Size(71, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            this.asercaDeToolStripMenuItem.Name = "asercaDeToolStripMenuItem";
            this.asercaDeToolStripMenuItem.Size = new Size(91, 24);
            this.asercaDeToolStripMenuItem.Text = "Acerca de ";
            this.asercaDeToolStripMenuItem.Click += new EventHandler(this.asercaDeToolStripMenuItem_Click);
            this.AutoScaleDimensions = new SizeF(8f, 16f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(703, 489);
            this.Controls.Add((Control)this.inPutOutOutText_tabControl);
            this.Controls.Add((Control)this.cargarXmlCheckBox);
            this.Controls.Add((Control)this.label3);
            this.Controls.Add((Control)this.vozSelectCB);
            this.Controls.Add((Control)this.btn_seleccionarSalida);
            this.Controls.Add((Control)this.tb_salida);
            this.Controls.Add((Control)this.label2);
            this.Controls.Add((Control)this.btn_clear);
            this.Controls.Add((Control)this.btn_buscar);
            this.Controls.Add((Control)this.label1);
            this.Controls.Add((Control)this.tb_url);
            this.Controls.Add((Control)this.btn_cargarXML);
            this.Controls.Add((Control)this.menuStrip1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(MainForm);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "  Audio Generator";
            this.Load += new EventHandler(this.Form1_Load);
            this.inPutOutOutText_tabControl.ResumeLayout(false);
            this.tabPage_input.ResumeLayout(false);
            this.tabPage_input.PerformLayout();
            this.tabPage_output.ResumeLayout(false);
            this.tabPage_output.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
