using PCLStorage;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearningAlgo
{
    public class PartsLoadClass
    {

        Dictionary<string, List<string>> PartsTb;

        public PartsLoadClass()
        {
            OnAppearing();
        }


        public Dictionary<string, List<string>> PartsLoad()
        {

            return PartsTb;


        }
        public async void OnAppearing()
        {
            using (var connection = await CreateConnection())
            // DBへのコネクションを取得してくるConnection())
            {

                foreach (var selectItem in (from x in connection.Table<FlowTable>() orderby x.flow_id select x))
                {

                    while (true)//部品テーブル数回すを格納します
                    {
                        List<string> PartsContent = new List<string>();
                        while (true)//テーブルの中身をPartsContent.Add(string型)で追加
                        {
                            //try,catch使えってもつかわなくてもいいけど終ったらブレイク
                            try
                            {
                            }
                            catch (Exception e)
                            {
                                break;
                            }
                        }
                        PartsTb[""] = PartsContent;

                    }
                    
                    System.Diagnostics.Debug.WriteLine("flowTable" + selectItem.flow_id + selectItem.flow_name + selectItem.comment);
                }

                connection.Close();

            }
        }





        public async Task<SQLiteConnection> CreateConnection()
        {
            //
            const string DatabasesFileName = "DB_TestFile.db3";
            //ルートフォルダの取得を行う
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            //DBファイルの存在をチェックする
            var result = await rootFolder.CheckExistsAsync(DatabasesFileName);
            if (result == ExistenceCheckResult.NotFound)
            {
                //存在しなかった場合に限り、新たにファイル作成とテーブル作成を新規に行う
                IFile file = await rootFolder.CreateFileAsync(DatabasesFileName, CreationCollisionOption.ReplaceExisting);
                var connection = new SQLiteConnection(file.Path);

                connection.CreateTable<FlowTable>();
                connection.CreateTable<FlowPartsTable>();
                connection.CreateTable<OutputTable>();
                connection.CreateTable<TypeTable>();

                return connection;
            }
            else
            {
                //ファイルが存在する場合はそのままコネクションの作成を行う
                IFile file = await rootFolder.CreateFileAsync(DatabasesFileName, CreationCollisionOption.OpenIfExists);
                var connection = new SQLiteConnection(file.Path);
                if (connection.GetTableInfo("DBtestDeta ").Count <= 0)       //テーブルが存在するか確認
                {
                    connection.CreateTable<FlowTable>();
                    connection.CreateTable<FlowPartsTable>();
                    connection.CreateTable<OutputTable>();
                    connection.CreateTable<TypeTable>();

                    return connection;
                }
                else
                {
                    return connection;
                }


            }
        }


    }
}
