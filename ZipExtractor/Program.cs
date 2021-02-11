using System;
using System.IO.Compression;

namespace ZipExtractor
{
    class Program
    {
        static void Main()
        {
            Console.Write("ZipExtractor [Version 0.0.1]\n");
            Console.Write("処理を選択してください。(圧縮/解凍): ");
            var Process = Console.ReadLine();
            if (Process == "圧縮")
            {
                // 圧縮処理
                Console.Write("圧縮したいディレクトリを指定してください。");
                var startPath = @Console.ReadLine();
                string zipName = @"\compressed.zip";
                string prevPath = @"\..";
                string zipPath = @startPath + prevPath + zipName;
                Console.Write("[確認]\n 出力先: " + zipPath + "\n よろしいですか？(y/n): ");
                var compressConf = Console.ReadLine();
                if (compressConf == "y")
                {
                    ZipFile.CreateFromDirectory(
                        startPath,
                        zipPath,
                        CompressionLevel.Optimal,
                        false,
                        System.Text.Encoding.GetEncoding("UTF-8"));
                }
                else if (compressConf == "n")
                {
                    Console.Write("キャンセルされました。");
                    return;
                }
                else
                {
                    Console.Write("エラー: yまたはnを入力してください。");
                    return;
                }
            }

            else if (Process == "解凍")
            {
                // 解凍処理
                Console.Write("解凍したいzipファイルを指定してください。");
                var zipPath = @Console.ReadLine();
                Console.Write("解凍先のフォルダを指定してください。");
                var extractPath = @Console.ReadLine();
                Console.Write("[確認]\n 解凍先: " + extractPath + "\n 解凍するファイルのディレクトリ: " + zipPath + "\n よろしいですか？(y/n): ");
                var extractConf = Console.ReadLine();
                if (extractConf == "y")
                {
                    ZipFile.ExtractToDirectory(
                        zipPath,
                        extractPath);
                }
                else if (extractConf == "n")
                {
                    Console.Write("キャンセルされました。");
                    return;
                }
                else
                {
                    Console.Write("エラー: yまたはnを入力してください。");
                    return;
                }
            }

            else
            {
                return;
            }
        }
    }
}
