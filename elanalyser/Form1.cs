/*                                        */
/*         EL Data Analyzer v1.01         */
/*              (2015/10/05)              */
/*                                        */
/*  Coded by 13期の駆け出しプログラマー   */
/*                                        */


/* 初期定義 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/* 名前空間 */

namespace elanalyser
{

    /* Form1 */

    public partial class Form1 : Form
    {
        /* 状態変数 */
        private bool ELS02Mode = false;     /* ELS-02モード */

        /* リストの宣言 */
        List<byte[]> SFFList = new List<byte[]>();


        public Form1()
        {
            InitializeComponent();
        }


        /* Form1のロード完了 */

        private void Form1_Load(object sender, EventArgs e)
        {
            /* 起動引数からファイルパスを取得 */
            string[] FilePass = Environment.GetCommandLineArgs();

            if (FilePass.Length > 1)
            {
                if (FileRead(FilePass[1]) == true)
                {
                    /* ユーザーリズムタブの表示 */
                    UserRythm_Show();

                    /* 操作ボタンの有効化 */
                    SaveSelectedSFF.Enabled = true;
                    SaveAllSFF.Enabled = true;
                    RenameAndSaveSFF.Enabled = true;
                }
            }
        }



        /* 開くボタンを押したときの動作 */

        private void button1_Click(object sender, EventArgs e)
        {

            /* ファイルを開くダイアログからパスを取得 */
            if (OpenRegistDialog.ShowDialog() == DialogResult.OK)
            {
                if (FileRead(OpenRegistDialog.FileName) == true)
                {
                    /* ユーザーリズムタブの表示 */
                    UserRythm_Show();

                    /* 操作ボタンの有効化 */
                    SaveSelectedSFF.Enabled = true;
                    SaveAllSFF.Enabled = true;
                    RenameAndSaveSFF.Enabled = true;
                }
            }
        }



        /* ファイルがD&Dされたときの動作 */

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            /* ファイルパスの取得 */
            string[] FilePass = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            /* ファイルを読み込み */
            if (FileRead(FilePass[0]) == true)
            {
                /* ユーザーリズムタブの表示 */
                UserRythm_Show();

                /* 操作ボタンの有効化 */
                SaveSelectedSFF.Enabled = true;
                SaveAllSFF.Enabled = true;
                RenameAndSaveSFF.Enabled = true;
            }
        }



        /* 選択保存ボタンを押したときの動作 */

        private void SaveSelectedSFF_Click(object sender, EventArgs e)
        {
            /* 1つ以上のリズムユーザーが選択されていることを確認 */
            if (UserRythmList.SelectedIndices.Count > 0)
            {
                /* フォルダ選択ダイアログを開き保存先パスを取得 */
                try
                {
                    if (SaveSFFFolderDialog.ShowDialog() == DialogResult.OK)
                    {
                        /* 選択されたSFF */
                        for (byte i = 0; i < UserRythmList.SelectedIndices.Count; i++)
                        {
                            byte k = (byte)UserRythmList.SelectedIndices[i];

                            /* ファイルストリームを用いて保存 */
                            using (FileStream fs = new FileStream(SaveSFFFolderDialog.SelectedPath + @"/User" + (k+1).ToString() + ".sty", FileMode.Create, FileAccess.Write))
                            {
                                fs.Write(SFFList[k], 0, SFFList[k].Length);
                            }
                        }

                        /* 完了報告 */
                        MessageBox.Show(UserRythmList.SelectedIndices.Count.ToString() + "個のStyleファイルを出力しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("ファイルの保存に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            /* ユーザー未選択エラー */
            else
            {
                MessageBox.Show("リズムユーザーが選択されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /* すべて保存ボタンを押したときの動作 */

        private void SaveAllSFF_Click(object sender, EventArgs e)
        {
            /* フォルダ選択ダイアログを開き保存先パスを取得 */
            try
            {
                if (SaveSFFFolderDialog.ShowDialog() == DialogResult.OK)
                {
                    byte k = 0;

                    /* すべてのSFF */
                    for (byte i = 0; i < 48; i++)
                    {
                        /* ファイルストリームを用いて保存 */ 
                        if (SFFList[i].Length > 388)
                        {
                            using (FileStream fs = new FileStream(SaveSFFFolderDialog.SelectedPath + @"/User" + (i + 1).ToString() + ".sty", FileMode.Create, FileAccess.Write))
                            {
                                fs.Write(SFFList[i], 0, SFFList[i].Length);
                            }

                            k++;
                        }
                    }

                    /* 完了報告 */
                    MessageBox.Show(k.ToString() + "個のStyleファイルを出力しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            /* 保存エラー */
            catch
            {
                MessageBox.Show("ファイルの保存に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /* 名前を付けて保存ボタンを押したときの動作 */

        private void RenameAndSaveSFF_Click(object sender, EventArgs e)
        {
            /* 選択されているすべてのユーザーについて処理を行う */
            for (byte i = 0; i < UserRythmList.SelectedIndices.Count; i++)
            {
                byte k = (byte)UserRythmList.SelectedIndices[i];

                /* デフォルトの保存名を指定 */
                SaveSFFDialog.FileName = "User" + (k + 1).ToString() + ".sty";

                try
                {
                    /* FileStreamを用いて保存 */
                    if (SaveSFFDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream fs = new FileStream(SaveSFFDialog.FileName, FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(SFFList[k], 0, SFFList[k].Length);
                        }
                    }
                }

                /* 保存エラー */
                catch
                {
                    MessageBox.Show("ファイルの保存に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        /* ファイルの読み込み */

        private bool FileRead(string FilePass)
        {
            /* 変数定義 */
            byte[] REGIST = new byte[1];

            /* ファイルの内容をREGISTに読み込み */
            using (FileStream fs = new FileStream(FilePass, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    Array.Resize(ref REGIST, (int)fs.Length);
                    fs.Read(REGIST, 0, REGIST.Length);
                }

                /* ファイルが開けなかったときは異常終了 */
                catch
                {
                    MessageBox.Show("ファイルが開けません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }


            /* ファイルヘッダを確認 */

            /* ELS-01シリーズのデータの時 */
            if (REGIST[0] == 240 && REGIST[1] == 67 && REGIST[2] == 112 && REGIST[3] == 120 && REGIST[4] == 0 && REGIST[5] == 60 && REGIST[6] == 0 && REGIST[7] == 127)
            {
                ELS02Mode = false;
            }

            /* ELS-02シリーズのデータの時 */
            else if (REGIST[0] == 240 && REGIST[1] == 67 && REGIST[2] == 112 && REGIST[3] == 120 && REGIST[4] == 1 && REGIST[5] == 60 && REGIST[6] == 0 && REGIST[7] == 127)
            {
                ELS02Mode = true;
            }

            /* ファイルヘッダ検出ができなかったときは異常終了 */
            else
            {
                MessageBox.Show("ELデータファイルではありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            /* リストのクリア */
            SFFList.Clear();


            /* ユーザーリズムの読み込み */

            /* ローカル変数定義 */
            int[] SFF_head = new int[49];
            byte[] SFF_temp = new byte[1];
            byte head = 0;

            /* ヘッダの検出 */
            for (int n = 0; n < REGIST.Length - 7; n++)
            {
                if (REGIST[n] == 77 && REGIST[n + 1] == 84 && REGIST[n + 2] == 104 && REGIST[n + 3] == 100 && REGIST[n + 4] == 0 && REGIST[n + 5] == 0 && REGIST[n + 6] == 0 && REGIST[n + 7] == 6)
                {
                    SFF_head[head] = n;
                    head++;
                }
            }

            /* ヘッダの個数を確認 */
            if (head == 48)
            {
                /* 終端の設定 */
                if (ELS02Mode == true)
                {
                    SFF_head[48] = REGIST.Length - 161570;
                }
                else
                {
                    SFF_head[48] = REGIST.Length - 2;
                }

                /* ヘッダをもとに分割 */
                for (byte k = 0; k < 48; k++)
                {
                    Array.Resize(ref SFF_temp, SFF_head[k + 1] - SFF_head[k]);

                    for (int i = 0; i < SFF_head[k + 1] - SFF_head[k]; i++)
                    {
                        SFF_temp[i] = REGIST[SFF_head[k] + i];
                    }

                    SFFList.Add(SFF_temp);
                }

            }

            /* ヘッダが48個検出されなかったときは異常終了 */
            else
            {
                MessageBox.Show("データの読み込みに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            /* ファイルパスを表示 */
            textBox1.Text = FilePass;

            return true;

        }



        /* ユーザーリズムタブの表示 */

        private void UserRythm_Show()
        {
            /* ユーザーリズムリスト初期化 */
            UserRythmList.Items.Clear();

            /* ユーザーリズムリスト表示 */
            for (byte k = 0; k < 48; k++)
            {
                ListViewItem UR = new ListViewItem("User" + (k + 1).ToString());

                if (SFFList[k].Length > 388)
                {
                    UR.SubItems.Add("Original");
                    UR.ForeColor = Color.Black;
                }

                else
                {
                    UR.SubItems.Add("Empty");
                    UR.ForeColor = Color.Gray;
                }

                UR.SubItems.Add(SFFList[k].Length.ToString());

                UserRythmList.Items.Add(UR);
            }
        }

    }
}
