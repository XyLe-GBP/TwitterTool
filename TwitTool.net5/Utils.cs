using CoreTweet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using PrivateProfile;
using System.Net.NetworkInformation;

namespace TwitTool
{
    class Utils
    {
        private static readonly IniFile ini = new(@".\\settings.ini");

        public static readonly string API_KEY = ini.GetString("TOKENS", "CONSUMER_KEY", ""); //"X1ZhDKTcCeetWSdLo06l0tzQl";
        public static readonly string API_SECRET = ini.GetString("TOKENS", "CONSUMER_SECRET", ""); //"3KtHhx2Ry6B09ap7T7Wn7dr8sVb6rRs2Pnp7pP3ws79Q4LSKtc";
        public static readonly string ACCESS_TOKEN = ini.GetString("TOKENS", "ACCESS_TOKEN", ""); //"1146298479054077958-GJFJW8gD58N93pYrxoYlnepmzx2VEC";
        public static readonly string ACCESS_SECRET = ini.GetString("TOKENS", "ACCESS_SECRET", ""); //"vpi8SKhHI9YM4wEgsNxOtgXyNVaBUbXqiWogOdAGJw4SI";
        public static readonly string BEARER_TOKEN = ini.GetString("TOKENS", "BEARER_TOKEN", ""); //"AAAAAAAAAAAAAAAAAAAAAAWXOQEAAAAA%2BbD9fGwFKceskKZuiFDWoLo%2BMa0%3DBTg5v5sTTuG78X4BpWmLtyYCrqghKfhb7RM7ownqB5Q0G8vXo4";

        /// <summary>
        /// トークン格納用変数
        /// </summary>
        public static Tokens token;

        /// <summary>
        /// CoreTweet.Status変数
        /// </summary>
        public static CoreTweet.Core.ListedResponse<Status> stat;
        public static SearchResult SearchedStatus;
        public static Status[] SearchStatus;

        /// <summary>
        /// PINコード、自身のアイコン変数
        /// </summary>
        public static string pin, profileimg;

        /// <summary>
        /// ユーザーのFF数を格納する配列変数。
        /// </summary>
        public static int[] usrfollows, usrfollowers;

        /// <summary>
        /// listboxのindex変数
        /// 配列変数を使用する際に使用。( 使用法：Utils.usrid[Utils.listindex] )
        /// </summary>
        public static int listindex;

        /// <summary>
        /// 画像数を格納する変数
        /// 画像付きツイートをする際に使用。( 使用法：ImageURL[Utils.imageid] )
        /// </summary>
        public static int imageid;

        /// <summary>
        /// ツイートID用配列変数
        /// いいね、リツイート、リプライを飛ばす際に使用。
        /// </summary>
        public static long[] usrid;

        public static string entitiesid = null;

        /// <summary>
        /// ユーザーのアイコン画像URLを格納する配列変数。
        /// </summary>
        public static string[] usricon;

        /// <summary>
        /// ユーザーのヘッダー画像URLを格納する配列変数。
        /// </summary>
        public static string[] usrheader;

        /// <summary>
        /// ユーザーのプロフィール文を格納する配列変数。
        /// </summary>
        public static string[] usrbio;

        /// <summary>
        /// @から始まるユーザー名を格納する配列変数
        /// </summary>
        public static string[] usrscn;

        /// <summary>
        /// ユーザー名を格納する配列変数。
        /// </summary>
        public static string[] usrname;
        public static string[] usrnamelists;

        public static string[] usrnameArray1;
        public static string[] usrnameArray2;
        public static string[] usrnameArray3;
        public static string[] usrnameArray4;
        public static string[] usrnameArray5;

        /// <summary>
        /// フォローされているが自分がフォローしていないユーザー名を格納する配列変数。
        /// </summary>
        public static string[] friendsusrArray1;
        public static string[] friendsusrArray2;
        public static string[] friendsusrArray3;
        public static string[] friendsusrArray4;
        public static string[] friendsusrArray5;

        /// <summary>
        /// 自分がフォローしているがフォローされていないユーザー名を格納する配列変数。
        /// </summary>
        public static string[] notfriendsusrArray1;
        public static string[] notfriendsusrArray2;
        public static string[] notfriendsusrArray3;
        public static string[] notfriendsusrArray4;
        public static string[] notfriendsusrArray5;

        /// <summary>
        /// 相互フォロー中のユーザー名を格納する配列変数。
        /// </summary>
        public static string[] mutualfriendsusrArray1;
        public static string[] mutualfriendsusrArray2;
        public static string[] mutualfriendsusrArray3;
        public static string[] mutualfriendsusrArray4;
        public static string[] mutualfriendsusrArray5;

        /// <summary>
        /// Process.Start: Open URI for .NET
        /// </summary>
        /// <param name="URI">http://~ または https://~ から始まるウェブサイトのURL</param>
        public static void OpenURI(string URI)
        {
            try
            {
                Process.Start(URI);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    //Windowsのとき  
                    URI = URI.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {URI}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    //Linuxのとき  
                    Process.Start("xdg-open", URI);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    //Macのとき  
                    Process.Start("open", URI);
                }
                else
                {
                    throw;
                }
            }

            return;
        }

        /// <summary>
        /// 現在接続されているネットワークの速度を取得します。
        /// </summary>
        /// <returns>bps (bits per second) 単位で速度を示す Int64 値。</returns>
        public static long ShowInterfaceSpeedAndQueue()
        {
            long spd = 0;
            System.Net.WebClient wc = new();
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                //IPInterfaceProperties properties = adapter.GetIPProperties();
                IPv4InterfaceStatistics stats = adapter.GetIPv4Statistics();
                spd = stats.OutputQueueLength;
            }
            return spd;
        }

        /// <summary>
        /// TwitterAPIを利用するためにOAuth認証を実行します。
        /// </summary>
        /// <param name="API_KEY">API AppのCONSUMER_KEY</param>
        /// <param name="API_SECRET">API AppのCONSUMER_SECRET_KEY</param>
        /// <returns>Tokens値</returns>
        public static Tokens TwitterOAuth(string API_KEY, string API_SECRET)
        {
            var session = OAuth.Authorize(API_KEY, API_SECRET);
            OpenURI(session.AuthorizeUri.AbsoluteUri);

            var formPINCode = new FormPINCode();
            formPINCode.ShowDialog();
            formPINCode.Dispose();

            try
            {
                return OAuth.GetTokens(session, pin);
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Appトークンが設定されているかをチェックします。
        /// </summary>
        /// <returns>真偽値</returns>
        public static bool TokensCheck()
        {
            if (API_KEY != "")
            {
                if (API_SECRET != "")
                {
                    if (ACCESS_TOKEN != "")
                    {
                        if (ACCESS_SECRET != "")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// TwitterAPIを利用するためにTokenを生成します。
        /// </summary>
        /// <param name="ck">API AppのCONSUMER_KEY</param>
        /// <param name="cks">API AppのCONSUMER_SECRET_KEY</param>
        /// <param name="at">取得したACCESS_TOKEN</param>
        /// <param name="ats">取得したACCESS_TOKEN_SECRET</param>
        /// <param name="uid">ユーザーID</param>
        /// <param name="sn">スクリーンネーム</param>
        /// <returns>Tokens値</returns>
        public static Tokens TokenCreate(string ck, string cks, string at, string ats, long uid, string sn)
        {
            try
            {
                return Tokens.Create(ck, cks, at, ats, uid, sn);
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを利用してタイムライン取得を行います。
        /// </summary>
        /// <param name="GetCount">取得するツイート数 (上限：300件)</param>
        /// <returns>ツイートID ( long[] )</returns>
        public static long[] GetHomeTimeLine(int GetCount)
        {
            if (GetCount > 300)
            {
                throw new Exception("TwitterAPIの制限を超えています。\n一度に取得可能な上限：300");
            }
            else
            {
                try
                {
                    List<long> ids = new();
                    stat = token.Statuses.HomeTimeline(count => GetCount);
                    foreach (var item in stat)
                    {
                        ids.Add((long)item.Id);
                    }
                    return ids.ToArray();
                }
                catch (TwitterException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                catch (WebException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                catch (TimeoutException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                catch (Exception e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        /// <summary>
        /// TwitterAPIを利用して特定のツイートを表示します。
        /// </summary>
        /// <param name="TargetTweetID">ツイートのID</param>
        /// <returns>ツイート本文</returns>
        public static string GetTweet(long TargetTweetID)
        {
            try
            {
                Status status = token.Statuses.Show(id => TargetTweetID);
                return status.Text;
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを利用して特定のツイートの@から始まるユーザー名を取得します。
        /// </summary>
        /// <param name="TargetTweetID">ツイートのID</param>
        /// <returns>@から始まるユーザー名</returns>
        public static string GetTweetUserScreenName(long TargetTweetID)
        {
            try
            {
                Status status = token.Statuses.Show(id => TargetTweetID);
                return "@" + status.User.ScreenName;
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを利用して特定のツイートのユーザー名を取得します。
        /// </summary>
        /// <param name="TargetTweetID">ツイートのID</param>
        /// <returns>ユーザー名</returns>
        public static string GetTweetUserName(long TargetTweetID)
        {
            try
            {
                Status status = token.Statuses.Show(id => TargetTweetID);
                return status.User.Name;
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを利用して特定のツイートのユーザーのアイコンを取得します。
        /// </summary>
        /// <param name="TargetTweetID">ツイートのID</param>
        /// <returns>ユーザーのアイコン</returns>
        public static string GetTweetUserIcon(long TargetTweetID)
        {
            try
            {
                Status status = token.Statuses.Show(id => TargetTweetID);
                return status.User.ProfileImageUrlHttps;
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを利用して特定のツイートの画像もしくは動画のURLを取得します。
        /// 
        /// </summary>
        /// <param name="TargetTweetID">ツイートのID</param>
        /// <param name="Videobitrate">動画ビットレート [0: 低画質, 1:標準画質, 2:高画質]</param>
        /// <returns>ツイートに添付された画像または動画のURL</returns>
        public static string[] GetTweetEntities(long TargetTweetID, int Videobitrate = 0)
        {
            try
            {
                Status status = token.Statuses.Show(id => TargetTweetID);
                if (status.Entities != null && status.ExtendedEntities != null)
                {
                    List<string> urls = new();
                    MediaEntity[] media = status.ExtendedEntities.Media;

                    if (status.Entities.Urls.Length != 0)
                    {
                        entitiesid = "id=" + status.Entities.Urls[0].ExpandedUrl[(status.Entities.Urls[0].ExpandedUrl.LastIndexOf("/") + 1)..];
                    }
                    
                    switch (media.Length)
                    {
                        case 1:
                            if (media[0].VideoInfo != null)
                            {
                                VideoVariant[] vd = media[0].VideoInfo.Variants;
                                switch (Videobitrate)
                                {
                                    case 0:
                                        urls.Add(vd[0].Url);
                                        break;
                                    case 1:
                                        urls.Add(vd[1].Url);
                                        break;
                                    case 2:
                                        urls.Add(vd[3].Url);
                                        break;
                                    default:
                                        urls.Add(vd[0].Url);
                                        break;
                                }
                                return urls.ToArray();
                            }
                            else
                            {
                                urls.Add(media[0].MediaUrlHttps);
                            }
                            return urls.ToArray();
                        case 2:
                            urls.Add(media[0].MediaUrlHttps);
                            urls.Add(media[1].MediaUrlHttps);
                            return urls.ToArray();
                        case 3:
                            urls.Add(media[0].MediaUrlHttps);
                            urls.Add(media[1].MediaUrlHttps);
                            urls.Add(media[2].MediaUrlHttps);
                            return urls.ToArray();
                        case 4:
                            urls.Add(media[0].MediaUrlHttps);
                            urls.Add(media[1].MediaUrlHttps);
                            urls.Add(media[2].MediaUrlHttps);
                            urls.Add(media[3].MediaUrlHttps);
                            return urls.ToArray();
                        default:
                            return null;
                    }
                }
                else if (status.Entities == null && status.ExtendedEntities != null)
                {
                    List<string> urls = new();
                    MediaEntity[] media = status.ExtendedEntities.Media;
                    entitiesid = null;
                    switch (media.Length)
                    {
                        case 1:
                            if (media[0].VideoInfo != null)
                            {
                                VideoVariant[] vd = media[0].VideoInfo.Variants;
                                switch (Videobitrate)
                                {
                                    case 0:
                                        urls.Add(vd[0].Url);
                                        break;
                                    case 1:
                                        urls.Add(vd[1].Url);
                                        break;
                                    case 2:
                                        urls.Add(vd[3].Url);
                                        break;
                                    default:
                                        urls.Add(vd[0].Url);
                                        break;
                                }
                                return urls.ToArray();
                            }
                            else
                            {
                                urls.Add(media[0].MediaUrlHttps);
                            }
                            return urls.ToArray();
                        case 2:
                            urls.Add(media[0].MediaUrlHttps);
                            urls.Add(media[1].MediaUrlHttps);
                            return urls.ToArray();
                        case 3:
                            urls.Add(media[0].MediaUrlHttps);
                            urls.Add(media[1].MediaUrlHttps);
                            urls.Add(media[2].MediaUrlHttps);
                            return urls.ToArray();
                        case 4:
                            urls.Add(media[0].MediaUrlHttps);
                            urls.Add(media[1].MediaUrlHttps);
                            urls.Add(media[2].MediaUrlHttps);
                            urls.Add(media[3].MediaUrlHttps);
                            return urls.ToArray();
                        default:
                            return null;
                    }
                }
                else if (status.Entities != null && status.ExtendedEntities == null)
                {
                    List<string> id = new();
                    if (status.Entities.Urls.Length != 0)
                    {
                        entitiesid = "id=" + status.Entities.Urls[0].ExpandedUrl[(status.Entities.Urls[0].ExpandedUrl.LastIndexOf("/") + 1)..];
                        id.Add(status.Entities.Urls[0].ExpandedUrl[(status.Entities.Urls[0].ExpandedUrl.LastIndexOf("/") + 1)..]);
                        return id.ToArray();
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    entitiesid = null;
                    return null;
                }
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// 自身のアイコンを取得します。
        /// </summary>
        /// <returns>真偽値</returns>
        public static bool SetProfileImg()
        {
            try
            {
                 var result = token.Statuses.UserTimeline(count => 1);
                 foreach (Status status in result)
                 {
                    profileimg = status.User.ProfileImageUrlHttps;
                 }
                 return true;
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// TwitterAPIを利用してユーザーID取得を行います。
        /// リプライを送る場合はGetHomeTimeLineとの併用が必要です。
        /// </summary>
        /// <returns>@から始まるユーザーID ( string[] )</returns>
        public static string[] GetUserID()
        {
            try
            {
                List<string> un = new();
                foreach (var item in stat)
                {
                    un.Add("@" + item.User.ScreenName);
                }
                return un.ToArray();
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを利用してユーザーのアイコン取得を行います。
        /// アイコンを表示させたい場合に使用します。
        /// </summary>
        /// <returns>ユーザーのアイコンURL ( string[] )</returns>
        public static string[] GetUserProfileIcon()
        {
            try
            {
                List<string> un = new();
                foreach (var item in stat)
                {
                    un.Add(item.User.ProfileImageUrlHttps);
                }
                return un.ToArray();
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを利用してユーザーのヘッダー取得を行います。
        /// ヘッダーを表示させたい場合に使用します。
        /// </summary>
        /// <returns>ユーザーのアイコンURL ( string[] )</returns>
        public static string[] GetUserProfileHeader()
        {
            try
            {
                List<string> un = new();
                foreach (var item in stat)
                {
                    un.Add(item.User.ProfileBannerUrl);
                }
                return un.ToArray();
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを使用してユーザーのプロフィール説明文を取得します。
        /// </summary>
        /// <returns>ユーザーのプロフィール説明文</returns>
        public static string[] GetUserProfileBio()
        {
            try
            {
                List<string> un = new();
                foreach (var item in stat)
                {
                    un.Add(item.User.Description);
                }
                return un.ToArray();
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを使用してユーザー名の取得を行います。
        /// </summary>
        /// <returns>ユーザー名 ( string[] )</returns>
        public static string[] GetUserName()
        {
            try
            {
                List<string> un = new();
                foreach (var item in stat)
                {
                    un.Add(item.User.Name);
                }
                return un.ToArray();
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを使用してユーザーが現在フォローしているアカウント数の取得を行います。
        /// </summary>
        /// <returns>フォロー数 ( int[] )</returns>
        public static int[] GetUserFollows()
        {
            try
            {
                List<int> un = new();
                foreach (var item in stat)
                {
                    un.Add(item.User.FriendsCount);
                }
                return un.ToArray();
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを使用してユーザーが現在フォローされているアカウント数の取得を行います。
        /// </summary>
        /// <returns>フォロワー数 ( int[] )</returns>
        public static int[] GetUserFollowers()
        {
            try
            {
                List<int> un = new();
                foreach (var item in stat)
                {
                    un.Add(item.User.FollowersCount);
                }
                return un.ToArray();
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを使用して特定ツイートのいいねされた数の取得を行います。
        /// </summary>
        /// <param name="TargetTweetID">ツイートのID</param>
        /// <returns>いいねされた数</returns>
        public static int GetTweetFavoritedCount(long TargetTweetID)
        {
            try
            {
                Status status = token.Statuses.Show(id => TargetTweetID);
                return (int)status.FavoriteCount;
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        /// <summary>
        /// TwitterAPIを使用して特定ツイートのリツイートされた数の取得を行います。
        /// </summary>
        /// <param name="TargetTweetID">ツイートのID</param>
        /// <returns>リツイートされた数</returns>
        public static int GetTweetRetweetedCount(long TargetTweetID)
        {
            try
            {
                Status status = token.Statuses.Show(id => TargetTweetID);
                return (int)status.RetweetCount;
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        /// <summary>
        /// TwitterAPIを使用して特定ツイートのクライアント名を取得します。
        /// </summary>
        /// <param name="TargetTweetID">ツイートのID</param>
        /// <returns>ツイートに使用されたクライアント</returns>
        public static string GetTweetedSources(long TargetTweetID)
        {
            try
            {
                Status status = token.Statuses.Show(id => TargetTweetID);
                return status.Source.Substring(status.Source.IndexOf(">") + 1, status.Source.LastIndexOf("<") - status.Source.IndexOf(">") - 1);
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを利用して特定キーワードのツイートを検索します。
        /// </summary>
        /// <param name="GetCount">取得するツイート数 [必須] (上限：300)</param>
        /// <param name="SearchKeyword">検索ワード [必須]</param>
        /// <param name="ScreenName">ツイートを取得するユーザー (null指定可能)</param>
        /// <param name="Since">取得を開始する日時 (null指定可能)</param>
        /// <param name="Until">取得を終了する日時 (null指定可能)</param>

        /// <returns>Status配列</returns>
        public static Status[] SearchTweets(int GetCount, string SearchKeyword, string ScreenName = null, string Since = null, string Until = null)
        {
            try
            {
                List<Status> un = new();
                if (ScreenName != null && Since != null && Until != null)
                {
                    SearchedStatus = Utils.token.Search.Tweets(count => GetCount, from => ScreenName, q => SearchKeyword, until => Until);
                    foreach (var item in SearchedStatus)
                    {
                        un.Add(item);
                    }
                    return un.ToArray();
                }
                else if (ScreenName != null && Since == null && Until == null)
                {
                    SearchedStatus = Utils.token.Search.Tweets(count => GetCount, from => ScreenName, q => SearchKeyword);
                    foreach (var item in SearchedStatus)
                    {
                        un.Add(item);
                    }
                    return un.ToArray();
                }
                else if (ScreenName == null && Since != null && Until != null)
                {
                    SearchedStatus = Utils.token.Search.Tweets(count => GetCount, q => SearchKeyword, until => Until);
                    foreach (var item in SearchedStatus)
                    {
                        un.Add(item);
                    }
                    return un.ToArray();
                }
                else
                {
                    SearchedStatus = Utils.token.Search.Tweets(count => GetCount, q => SearchKeyword);
                    foreach (var item in SearchedStatus)
                    {
                        un.Add(item);
                    }
                    return un.ToArray();
                }
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを利用してID取得を行います。
        /// </summary>
        /// <param name="GetCount">取得するID数 (上限：300件)</param>
        /// <returns>ツイートID ( long[] )</returns>
        public static long[] GetUserIdForSearched(int GetCount)
        {
            if (GetCount > 300)
            {
                throw new Exception("TwitterAPIの制限を超えています。\n一度に取得可能な上限：300");
            }
            else
            {
                try
                {
                    List<long> ids = new();
                    foreach (var item in SearchStatus)
                    {
                        ids.Add((long)item.Id);
                    }
                    return ids.ToArray();
                }
                catch (TwitterException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                catch (WebException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                catch (TimeoutException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                catch (Exception e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        /// <summary>
        /// TwitterAPIを利用してScrrenName取得を行います。
        /// リプライを送る場合はGetUserIdForSearchedとの併用が必要です。
        /// </summary>
        /// <returns>@から始まるユーザーID ( string[] )</returns>
        public static string[] GetUserScreenNameForSearched()
        {
            try
            {
                List<string> un = new();
                foreach (var item in SearchStatus)
                {
                    un.Add("@" + item.User.ScreenName);
                }
                return un.ToArray();
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを利用してユーザーのアイコン取得を行います。
        /// アイコンを表示させたい場合に使用します。
        /// </summary>
        /// <returns>ユーザーのアイコンURL ( string[] )</returns>
        public static string[] GetUserProfileIconForSearched()
        {
            try
            {
                List<string> un = new();
                foreach (var item in SearchStatus)
                {
                    un.Add(item.User.ProfileImageUrlHttps);
                }
                return un.ToArray();
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを利用してユーザーのヘッダー取得を行います。
        /// ヘッダーを表示させたい場合に使用します。
        /// </summary>
        /// <returns>ユーザーのアイコンURL ( string[] )</returns>
        public static string[] GetUserProfileHeaderForSearched()
        {
            try
            {
                List<string> un = new();
                foreach (var item in SearchStatus)
                {
                    un.Add(item.User.ProfileBannerUrl);
                }
                return un.ToArray();
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを使用してユーザーのプロフィール説明文を取得します。
        /// </summary>
        /// <returns>ユーザーのプロフィール説明文</returns>
        public static string[] GetUserProfileBioForSearched()
        {
            try
            {
                List<string> un = new();
                foreach (var item in SearchStatus)
                {
                    un.Add(item.User.Description);
                }
                return un.ToArray();
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを使用してユーザー名の取得を行います。
        /// </summary>
        /// <returns>ユーザー名 ( string[] )</returns>
        public static string[] GetUserNameForSearched()
        {
            try
            {
                List<string> un = new();
                foreach (var item in SearchStatus)
                {
                    un.Add(item.User.Name);
                }
                return un.ToArray();
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを使用してユーザーが現在フォローしているアカウント数の取得を行います。
        /// </summary>
        /// <returns>フォロー数 ( int[] )</returns>
        public static int[] GetUserFollowsForSearched()
        {
            try
            {
                List<int> un = new();
                foreach (var item in SearchStatus)
                {
                    un.Add(item.User.FriendsCount);
                }
                return un.ToArray();
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを使用してユーザーが現在フォローされているアカウント数の取得を行います。
        /// </summary>
        /// <returns>フォロワー数 ( int[] )</returns>
        public static int[] GetUserFollowersForSearched()
        {
            try
            {
                List<int> un = new();
                foreach (var item in SearchStatus)
                {
                    un.Add(item.User.FollowersCount);
                }
                return un.ToArray();
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Twitterに投稿する画像パスを取得します。
        /// </summary>
        /// <returns>ファイルのパス配列</returns>
        public static FileInfo[] GetTweetImageFileInfos()
        {
            try
            {
                OpenFileDialog ofd = new()
                {
                    Title = "画像ファイルを選択",
                    Filter = "サポートされているすべての形式 (*.pjp,*.jpg,*.pjpeg,*.jpeg,*.jfif,*.png,*.webp,*.gif)|*.pjp;*.jpg;*.pjpeg;*.jpeg;*.jfif;*.png;*.webp;*.gif",
                    Multiselect = true,
                };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    List<FileInfo> fi = new();
                    foreach (var item in ofd.FileNames)
                    {
                        FileInfo fileInfo = new(item);
                        fi.Add(fileInfo);
                    }
                    return fi.ToArray();
                }
                else
                {
                    return null;
                }
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Twitterに投稿する動画パスを取得します。
        /// </summary>
        /// <returns>ファイルのパス</returns>
        public static FileInfo GetTweetVideoFileInfo()
        {
            try
            {
                OpenFileDialog ofd = new()
                {
                    Title = "動画ファイルを選択",
                    Filter = "サポートされているすべての形式 (*.gif,*.m4v,*.mp4,*.mov,*.webm)|*.gif;*.m4v;*.mp4;*.mov;*.webm",
                    Multiselect = false,
                };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileInfo = new(ofd.FileName);
                    return fileInfo;
                }
                else
                {
                    return null;
                }
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを利用してツイートを行います。
        /// </summary>
        /// <param name="TweetText">ツイートするテキスト</param>
        /// <returns>StatusResponse値</returns>
        public static StatusResponse TextOnlyTweet(string TweetText)
        {
            if (token != null)
            {
                try
                {
                    return Utils.token.Statuses.Update(status => TweetText);
                }
                catch (TwitterException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                catch (WebException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                catch (TimeoutException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                catch (Exception e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            else
            {
                MessageBox.Show("アクセストークンが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを利用して画像付きツイートを行います。
        /// </summary>
        /// <param name="TweetText">ツイートするテキスト</param>
        /// <param name="ImageURL">ツイートする画像パス</param>
        /// <returns>真偽値</returns>
        public static bool ImageTweet(string TweetText, FileInfo[] fileInfos)
        {
            if (token != null)
            {
                try
                {
                    if (fileInfos == null)
                    {
                        throw new Exception("ツイートする画像が指定されていません。");
                    }
                    if (fileInfos.Length > 4)
                    {
                        throw new Exception("ツイートする画像の数が多すぎます。\n画像は最大4件までです。");
                    }
                    MediaUploadResult upload_result_v1, upload_result_v2, upload_result_v3, upload_result_v4;
                    switch (fileInfos.Length)
                    {
                        case 0:
                            throw new Exception("予期せぬエラーが発生しました。");
                        case 1:
                            upload_result_v1 = token.Media.Upload(media: new FileInfo(fileInfos[0].ToString()));
                            upload_result_v2 = null;
                            upload_result_v3 = null;
                            upload_result_v4 = null;
                            token.Statuses.Update(status => TweetText, media_ids => new long[] { upload_result_v1.MediaId });
                            break;
                        case 2:
                            upload_result_v1 = token.Media.Upload(media: new FileInfo(fileInfos[0].ToString()));
                            upload_result_v2 = token.Media.Upload(media: new FileInfo(fileInfos[1].ToString()));
                            upload_result_v3 = null;
                            upload_result_v4 = null;
                            token.Statuses.Update(status => TweetText, media_ids => new long[] { upload_result_v1.MediaId, upload_result_v2.MediaId });
                            break;
                        case 3:
                            upload_result_v1 = token.Media.Upload(media: new FileInfo(fileInfos[0].ToString()));
                            upload_result_v2 = token.Media.Upload(media: new FileInfo(fileInfos[1].ToString()));
                            upload_result_v3 = token.Media.Upload(media: new FileInfo(fileInfos[2].ToString()));
                            upload_result_v4 = null;
                            token.Statuses.Update(status => TweetText, media_ids => new long[] { upload_result_v1.MediaId, upload_result_v2.MediaId, upload_result_v3.MediaId });
                            break;
                        case 4:
                            upload_result_v1 = token.Media.Upload(media: new FileInfo(fileInfos[0].ToString()));
                            upload_result_v2 = token.Media.Upload(media: new FileInfo(fileInfos[1].ToString()));
                            upload_result_v3 = token.Media.Upload(media: new FileInfo(fileInfos[2].ToString()));
                            upload_result_v4 = token.Media.Upload(media: new FileInfo(fileInfos[3].ToString()));
                            token.Statuses.Update(status => TweetText, media_ids => new long[] { upload_result_v1.MediaId, upload_result_v2.MediaId, upload_result_v3.MediaId, upload_result_v4.MediaId });
                            break;
                        default:
                            throw new Exception("予期せぬエラーが発生しました。");
                    }
                    return true;
                }
                catch (TwitterException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (WebException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (TimeoutException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("アクセストークンが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// TwitterAPIを利用して動画ツイートを行います。
        /// </summary>
        /// <param name="TweetText">ツイートする本文</param>
        /// <param name="fileInfo">動画ファイルのパス</param>
        /// <returns></returns>
        public static bool VideoTweet(string TweetText, FileInfo fileInfo)
        {
            if (token != null)
            {
                try
                {
                    if (fileInfo == null)
                    {
                        throw new Exception("ツイートする動画が指定されていません。");
                    }
                    MediaUploadResult upload_result = token.Media.UploadChunked(File.OpenRead(fileInfo.ToString()), UploadMediaType.Video, media_category => "tweet_video");
                    token.Statuses.Update(status => TweetText, media_ids => new long[] { upload_result.MediaId });

                    return true;
                }
                catch (TwitterException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (WebException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (TimeoutException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("アクセストークンが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// TwitterAPIを利用していいねを行います。
        /// </summary>
        /// <param name="TargetTweetID">いいねするツイートのID</param>
        /// <returns>unsigned int値 [0:失敗, 1:成功, 2:成功]</returns>
        public static uint FavoriteTweet(long TargetTweetID)
        {
            if (token != null)
            {
                try
                {
                    Status status = token.Statuses.Show(id => TargetTweetID);

                    //いいねする
                    if ((bool)status.IsFavorited == false)
                    {
                        //ツイートIDを使っていいねする
                        status = token.Favorites.Create(id => TargetTweetID);
                        return 1;
                    }
                    else
                    {
                        status = token.Favorites.Destroy(id => TargetTweetID);
                        return 2;
                    }
                }
                catch (TwitterException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                catch (System.Net.WebException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                catch (System.TimeoutException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                catch (Exception e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
            else
            {
                MessageBox.Show("予期せぬエラーが発生しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// TwitterAPIを利用してRTを行います。
        /// </summary>
        /// <param name="TargetTweetID">RTするツイートのID</param>
        /// <returns>unsigned int値 [0:失敗, 1:成功, 2:成功]</returns>
        public static uint Retweet(long TargetTweetID)
        {
            if (Utils.token != null)
            {
                try
                {
                    Status status = token.Statuses.Show(id => TargetTweetID);

                    if ((bool)status.IsRetweeted == false)
                    {
                        status = token.Statuses.Retweet(id => TargetTweetID);
                        return 1;
                    }
                    else
                    {
                        status = token.Statuses.Unretweet(id => TargetTweetID);
                        return 2;
                    }
                }
                catch (TwitterException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                catch (System.Net.WebException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                catch (System.TimeoutException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                catch (Exception e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
            else
            {
                MessageBox.Show("予期せぬエラーが発生しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// TwitterAPIを利用してリプライを行います。
        /// </summary>
        /// <param name="ReplyText">リプライ内容</param>
        /// <param name="UserName">@から始まるユーザー名</param>
        /// <param name="TargetTweetID">リプライするツイートのID</param>
        /// <returns>真偽値</returns>
        public static bool SendReply(string ReplyText, string UserName, long TargetTweetID)
        {
            if (Utils.token != null)
            {
                try
                {
                    string reply_text = UserName + "\n" + ReplyText;
                    token.Statuses.Update(status => reply_text, in_reply_to_status_id => TargetTweetID);
                    return true;
                }
                catch (TwitterException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (System.Net.WebException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (System.TimeoutException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("予期せぬエラーが発生しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// TwitterAPIを利用して引用リツイートを行います。
        /// </summary>
        /// <param name="QuoteText">引用本文</param>
        /// <param name="UserName">@から始まるユーザー名</param>
        /// <param name="TargetTweetID">引用リツイートするツイートのID</param>
        /// <returns></returns>
        public static bool QuoteTweet(string QuoteText, string UserName, long TargetTweetID)
        {
            if (Utils.token != null)
            {
                try
                {
                    string quote_url = "https://twitter.com/" + UserName.Replace("@", "") + "/status/" + TargetTweetID;
                    token.Statuses.Update(status => QuoteText, attachment_url => quote_url);
                    return true;
                }
                catch (TwitterException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (System.Net.WebException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (System.TimeoutException e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception e)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("予期せぬエラーが発生しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// ユーザー関連情報をまとめて取得します。
        /// </summary>
        /// <param name="GetCount">取得する数</param>
        /// <returns>真偽値</returns>
        public static bool GetStatuses(int GetCount)
        {
            Utils.usrid = Utils.GetHomeTimeLine(GetCount);
            Utils.usrname = Utils.GetUserName();
            Utils.usrscn = Utils.GetUserID();
            Utils.usricon = Utils.GetUserProfileIcon();
            Utils.usrheader = Utils.GetUserProfileHeader();
            Utils.usrfollows = Utils.GetUserFollows();
            Utils.usrfollowers = Utils.GetUserFollowers();
            Utils.usrbio = Utils.GetUserProfileBio();

            return true;
        }

        /// <summary>
        /// ユーザー関連情報をまとめて取得します。
        /// </summary>
        /// <param name="GetCount">取得する数</param>
        /// <returns>真偽値</returns>
        public static bool GetStatusesForSearched(int GetCount)
        {
            Utils.usrid = Utils.GetUserIdForSearched(GetCount);
            Utils.usrscn = Utils.GetUserScreenNameForSearched();
            Utils.usrname = Utils.GetUserNameForSearched();
            Utils.usrbio = Utils.GetUserProfileBioForSearched();
            Utils.usricon = Utils.GetUserProfileIconForSearched();
            Utils.usrheader = Utils.GetUserProfileHeaderForSearched();
            Utils.usrfollows = Utils.GetUserFollowsForSearched();
            Utils.usrfollowers = Utils.GetUserFollowersForSearched();

            return true;
        }

        /// <summary>
        /// TwitterAPIを利用して自身のフォロワーのリストを取得します。
        /// </summary>
        /// <param name="GetCount">取得数</param>
        /// <returns>@を除いたユーザー名の配列</returns>
        public static string[] GetFollowerLists(int GetCount)
        {
            try
            {
                List<string> un = new();
                var lists = token.Followers.List(cursor => -1, count => GetCount);
                foreach (var item in lists)
                {
                    un.Add(item.ScreenName);
                }

                var nextCursor = lists.NextCursor;
                lists = token.Followers.List(cursor => nextCursor, count => GetCount);
                foreach (var item in lists)
                {
                    un.Add(item.ScreenName);
                }

                return un.ToArray();
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// フォロワーリストを100件ずつ分割します。
        /// </summary>
        public static void SplittingUserList()
        {
            if (100 >= usrnamelists.Length)
            {
                List<string> un = new();
                for (int i = 0; i < usrnamelists.Length; i++)
                {
                    un.Add(usrnamelists[i]);
                }
                usrnameArray1 = un.ToArray();
                return;
            }
            else if (100 <= usrnamelists.Length && 200 >= usrnamelists.Length)
            {
                List<string> un1 = new();
                List<string> un2 = new();
                for (int i = 0; i < 100; i++)
                {
                    un1.Add(usrnamelists[i]);
                }
                for (int i = 100; i < usrnamelists.Length; i++)
                {
                    un2.Add(usrnamelists[i]);
                }
                usrnameArray1 = un1.ToArray();
                usrnameArray2 = un2.ToArray();
                return;
            }
            else if (200 <= usrnamelists.Length && 300 >= usrnamelists.Length)
            {
                List<string> un1 = new();
                List<string> un2 = new();
                List<string> un3 = new();
                for (int i = 0; i < 100; i++)
                {
                    un1.Add(usrnamelists[i]);
                }
                for (int i = 100; i < 200; i++)
                {
                    un2.Add(usrnamelists[i]);
                }
                for (int i = 200; i < usrnamelists.Length; i++)
                {
                    un3.Add(usrnamelists[i]);
                }
                usrnameArray1 = un1.ToArray();
                usrnameArray2 = un2.ToArray();
                usrnameArray3 = un3.ToArray();
                return;
            }
            else if (300 <= usrnamelists.Length && 400 >= usrnamelists.Length)
            {
                List<string> un1 = new();
                List<string> un2 = new();
                List<string> un3 = new();
                List<string> un4 = new();
                for (int i = 0; i < 100; i++)
                {
                    un1.Add(usrnamelists[i]);
                }
                for (int i = 100; i < 200; i++)
                {
                    un2.Add(usrnamelists[i]);
                }
                for (int i = 200; i < 300; i++)
                {
                    un3.Add(usrnamelists[i]);
                }
                for (int i = 300; i < usrnamelists.Length; i++)
                {
                    un4.Add(usrnamelists[i]);
                }
                usrnameArray1 = un1.ToArray();
                usrnameArray2 = un2.ToArray();
                usrnameArray3 = un3.ToArray();
                usrnameArray4 = un4.ToArray();
                return;
            }
            else if (400 <= usrnamelists.Length && 500 >= usrnamelists.Length)
            {
                List<string> un1 = new();
                List<string> un2 = new();
                List<string> un3 = new();
                List<string> un4 = new();
                List<string> un5 = new();
                for (int i = 0; i < 100; i++)
                {
                    un1.Add(usrnamelists[i]);
                }
                for (int i = 100; i < 200; i++)
                {
                    un2.Add(usrnamelists[i]);
                }
                for (int i = 200; i < 300; i++)
                {
                    un3.Add(usrnamelists[i]);
                }
                for (int i = 300; i < 400; i++)
                {
                    un4.Add(usrnamelists[i]);
                }
                for (int i = 400; i < usrnamelists.Length; i++)
                {
                    un5.Add(usrnamelists[i]);
                }
                usrnameArray1 = un1.ToArray();
                usrnameArray2 = un2.ToArray();
                usrnameArray3 = un3.ToArray();
                usrnameArray4 = un4.ToArray();
                usrnameArray5 = un5.ToArray();
                return;
            }
        }

        /// <summary>
        /// TwitterAPIを利用してフォローされているが自分がフォローしていないアカウントを取得します。
        /// </summary>
        /// <param name="UserList">@を除いたユーザー名の配列</param>
        /// <returns>フォローされているが自分がフォローしていないユーザー名の配列</returns>
        public static string[] GetFriendsLists(string[] UserList)
        {
            try
            {
                List<string> un = new();
                var user = token.Friendships.Lookup(screen_name => UserList);
                for (int i = 0; i < 100; i++)
                {
                    switch (user[i].Connections.Length)
                    {
                        case 1:
                            if (user[i].Connections[0].Contains("followed_by"))
                            {
                                un.Add("@" + UserList[i]);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        case 2:
                            if (user[i].Connections[0].Contains("followed_by") || user[i].Connections[1].Contains("followed_by"))
                            {
                                if (user[i].Connections[0].Contains("following") || user[i].Connections[1].Contains("following"))
                                {
                                    break;
                                }
                                else
                                {
                                    un.Add("@" + UserList[i]);
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        case 3:
                            if (user[i].Connections[0].Contains("followed_by") || user[i].Connections[1].Contains("followed_by") || user[i].Connections[2].Contains("followed_by"))
                            {
                                if (user[i].Connections[0].Contains("following") || user[i].Connections[1].Contains("following") || user[i].Connections[2].Contains("following"))
                                {
                                    break;
                                }
                                else
                                {
                                    un.Add("@" + UserList[i]);
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        default:
                            break;
                    }
                }

                return un.ToArray();
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを利用して自分がフォローしているがフォローされていないアカウントを取得します。
        /// </summary>
        /// <param name="UserList">@を除いたユーザー名の配列</param>
        /// <returns>自分がフォローしているがフォローされていないユーザー名の配列</returns>
        public static string[] GetNotFriendsLists(string[] UserList)
        {
            try
            {
                List<string> un = new();
                var user = token.Friendships.Lookup(screen_name => UserList);
                for (int i = 0; i < 100; i++)
                {
                    if (user.Json.Contains("followed_by") && !user.Json.Contains("following"))
                    {
                        continue;
                    }
                    else if (user.Json.Contains("following") && !user.Json.Contains("followed_by"))
                    {
                        un.Add("@" + UserList[i]);
                    }
                    else if (user.Json.Contains("following") && user.Json.Contains("followed_by"))
                    {
                        continue;
                    }
                    else if (!user.Json.Contains("following") && !user.Json.Contains("followed_by"))
                    {
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }

                return un.ToArray();
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// TwitterAPIを利用して相互フォロー中のアカウントを取得します。
        /// </summary>
        /// <param name="UserList">@を除いたユーザー名の配列</param>
        /// <returns>相互フォロー中のユーザー名の配列</returns>
        public static string[] GetMutualFriendsLists(string[] UserList)
        {
            try
            {
                List<string> un = new();
                var user = token.Friendships.Lookup(screen_name => UserList);
                for (int i = 0; i < 100; i++)
                {
                    switch (user[i].Connections.Length)
                    {
                        case 2:
                            if (user[i].Connections[0].Contains("followed_by") || user[i].Connections[1].Contains("followed_by"))
                            {
                                if (user[i].Connections[0].Contains("following") || user[i].Connections[1].Contains("following"))
                                {
                                    un.Add("@" + UserList[i]);
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        case 3:
                            if (user[i].Connections[0].Contains("followed_by") || user[i].Connections[1].Contains("followed_by") || user[i].Connections[2].Contains("followed_by"))
                            {
                                if (user[i].Connections[0].Contains("following") || user[i].Connections[1].Contains("following") || user[i].Connections[2].Contains("following"))
                                {
                                    un.Add("@" + UserList[i]);
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        default:
                            break;
                    }
                }

                return un.ToArray();
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static long[] GetFavoritters(long TargetTweetID)
        {
            try
            {
                List<long> un = new();
                string Json;
                WebClient wc = new();

                Stream st = wc.OpenRead("https://twitter.com/i/activity/favorited_popup?id=" + TargetTweetID.ToString());
                StreamReader sr = new(st);
                Json = sr.ReadToEnd();

                sr.Close();
                st.Close();

                var result = token.Statuses.Show(id => TargetTweetID);
                foreach (var item in result.Json)
                {
                    
                    un.Add((long)item);
                }
                return un.ToArray();
            }
            catch (TwitterException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (WebException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TimeoutException e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}


namespace PrivateProfile
{
    /// <summary>
    /// Ini ファイルの読み書きを扱うクラスです。
    /// </summary>
    public class IniFile
    {
        [DllImport("kernel32.dll")]
        private static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);

        [DllImport("kernel32.dll")]
        private static extern uint GetPrivateProfileInt(string lpAppName, string lpKeyName, int nDefault, string lpFileName);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        /// <summary>
        /// Ini ファイルのファイルパスを取得、設定します。
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// インスタンスを初期化します。
        /// </summary>
        /// <param name="filePath">Ini ファイルのファイルパス</param>
        public IniFile(string filePath)
        {
            FilePath = filePath;
        }
        /// <summary>
        /// Ini ファイルから文字列を取得します。
        /// </summary>
        /// <param name="section">セクション名</param>
        /// <param name="key">項目名</param>
        /// <param name="defaultValue">値が取得できない場合の初期値</param>
        /// <returns></returns>
        public string GetString(string section, string key, string defaultValue = "")
        {
            var sb = new StringBuilder(1024);
            var r = GetPrivateProfileString(section, key, defaultValue, sb, (uint)sb.Capacity, FilePath);
            return sb.ToString();
        }
        /// <summary>
        /// Ini ファイルから整数を取得します。
        /// </summary>
        /// <param name="section">セクション名</param>
        /// <param name="key">項目名</param>
        /// <param name="defaultValue">値が取得できない場合の初期値</param>
        /// <returns></returns>
        public int GetInt(string section, string key, int defaultValue = 0)
        {
            return (int)GetPrivateProfileInt(section, key, defaultValue, FilePath);
        }
        /// <summary>
        /// Ini ファイルに文字列を書き込みます。
        /// </summary>
        /// <param name="section">セクション名</param>
        /// <param name="key">項目名</param>
        /// <param name="value">書き込む値</param>
        /// <returns></returns>
        public bool WriteString(string section, string key, string value)
        {
            return WritePrivateProfileString(section, key, value, FilePath);
        }
    }
}
