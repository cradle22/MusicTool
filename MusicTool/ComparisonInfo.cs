using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTool
{
  class ComparisonInfo
  {
    private MusicFileInfo f1 = null;
    public MusicFileInfo FileLeft { get { return f1; } set { f1 = value; } }
    private MusicFileInfo f2 = null;
    public MusicFileInfo FileRight { get { return f2; } set { f2 = value; } }
    private readonly int equality = 0;
    public int Equality { get { return equality; } }
    private string newer = "left";
    public string Newer { get { return newer; } }
    private string longer = "left";
    public string Longer { get { return longer; } }
    private string quality = "left";
    public string Quality { get { return quality; } }
    private string shouldBeTranscoded = "none";
    public string ShouldBeTranscoded { get { return shouldBeTranscoded; } }
    public ComparisonInfo(MusicFileInfo fileLeft, MusicFileInfo fileRight, int minBitrate)
    {
      this.f1 = fileLeft;
      this.f2 = fileRight;
      if(f1 != null && f2 != null) {
        if(f1.Modified > f2.Modified) {
          newer = "left";
        } else if(f1.Modified == f2.Modified) {
          newer = "same";
        } else {
          newer = "rigth";
        }
        if(f1.Length > f2.Length) {
          longer = "left";
        } else if(f1.Length == f2.Length) {
          longer = "same";
        } else {
          longer = "right";
        }
        if((f1.Lossless && f2.Lossless)) {
          quality = "lossless";
        } else if(f1.Lossless && ! f2.Lossless) {
          quality = "left";
        } else if(! f1.Lossless && f2.Lossless) {
          quality = "right";
        } else if(f1.Extension.Equals(f2.Extension, StringComparison.InvariantCultureIgnoreCase)
          && f1.Length == f2.Length) {
          quality = "same";
        } else if(f1.Length >= f2.Length) {
          quality = "left";
        } else {
          quality = "right";
        }
        if(minBitrate > 0) {
          if(f1.Lossless && !f2.Lossless && f2.Bitrate > 0 && f2.Bitrate < minBitrate) {
            shouldBeTranscoded = "right";
          } else if(!f1.Lossless && f2.Lossless && f1.Bitrate > 0 && f1.Bitrate < minBitrate) {
            shouldBeTranscoded = "left";
          }
        }
        if(f1.FileName.ToLower() == f2.FileName.ToLower() && f1.Extension.ToLower() == f2.Extension.ToLower() &&
          f1.Length == f2.Length) {
          equality = 100;
        } else {
          if(! string.IsNullOrEmpty(f1.Artist) && ! string.IsNullOrEmpty(f2.Artist) &&
            ! string.IsNullOrEmpty(f1.Title) && ! string.IsNullOrEmpty(f2.Title) &&
            f1.Artist.Equals(f2.Artist, StringComparison.InvariantCultureIgnoreCase) &&
            f1.Title.Equals(f2.Title, StringComparison.InvariantCultureIgnoreCase)) {
            equality = 85;
            if(f1.Extension.Equals(f2.Extension, StringComparison.InvariantCultureIgnoreCase)) {
              equality += 5;
            }
            if(f1.TagsRead && f2.TagsRead && !f1.TagsGuessed && !f2.TagsGuessed) {
              equality += 5;
            }
          } else if(! string.IsNullOrEmpty(f1.Title) && ! string.IsNullOrEmpty(f2.Title) &&
            f1.Title.Equals(f2.Title, StringComparison.InvariantCultureIgnoreCase)) {
            equality = 50;
            if(f1.Extension.Equals(f2.Extension, StringComparison.InvariantCultureIgnoreCase)) {
              equality += 5;
            }
            if(f1.TagsRead && f2.TagsRead && !f1.TagsGuessed && !f2.TagsGuessed) {
              equality += 5;
            }
          }
        }
      }
    }
  }
}
