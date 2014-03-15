using System;
using System.IO;

namespace PlaylistCondenser {
  internal class PlaylistEntry {
    private string PlaylistFilename { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public long Size { get; set; }
    public bool IsValid { get; set; }

    public static PlaylistEntry FromM3uData( string playlistFilename, string title, string location ) {
      PlaylistEntry result = new PlaylistEntry() {
        Title = title,
        Location = location,
        PlaylistFilename = playlistFilename
      };

      return result;
    }

    public void Init() {
      Title = Title.Substring( Title.IndexOf( ',' ) + 1 );

      if( Location.StartsWith( @"\" ) ) {
        Location = Path.GetPathRoot( PlaylistFilename ) + Location.Substring( 1 );
      }

      try {
        if( File.Exists( Location ) ) {
          IsValid = true;
          FileInfo fileInfo = new FileInfo( Location );
          Size = fileInfo.Length;
        }
      } catch( ArgumentException ex ) {
        Title = "ArgumentException";
        IsValid = false;
      }
    }
  }
}