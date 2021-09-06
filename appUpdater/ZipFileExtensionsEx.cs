/*
 * SharpDevelopによって生成
 * ユーザ: 大介
 * 日付: 2020/05/31
 * 時刻: 16:30
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */
using System;
using System.IO;
using System.IO.Compression;

namespace appUpdater
{
	/// <summary>
	/// Description of ZipFileExtensionsEx.
	/// </summary>
	public static class ZipFileExtensionsEx
	{
		/// <summary>
        /// エントリーがディレクトリかどうか取得する。
        /// </summary>
        /// <param name="entry">ZIPアーカイブエントリー</param>
        /// <returns></returns>
        public static bool IsDirectory(this ZipArchiveEntry entry)
        {
            return string.IsNullOrEmpty(entry.Name);
        }

        /// <summary>
        /// ZIPアーカイブ内のすべてのファイルを特定のフォルダに解凍する。
        /// </summary>
        /// <param name="source">ZIPアーカイブ</param>
        /// <param name="destinationDirectoryName">解凍先ディレクトリ。</param>
        /// <param name="overwrite">上書きフラグ。ファイルの上書きを行う場合はtrue。</param>
        public static void ExtractToDirectory(this ZipArchive source, string destinationDirectoryName, bool overwrite)
        {
            foreach (var entry in source.Entries)
            {
                var fullPath = Path.Combine(destinationDirectoryName, entry.FullName);
                if (entry.IsDirectory())
                {
                    if (!Directory.Exists(fullPath))
                    {
                        Directory.CreateDirectory(fullPath);
                    }
                }
                else
                {
                    if (overwrite){
                        entry.ExtractToFile(fullPath, true); 
                    }
                    else
                    {
                        if (!File.Exists(fullPath)) {
                            entry.ExtractToFile(fullPath, true); 
                        }
                    }
                }
            }
        }
	}
}
