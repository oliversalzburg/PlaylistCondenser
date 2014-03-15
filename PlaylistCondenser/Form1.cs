using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PlaylistCondenser {
  public partial class Form1 : Form {
    private List<PlaylistEntry> Playlist { get; set; }

    public Form1() {
      InitializeComponent();

      listView1.Sorting = SortOrder.None;

      playlistLoader.DoWork += playlistLoader_DoWork;
      playlistCondenser.DoWork += PlaylistCondenserOnDoWork;

      playlistLoader.ProgressChanged += ( sender, args ) => {
        UpdateInfoLabels();
        progressBar1.Value = args.ProgressPercentage;
      };
      playlistCondenser.ProgressChanged += ( sender, args ) => { progressBar1.Value = args.ProgressPercentage; };
    }

    private void UpdateInfoLabels() {
      FileCountLabel.Text = String.Format( "Files: {0}", Playlist.Count );
      FileSizeLabel.Text = String.Format( "Size: {0} MB", Playlist.Sum( ( entry ) => entry.Size ) / 1048576 );
    }

    private void Form1_DragDrop( object sender, DragEventArgs e ) {
      if( e.Data.GetDataPresent( DataFormats.FileDrop ) ) {
        string[] files = (string[])e.Data.GetData( DataFormats.FileDrop );
        foreach( string filePath in files ) {
          if( filePath.EndsWith( ".m3u" ) || filePath.EndsWith( ".m3u8" ) ) {
            playlistLoader.RunWorkerAsync( filePath );
          } else {
            //listView1.Items.Add( filePath );
          }
        }
      }
    }

    private void playlistLoader_DoWork( object sender, System.ComponentModel.DoWorkEventArgs e ) {
      string filePath = (string)e.Argument;
      Playlist = LoadPlaylist( filePath );
      for( int entryIndex = 0; entryIndex < Playlist.Count; entryIndex++ ) {
        PlaylistEntry entry = Playlist[ entryIndex ];
        entry.Init();

        ListViewItem listViewItem = new ListViewItem( (entryIndex + 1).ToString() );
        listViewItem.Tag = entry;
        listViewItem.SubItems.Add( entry.Title );
        listViewItem.SubItems.Add( entry.Location );
        listViewItem.SubItems.Add( Math.Round( entry.Size / 1048576.0,2 ).ToString() );
        if( !entry.IsValid ) {
          listViewItem.ForeColor = Color.Red;
        }
        playlistLoader.ReportProgress( (int)( (float)( entryIndex + 1 ) / Playlist.Count * 100 ) );
        if( playlistLoader.CancellationPending ) {
          break;
        }

        listView1.Invoke( new PlaylistUpdater( UpdatePlaylist ), new object[] {listViewItem} );
      }
      playlistLoader.ReportProgress( 100 );
    }

    private void PlaylistCondenserOnDoWork( object sender, DoWorkEventArgs doWorkEventArgs ) {
      string targetPath = TargetTextBox.Text;
      for( int entryIndex = 0; entryIndex < Playlist.Count; entryIndex++ ) {
        PlaylistEntry entry = Playlist[ entryIndex ];
        if( !entry.IsValid ) {
          continue;
        }

        string targetFilename = String.Format( "{0} - {1}.{2}", entryIndex, entry.Title, Path.GetExtension( entry.Location ) );
        targetFilename = Path.GetInvalidFileNameChars().Aggregate( targetFilename, ( current, c ) => current.Replace( c, '-' ) );

        File.Copy( entry.Location, Path.Combine( targetPath, targetFilename ) );

        playlistCondenser.ReportProgress( (int)( (float)( entryIndex + 1 ) / Playlist.Count * 100 ) );
        if( playlistCondenser.CancellationPending ) {
          break;
        }
      }
      playlistCondenser.ReportProgress( 100 );
    }

    public delegate void PlaylistUpdater( ListViewItem listViewItem );

    public void UpdatePlaylist( ListViewItem listViewItem ) {
      listView1.Items.Add( listViewItem );
    }

    private List<PlaylistEntry> LoadPlaylist( string filename ) {
      string[] lines = File.ReadAllLines( filename );
      if( "#EXTM3U" != lines[ 0 ] ) {
        throw new InvalidOperationException( "Unsupported playlist format." );
      }

      List<PlaylistEntry> result = new List<PlaylistEntry>();
      for( int lineIndex = 1; lineIndex < lines.Length; lineIndex += 2 ) {
        result.Add( PlaylistEntry.FromM3uData( filename, lines[ lineIndex + 0 ], lines[ lineIndex + 1 ] ) );
      }
      return result;
    }

    private void Form1_DragOver( object sender, DragEventArgs e ) {
      if( e.Data.GetDataPresent( DataFormats.FileDrop ) ) {
        e.Effect = DragDropEffects.Link;
      } else {
        e.Effect = DragDropEffects.None;
      }
    }

    private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e ) {
      DialogResult result = selectTargetDialog.ShowDialog();
      if( result == DialogResult.OK ) {
        TargetTextBox.Text = Path.Combine( selectTargetDialog.SelectedPath, "Condensed Playlist" );
      }
    }

    private void CondenseButton_Click( object sender, EventArgs e ) {
      if( Directory.Exists( TargetTextBox.Text ) ) {
        MessageBox.Show( String.Format( "{0} already exists. Please delete it.", TargetTextBox.Text ) );
        return;
      }
      Directory.CreateDirectory( TargetTextBox.Text );
      playlistCondenser.RunWorkerAsync();
    }

    private void listView1_KeyUp( object sender, KeyEventArgs e ) {
      if( e.KeyCode == Keys.Delete ) {
        foreach( ListViewItem selectedItem in listView1.SelectedItems ) {
          Playlist.Remove( (PlaylistEntry)selectedItem.Tag );
          listView1.Items.Remove( selectedItem );
        }
        UpdateInfoLabels();
      }
    }
  }
}