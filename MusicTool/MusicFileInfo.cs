using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading.Tasks;

namespace MusicTool
{
  class MusicFileInfo
  {
    public static readonly string KeySplitter = "<<<###splitValue###>>>";
    private readonly string completePath = null;
    public string CompletePath { get { return completePath;  } }
    private readonly bool fileExists = false;
    public bool FileExists { get { return fileExists; } }
    private readonly string fileName = null;
    public string FileName { get { return fileName; } }
    private readonly string fileNameWithoutExtension = null;
    public string FileNameWithoutExtension { get { return fileNameWithoutExtension;} }
    private readonly string extension = null;
    public string Extension { get { return extension; } }
    private readonly string path = null;
    public string Path { get { return path; } }
    private readonly string relativePath = null;
    public string RelativPath { get { return relativePath; } }
    private readonly long length = 0;
    public long Length { get { return length; } }
    private readonly DateTime creationTime;
    public DateTime CreationTime { get { return creationTime; } }
    private readonly DateTime modified;
    public DateTime Modified { get { return modified; } }

    private string relatedFile = null;
    public string RelatedFile
    {
      get { return relatedFile; }
      set { relatedFile = value; }
    }
    private readonly bool lossless = false;
    public bool Lossless { get { return lossless; } }
    private string artist = null;
    public string Artist { get { return artist; } }
    private string title = null;
    public string Title { get { return title; } }
    private int bitrate = 0;
    public int Bitrate { get { return bitrate; } }

    private string key = null;
    public string Key { get { return key; } }
    private bool tagsRead = false;
    public bool TagsRead { get { return tagsRead; } }
    private bool tagsGuessed = false;
    public bool TagsGuessed { get { return tagsGuessed; } }

    private int keyExtension = 0;
    private string duplicateFile = null;
    public string DuplicateFile
    {
      get { return duplicateFile; }
      set { duplicateFile = value; }
    }

    public MusicFileInfo(string basePath, string fileName, bool readTags)
    {
      tagsRead = false;
      tagsGuessed = false;
      completePath = fileName;
      FileInfo fi = new FileInfo(completePath);
      fileExists = fi.Exists;
      this.fileName = fi.Name;
      fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(completePath);
      extension = fi.Extension;
      if(! string.IsNullOrEmpty(Extension) && Extension.StartsWith(".")) {
        extension = Extension.Substring(1);
        if(extension.Equals("flac", StringComparison.InvariantCultureIgnoreCase) ||
          extension.Equals("alac", StringComparison.InvariantCultureIgnoreCase) ||
          extension.Equals("wav", StringComparison.InvariantCultureIgnoreCase)) {
            lossless = true;
        }
      }
      path = fi.DirectoryName;
      if(!string.IsNullOrEmpty(path) && path.EndsWith("\\")) {
        path = path.Substring(0, path.Length - 1);
      }
      if(!string.IsNullOrEmpty(basePath)) {
        try {
          relativePath = Helper.GetRelativePath(basePath, path);
        } catch(Exception) {
          ;
        }
      }
      if(fi.Exists) {
        length = fi.Length;
        creationTime = fi.CreationTime;
        modified = fi.LastWriteTime;
      }
      if(readTags && fi.Exists) {
        ReadTags();
      } else {
        GuessTags(true, true);
      }
      BuildKey();
    }

    public void ReadTags()
    {
      if(FileExists) {
        try {
          TagLib.File tagFile = TagLib.File.Create(CompletePath);
          if(tagFile.Tag.AlbumArtists != null && tagFile.Tag.AlbumArtists.Length > 0 
            && ! string.IsNullOrEmpty(tagFile.Tag.AlbumArtists[0].Trim())) {
            artist = tagFile.Tag.AlbumArtists[0].Trim();
          } else if(tagFile.Tag.Performers != null && tagFile.Tag.Performers.Length > 0
            && ! string.IsNullOrEmpty(tagFile.Tag.Performers[0].Trim())) {
            artist = tagFile.Tag.Performers[0];
          }
          if(!string.IsNullOrEmpty(tagFile.Tag.Title)) {
            title = tagFile.Tag.Title;
          }
          if(tagFile.Properties != null) {
            bitrate = tagFile.Properties.AudioBitrate;
          }
          tagsRead = true;
        } catch(Exception) {

        }
      }
      if(string.IsNullOrEmpty(title) && string.IsNullOrEmpty(artist)) {
        GuessTags(true, true);
      }
    }

    public void GuessTags(bool getArtist, bool getTitle) {
      if(! String.IsNullOrEmpty(FileNameWithoutExtension)) {
        Match m = Regex.Match(FileNameWithoutExtension, @"(.*)\s*-\s*(.*)");
        if(m != null && m.Success && m.Groups.Count >= 2) {
          if(getArtist) {
            artist = m.Groups[1].Value;
            artist = Regex.Replace(artist, @"^\d+\s*", "", RegexOptions.Singleline);
            artist = Regex.Replace(artist, @"^\d+\.\s*", "", RegexOptions.Singleline);
            artist = Regex.Replace(artist, @"^\s*-\s*", "", RegexOptions.Singleline);
            artist = artist.Trim();
          }
          if(getTitle && m.Groups.Count >= 3) {
            title = m.Groups[2].Value.Trim();
          }
        }
      }
      tagsGuessed = true;
    }

    public string BuildKey()
    {
      StringBuilder key = new StringBuilder();
      if(!string.IsNullOrEmpty(Artist) && !string.IsNullOrEmpty(Title)) {
        key.Append(Artist.ToLower()).Append(KeySplitter).Append(Title.ToLower());
      } else {
        key.Append(FileNameWithoutExtension);
      }
      this.key = key.ToString();
      return this.key;
    }

    public string ModifyKey()
    {
      BuildKey();
      keyExtension++;
      key += KeySplitter + keyExtension;
      return key;
    }

    private string MakeRelative(string filePath, string referencePath)
    {
      var fileUri = new Uri(filePath);
      var referenceUri = new Uri(referencePath);
      return referenceUri.MakeRelativeUri(fileUri).ToString();
    }
  }
}
