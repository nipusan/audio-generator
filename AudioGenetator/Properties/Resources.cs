// Decompiled with JetBrains decompiler
// Type: AudioGenetator.Properties.Resources
// Assembly: AudioGenetator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=beaa9c357ca987d8
// MVID: 47AA44B6-B43A-45ED-BE9C-D6D0B391B2BF
// Assembly location: C:\Users\user\AppData\Local\Apps\2.0\2D48149K.0WA\KDWBYXGE.CGT\audi..tion_f923b6c0b495be75_0001.0000_aa06e220d98a2a45\AudioGenetator.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace AudioGenetator.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (AudioGenetator.Properties.Resources.resourceMan == null)
          AudioGenetator.Properties.Resources.resourceMan = new ResourceManager("AudioGenetator.Properties.Resources", typeof (AudioGenetator.Properties.Resources).Assembly);
        return AudioGenetator.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => AudioGenetator.Properties.Resources.resourceCulture;
      set => AudioGenetator.Properties.Resources.resourceCulture = value;
    }

    internal static Bitmap Logo_Np => (Bitmap) AudioGenetator.Properties.Resources.ResourceManager.GetObject("logo-np", AudioGenetator.Properties.Resources.resourceCulture);
  }
}
