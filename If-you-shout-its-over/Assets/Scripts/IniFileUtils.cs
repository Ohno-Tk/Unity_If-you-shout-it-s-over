using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Reflection;

// iniファイルを読み込んだり書き込んだりするクラス
public static class IniFileUtils
{
    // ファイルごとの連想配列
    private static Dictionary<string, Dictionary<string, Dictionary<string, string>>> fileDic = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();

    // iniファイルから設定値を読み込む、該当の設定値がない場合はdefaultStrが返却される
    public static string read(string filePath, string section, string param, string defaultStr, Encoding enc)
    {

        // セクションごとの連想配列
        Dictionary<string, Dictionary<string, string>> sectionDic;
        // パラメータ(変数)ごとの連想配列
        Dictionary<string, string> paramDic;

        if (!fileDic.ContainsKey(filePath))
        {
            // まだファイルを読み込んでいない場合、読みこんで変数fileDicに格納する
            addFileDic(filePath, enc);
        }

        if (!fileDic.ContainsKey(filePath))
        {
            // ファイルが見つからなかった場合
            return defaultStr;
        }

        sectionDic = fileDic[filePath];
        if (!sectionDic.ContainsKey(section))
        {
            // セクションが見つからなかった場合
            return defaultStr;
        }

        paramDic = sectionDic[section];
        if (!paramDic.ContainsKey(param))
        {
            // パラメータが見つからなかった場合
            return defaultStr;
        }
        return paramDic[param];
    }

    public static string read(string filePath, string section, string param)
    {
        return read(filePath, section, param, "", Encoding.GetEncoding("UTF-8"));
    }

    // 読み込んだファイルをクリアする
    public static void clear(string filePath)
    {
        if (fileDic.ContainsKey(filePath))
        {
            fileDic.Remove(filePath);
        }
    }

    // 読み込んだファイルを再読み込みする
    public static void reload(string filePath)
    {
        clear(filePath);
        addFileDic(filePath, Encoding.GetEncoding("UTF-8"));
    }


    // iniファイルに設定値を書き込む
    public static void write(string filePath, string section, string param, string value, Encoding enc)
    {

        // ファイルを開いて読み込む
        reload(filePath);
        StreamReader sr = new StreamReader(filePath, enc);

        List<string> writeLine = new List<string>();

        // ファイルを1行ずつ読み込む
        // 現在読み込んでいるセクション名
        string curSection = "";

        bool isSectionExist = fileDic[filePath].ContainsKey(section);
        bool isParamExist = isSectionExist && fileDic[filePath][section].ContainsKey(param);

        while (sr.Peek() >= 0)
        {
            string buf = sr.ReadLine();
            string trimed = buf.Trim();
            if (trimed.StartsWith(";") || trimed.StartsWith("#"))
            {
                // コメント行の場合、そのまま書き込み
                writeLine.Add(buf);
            }
            else if (trimed.StartsWith("[") && trimed.EndsWith("]"))
            {
                string newSection = buf.Substring(1, buf.Length - 2);
                if (!isParamExist && curSection == section && newSection != curSection)
                {
                    // セクション変更時、新規パラメータなら書き込み
                    writeLine.Add(param + "=" + value);
                }
                // セクションの場合、そのまま書き込み
                curSection = newSection;
                writeLine.Add(buf);
            }
            else
            {
                // 設定値の場合
                if (curSection != section)
                {
                    // 別セクションの場合、そのまま書き込み
                    writeLine.Add(buf);
                }
                else
                {
                    string[] bufs = buf.Split('=');
                    if (bufs.Length != 2)
                    {
                        // key=valueの形式以外は何もしない
                    }
                    // パラメータ名
                    string key = bufs[0].Trim();
                    if (key == param)
                    {
                        // 同設定値の場合、値を書き換え
                        writeLine.Add(param + "=" + value);
                    }
                    else
                    {
                        // 別設定値の場合、そのまま書き込み
                        writeLine.Add(buf);
                    }
                }
            }
        }

        // 新規セクションの場合
        if (!isSectionExist)
        {
            writeLine.Add("[" + section + "]");
        }
        if (!isParamExist)
        {
            // 新規パラメータ場合
            writeLine.Add(param + "=" + value);
        }

        sr.Close();

        // ファイル書き込み
        StreamWriter sw = new StreamWriter(filePath, false, enc);
        for (int i = 0; i < writeLine.Count; i++)
        {
            if (i != writeLine.Count - 1 || writeLine[i] != "")
            {
                // 最終行は空白なら出力しない
                sw.WriteLine(writeLine[i]);
            }
        }

        sw.Close();

        // 書き込んだファイルを再読込する
        reload(filePath);
    }

    public static void write(string filePath, string section, string param, string value)
    {
        write(filePath, section, param, value, Encoding.GetEncoding("UTF-8"));
    }

    // ファイルを読み込んで変数fileDicに格納する
    private static void addFileDic(string filePath, Encoding enc)
    {
        clear(filePath);

        // 読み込み中のデータを格納しておく一時変数
        Dictionary<string, Dictionary<string, string>> tmpSecDic = new Dictionary<string, Dictionary<string, string>>();

        // ファイルを開いて読み込む
        StreamReader sr = new StreamReader(filePath, enc);

        // 現在読み込んでいるセクション名
        string curSection = "";

        while (sr.Peek() >= 0)
        {
            // ファイルを 1 行ずつ読み込む
            string buf = sr.ReadLine().Trim();
            if (buf.StartsWith(";") || buf.StartsWith("#"))
            {
                // コメント行の場合何もしない
            }
            else if (buf.StartsWith("[") && buf.EndsWith("]"))
            {
                // セクションの場合
                curSection = buf.Substring(1, buf.Length - 2);
            }
            else
            {
                string[] bufs = buf.Split('=');
                if (bufs.Length != 2)
                {
                    // key=valueの形式以外は何もしない
                }
                else
                {
                    // パラメータ名
                    string key = bufs[0].Trim();
                    // 設定値
                    string value = bufs[1].Trim();

                    Dictionary<string, string> targetParamDic;
                    if (tmpSecDic.ContainsKey(curSection))
                    {
                        // 読み込み済みのセクションの場合
                        targetParamDic = tmpSecDic[curSection];
                    }
                    else
                    {
                        // 新規のセクションの場合
                        targetParamDic = new Dictionary<string, string>();
                        tmpSecDic.Add(curSection, targetParamDic);
                    }

                    if (targetParamDic.ContainsKey(key))
                    {
                        // 設定値が重複していた場合は後勝ちにする
                        targetParamDic.Remove(filePath);
                    }
                    targetParamDic.Add(key, value);
                }
            }
        }

        fileDic.Add(filePath, tmpSecDic);
        sr.Close();
    }
}