using FolderSelect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicTool
{
  public partial class MainForm : Form
  {
    private string mode = "directories"; 
    private FolderSelectDialog fsDlg = null;
    private Dictionary<string, MusicFileInfo> infosLeft = null;
    private Dictionary<string, MusicFileInfo> infosRight = null;
    private Dictionary<string, ComparisonInfo> cpInfos = null;
    public MainForm()
    {
      InitializeComponent();
      comboBox1.SelectedItem = "APO Lenovo Note 3";
      if(!string.IsNullOrEmpty(txt_folderLeft.Text)) {
        ReadFiles(txt_folderLeft.Text, "left");
      }
      if(!string.IsNullOrEmpty(txt_folderRight.Text)) {
        ReadFiles(txt_folderRight.Text, "right");
      }
      if(!string.IsNullOrEmpty(txt_playlistFile.Text)) {
        readPlaylist(txt_playlistFile.Text);
      }
    }

    private void btt_choseDirLeft_Click(object sender, EventArgs e)
    {
      string folderName = txt_folderLeft.Text;
      fsDlg = new FolderSelectDialog();
      if(!string.IsNullOrEmpty(folderName)) {
        fsDlg.InitialDirectory = folderName;
      }
      fsDlg.Title = "Bitte einen Basispfad zu Musikdaten auswählen";
      if(fsDlg.ShowDialog(IntPtr.Zero)) {
        folderName = fsDlg.FileName;
        if(!folderName.EndsWith("\\")) {
          folderName += "\\";
        }
        txt_folderLeft.Text = folderName;
        ReadFiles(folderName, "left");
        mode = "directories";
      }
    }

    private void btt_choseDirRight_Click(object sender, EventArgs e)
    {
      string folderName = txt_folderLeft.Text;
      fsDlg = new FolderSelectDialog();
      if(!string.IsNullOrEmpty(folderName)) {
        fsDlg.InitialDirectory = folderName;
      }
      fsDlg.Title = "Bitte einen Basispfad zu Musikdaten auswählen";
      if(fsDlg.ShowDialog(IntPtr.Zero)) {
        folderName = fsDlg.FileName;
        if(!folderName.EndsWith("\\")) {
          folderName += "\\";
        }
        txt_folderRight.Text = folderName;
        txt_playlistFile.Text = "";
        ReadFiles(folderName, "right");
        mode = "directories";
      }
    }
    private void ReadFiles(string path, string target)
    {
      List<string> files = new List<string>();
      foreach(string file in Directory.EnumerateFiles(
        path, "*.*", SearchOption.AllDirectories)) {
        if(IsMusicFile(file)) {
          files.Add(file);
        }
      }
      ReadFiles(path, files, target);
    }

    private void ReadFiles(string basePath, List<string> files, string target)
    {
      Dictionary<string, MusicFileInfo> infos = null;
      MusicFileInfo mfi = null;
      string key = null;
      string duplicateFile = null;
      if(string.IsNullOrEmpty(basePath)) {
        basePath = Helper.getCommonPrefix(files);
      }
      if(basePath.EndsWith("\\")) {
        basePath = basePath.Substring(0, basePath.Length - 1);
      }
      if(target == "left") {
        infosLeft = new Dictionary<string,MusicFileInfo>();
        infos = infosLeft;
      } else {
        infosRight = new Dictionary<string, MusicFileInfo>();
        infos = infosRight;
      }
      foreach(string file in files) {
        duplicateFile = null;
        if(IsMusicFile(file)) {
          mfi = new MusicFileInfo(basePath, file, true);
          key = mfi.Key;
          if(infos.ContainsKey(key)) {
            duplicateFile = infos[key].CompletePath;
            while(infos.ContainsKey(key)) {
              key = mfi.ModifyKey();
            }
            mfi.DuplicateFile = duplicateFile;
          }
          infos.Add(key, mfi);
        }
      }
    }

    private bool IsMusicFile(string path)
    {
      bool isMusic = false;
      string ext = Path.GetExtension(path);
      if(! string.IsNullOrEmpty(ext)) {
        ext = ext.ToLower();
        if(ext.StartsWith(".")) {
          ext = ext.Substring(1);
        }
        isMusic = (ext == "mp3" || ext == "flac" || ext == "ogg"  || ext == "m4a" || ext == "mp4" || ext == "mpc" || ext == "wav"
          || ext == "alac");
      }
      return isMusic;
    }

    private void compareLists(Dictionary<string, MusicFileInfo> info1, Dictionary<string, MusicFileInfo> info2,
      string typeLeft, string typeRight)
    {
      MusicFileInfo fi1 = null;
      MusicFileInfo fi2 = null;
      StringBuilder text = null;
      ComparisonInfo cp = null;
      ComparisonInfo cpt = null;
      string[] pathSubstitutions = null;
      if(txt_pathSubst.Text.Trim().Length > 0) {
        pathSubstitutions = txt_pathSubst.Text.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);
      }
      Dictionary<string, object[]> results = null;
      object[] result = null;
      List<string> foundRight = new List<string>();
      cpInfos = new Dictionary<string, ComparisonInfo>();
      
      bool found = false;
      int minBitrate = 0;
      if(! string.IsNullOrEmpty(txt_minBitrate.Text)) {
        minBitrate = Convert.ToInt32(txt_minBitrate.Text);
      }
      if(info1 != null && info1.Count > 0 && info2 != null && info2.Count > 0) {

        // Links-rechts Vergleich
        foreach(KeyValuePair<string, MusicFileInfo> kvp in info1) {
          found = false;
          fi1 = kvp.Value;
          if(info2.ContainsKey(fi1.Key)) {
            fi2 = info2[fi1.Key];
            cp = new ComparisonInfo(fi1, fi2, minBitrate);
            cpInfos.Add(fi1.Key, cp);
            foundRight.Add(fi1.Key);
            found = true;
          } else {
            cp = null;
            foreach(MusicFileInfo comparer in info2.Values) {
              cpt = new ComparisonInfo(fi1, comparer, minBitrate);
              if(cpt.Equality >= 50) {
                if(cp == null || cp.Equality < cpt.Equality) {
                  cp = cpt;
                }
              }
            }
            if(cp != null && cp.Equality >= 50) {
              cpInfos.Add(fi1.Key, cp);
              foundRight.Add(kvp.Key);
              found = true;
            }
          }
          if(!found) {
            cp = new ComparisonInfo(fi1, null, minBitrate);
            cpInfos.Add(kvp.Key, cp);
          }
        }

        // Rechts-Links Vergleich fuer noch nicht gefundene Matches
        if(foundRight.Count < info1.Count && typeLeft == "directory") {
          foreach(KeyValuePair<string, MusicFileInfo> kvp in info2) {
            fi2 = kvp.Value;
            found = false;
            if(!foundRight.Contains(fi2.Key)) {
              cp = null;
              foreach(MusicFileInfo comparer in info1.Values) {
                cpt = new ComparisonInfo(fi2, comparer, minBitrate);
                if(cpt.Equality >= 50) {
                  if(cp == null || cp.Equality < cpt.Equality) {
                    cp = cpt;
                  }
                }
              }
              if(cp != null && cp.Equality >= 50) {
                cpInfos.Add(fi2.Key, cp);
                foundRight.Add(kvp.Key);
                found = true;
              }
              if(!found) {
                cp = new ComparisonInfo(null, fi2, minBitrate);
                cpInfos.Add(fi2.Key, cp);
              }
            }
          }
        }
      }
      if(typeLeft == "playlist") {
        results = new Dictionary<string, object[]>();
        foreach(KeyValuePair <string, ComparisonInfo> kvp in cpInfos) {
          fi1 = kvp.Value.FileLeft;
          fi2 = kvp.Value.FileRight;
          if(fi1 != null) {
            result = new object[15];
            result[0] = (object)false;
            result[1] = (object)(fi1 == null ? "not found" : (string.IsNullOrEmpty(fi1.Artist) ? "" : fi1.Artist));
            result[2] = (object)(fi1 == null ? "not found" : (string.IsNullOrEmpty(fi1.Title) ? "" : fi1.Title));
            result[3] = (object)(fi1 == null ? "not found" : (string.IsNullOrEmpty(fi1.Path) ? "" : fi1.Path));
            result[4] = (object)(fi1 == null ? "not found" : (string.IsNullOrEmpty(fi1.Extension) ? "" : fi1.Extension));
            result[5] = (object)(fi1 == null ? 0 : fi1.Length);
            result[6] = (object)(fi1 == null ? 0 : fi1.Bitrate);
            result[7] = (object)("" + kvp.Value.Equality);
            result[8] = (object)kvp.Value.ShouldBeTranscoded;
            result[9] = (object)(fi2 == null ? "not found" : (string.IsNullOrEmpty(fi2.Artist) ? "" : fi2.Artist));
            result[10] = (object)(fi2 == null ? "not found" : (string.IsNullOrEmpty(fi2.Title) ? "" : fi2.Title));
            result[11] = (object)(fi2 == null ? "not found" : (string.IsNullOrEmpty(fi2.Path) ? "" : fi2.Path));
            result[12] = (object)(fi2 == null ? "not found" : (string.IsNullOrEmpty(fi2.Extension) ? "" : fi2.Extension));
            result[13] = (object)(fi2 == null ? 0 : fi2.Length);
            result[14] = (object)(fi2 == null ? 0 : fi2.Bitrate);
            results.Add(kvp.Key, result);
          }
        }
        bool first = true;
        txt_playlistOutput.Text = "";
        text = new StringBuilder();
        foreach(KeyValuePair<string, ComparisonInfo> kvp in cpInfos.Where(x => x.Value.FileRight != null)) {
          if(first) {
            first = false;
          } else {
            text.Append(System.Environment.NewLine);
          }
          string completePath = kvp.Value.FileRight.CompletePath;
          if(pathSubstitutions != null && pathSubstitutions.Length > 0) {
            for(int i = 0; i < pathSubstitutions.Length; i = i + 2) {
              completePath = Regex.Replace(completePath, @pathSubstitutions[i], @pathSubstitutions[i + 1], RegexOptions.IgnoreCase);
              //completePath = Regex.Replace(completePath, @".*handy\\", "../", RegexOptions.IgnoreCase);
            }
          }
          if(! string.IsNullOrEmpty(txt_delimiter.Text)) {
            completePath = completePath.Replace("\\", txt_delimiter.Text);
          }
          text.Append(completePath);
        }
        txt_playlistOutput.Text = text.ToString();
      } else if(typeLeft == "directories" && typeRight == "directories") {
        results = new Dictionary<string, object[]>();
        foreach(KeyValuePair <string, ComparisonInfo> kvp in cpInfos) {
          result = new object[15];
          fi1 = kvp.Value.FileLeft;
          fi2 = kvp.Value.FileRight;
          result[0] = (object)false;
          result[1] = (object)(fi1 == null ? "not found" : (string.IsNullOrEmpty(fi1.Artist) ? "" : fi1.Artist));
          result[2] = (object)(fi1 == null ? "not found" : (string.IsNullOrEmpty(fi1.Title) ? "" : fi1.Title));
          result[3] = (object)(fi1 == null ? "not found" : (string.IsNullOrEmpty(fi1.Path) ? "" : fi1.Path));
          result[4] = (object)(fi1 == null ? "not found" : (string.IsNullOrEmpty(fi1.Extension) ? "" : fi1.Extension));
          result[5] = (object)(fi1 == null ? 0 : fi1.Length);
          result[6] = (object)(fi1 == null ? 0 : fi1.Bitrate);
          result[7] = (object)("" + kvp.Value.Equality);
          result[8] = (object)kvp.Value.ShouldBeTranscoded;
          result[9] = (object)(fi2 == null ? "not found" : (string.IsNullOrEmpty(fi2.Artist) ? "" : fi2.Artist));
          result[10] = (object)(fi2 == null ? "not found" : (string.IsNullOrEmpty(fi2.Title) ? "" : fi2.Title));
          result[11] = (object)(fi2 == null ? "not found" : (string.IsNullOrEmpty(fi2.Path) ? "" : fi2.Path));
          result[12] = (object)(fi2 == null ? "not found" : (string.IsNullOrEmpty(fi2.Extension) ? "" : fi2.Extension));
          result[13] = (object)(fi2 == null ? 0 : fi2.Length);
          result[14] = (object)(fi2 == null ? 0 : fi2.Bitrate);
          results.Add(kvp.Key, result);
        }
      }
      DataGridViewRow dgvr = null;
      dgv_directories.SuspendLayout();
      dgv_directories.Rows.Clear();
      if(results != null && results.Count > 0) {
        foreach(KeyValuePair <string, object[]> kvp in results) {
          dgvr = (DataGridViewRow)dgv_directories.RowTemplate.Clone();
          dgvr.CreateCells(dgv_directories, kvp.Value);
          dgvr.Tag = cpInfos[kvp.Key];
          dgv_directories.Rows.Add(dgvr);
        }
      }
      dgv_directories.ResumeLayout();
      dgv_directories.PerformLayout();
    }

    private void btt_compare_Click(object sender, EventArgs e)
    {
      if(mode == "directories") {
        txt_playlistOutput.Text = "";
        compareLists(infosLeft, infosRight, "directories", "directories");
      }
    }

    private void btt_openPlaylist_Click(object sender, EventArgs e)
    {
      string filename = txt_playlistFile.Text;
      openFileDialog1 = new OpenFileDialog();
      if(!string.IsNullOrEmpty(filename)) {
        openFileDialog1.InitialDirectory = Path.GetDirectoryName(filename);
        openFileDialog1.FileName = filename;
      }
      openFileDialog1.Filter = "m3u files (*.m3u)|*.m3u|m3u8 files (*.m3u8)|*.m3u8|All files (*.*)|*.*";
      openFileDialog1.FilterIndex = 2;
      openFileDialog1.RestoreDirectory = true;
      if(openFileDialog1.ShowDialog() == DialogResult.OK) {
        txt_playlistFile.Text = openFileDialog1.FileName;
        readPlaylist(txt_playlistFile.Text);
      }
    }

    private void readPlaylist(string filename)
    {
      List<string> files = File.ReadLines(filename).ToList().Where(x => !x.StartsWith("#")).ToList();
      if(files != null && files.Count > 0) {
        ReadFiles(null, files, "right");
        mode = "playlist";
        txt_folderRight.Text = "";
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if(mode == "playlist") {
        compareLists(infosRight, infosLeft, "playlist", "directories");
      }
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      switch(comboBox1.SelectedItem.ToString()) {
        case "APO Sansa Rockbox":
          txt_pathSubst.Text = @".*player\\Heavy & Rock\\"
            + System.Environment.NewLine + "/MUSICA/Heavy & Rock/"
            + System.Environment.NewLine + @".*player\\"
            + System.Environment.NewLine + "/<microSD1>/";
          txt_delimiter.Text = "/";
          break;
        case "APO Lenovo Note 3":
          txt_pathSubst.Text = ".*handy\\\\"
            + System.Environment.NewLine + "../";
          txt_delimiter.Text = "/";
          break;
      }
    }

    private void copyFileList(string art)
    {
      ComparisonInfo ci = null;
      List<string> files = new List<string>();
      List<string> deleteFiles = new List<string>();
      foreach(DataGridViewRow dgvr in dgv_directories.Rows) {
        ci = (ComparisonInfo)dgvr.Tag;
        if(art == "notright" && ci.FileRight == null && ci.FileLeft != null) {
          files.Add(ci.FileLeft.CompletePath);
        } else if(art == "notleft" && ci.FileLeft == null && ci.FileRight != null) {
          files.Add(ci.FileRight.CompletePath);
        } else if(art == "encoderight" && ci.FileLeft != null && ci.ShouldBeTranscoded == "right") {
          files.Add(ci.FileLeft.CompletePath);
          if(ci.FileRight != null) {
            deleteFiles.Add(ci.FileRight.CompletePath);
          }
        }
      }
      if(files.Count > 0) {
        if(deleteFiles.Count > 0) {
          files.Add("---------------- Löschen ----------------");
          files.AddRange(deleteFiles);
        }
        Clipboard.SetText(string.Join(Environment.NewLine, files.Cast<object>().Select(o => o.ToString()).ToArray()));
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      copyFileList("notright");
    }

    private void button3_Click(object sender, EventArgs e)
    {
      copyFileList("notleft");
    }

    private void button4_Click(object sender, EventArgs e)
    {
      copyFileList("encoderight");
    }

  }
}
