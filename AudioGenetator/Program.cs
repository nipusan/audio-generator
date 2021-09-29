// Decompiled with JetBrains decompiler
// Type: AudioGenetator.Program
// Assembly: AudioGenetator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=beaa9c357ca987d8
// MVID: 47AA44B6-B43A-45ED-BE9C-D6D0B391B2BF
// Assembly location: C:\Users\user\AppData\Local\Apps\2.0\2D48149K.0WA\KDWBYXGE.CGT\audi..tion_f923b6c0b495be75_0001.0000_aa06e220d98a2a45\AudioGenetator.exe

using System;
using System.Windows.Forms;

namespace AudioGenetator
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new MainForm());
    }
  }
}
