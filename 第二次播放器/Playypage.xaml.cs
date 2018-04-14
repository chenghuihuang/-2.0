using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace 第二次播放器
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Playypage : Page
    {
        public Playypage()
        {
            this.InitializeComponent();
        }
        public async Task<StorageFile> Download()
        {
            try
            {
                var httpClient = new HttpClient();
                var buffer = await httpClient.GetBufferAsync(new Uri("http://www.neu.edu.cn/indexsource/neusong.mp3"));
                var file = await KnownFolders.MusicLibrary.CreateFileAsync("neusong.mp3", CreationCollisionOption.ReplaceExisting);
                using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
                {
                    await stream.WriteAsync(buffer);
                    await stream.FlushAsync();
                }
              mediaPlayer.Source = new Uri("http://www.neu.edu.cn/indexsource/neusong.mp3");
                return file;
            }
            catch { }
            return null;
        }
        private void Button_Clickone(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Source = new Uri("http://www.neu.edu.cn/indexsource/neusong.mp3");
        }
        
        private void Button_Clicktwo(object sender, RoutedEventArgs e)
        {
            Download();
        }


    }
}
