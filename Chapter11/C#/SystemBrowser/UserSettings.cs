using System;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace SystemBrowser
{
	/// <summary>
	/// This class holds the user's settings, and supports
	/// persistence of the settings, saving them in an XML file
	/// </summary>
  public class UserSettings
  {
    private string persistentFilePath;

    private bool showFoldersNavigator; // ShowFolders if true, ShowSearch if false
    public bool ShowFoldersNavigator
    {
      get {return showFoldersNavigator;}
      set {showFoldersNavigator = value;}
    }

    public void ShowFolders()
    {
      ShowFoldersNavigator = true;
    }

    public void ShowSearch()
    {
      ShowFoldersNavigator = false;
    }

	  public UserSettings()
	  {
      persistentFilePath = string.Format(@"{0}\settings.xml", Application.StartupPath);

      // set default values for all settings (we only have one!)
      ShowFoldersNavigator = true;
	  }

    public void Save()
    {
      try
      {
        StreamWriter writer = new StreamWriter(persistentFilePath);
        writer.WriteLine("<?xml version='1.0' encoding='UTF-8'?>");
        writer.WriteLine("<settings>");
        writer.WriteLine(string.Format("<ShowFolders>{0}</ShowFolders>", showFoldersNavigator));
        writer.WriteLine("</settings>");
        writer.Close();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString(), "Couldn't save settings");
      }
    }

    public void Load()
    {
      try
      {
        if (!File.Exists(persistentFilePath)) return;
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(persistentFilePath);
        XmlNode node = xmlDoc.SelectSingleNode("//ShowFolders");
        if (node == null) return;
        showFoldersNavigator = Boolean.Parse(node.InnerText.ToString());
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString(), "Couldn't load settings");
      }
    }
  }
}
