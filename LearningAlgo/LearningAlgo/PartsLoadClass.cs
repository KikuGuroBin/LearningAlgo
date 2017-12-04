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
        /// <summary>
        /// パーツテーブルの格納
        /// </summary>
        public Dictionary<string, List<string>> ParTb;

        public async Task<Dictionary<string, List<string>>> OnAppearing()
        {
            using (var connection = await CreateConnection())
            // DBへのコネクションを取得してくるConnection())
            {
                var a = from b in connection.Table<FlowPartsTable>()
                        select b;
                ParTb = new Dictionary<string, List<string>>();

                foreach (var preset in connection.Table<FlowTable>())
                {
                   /* PreTb[preset.flow_id] = new Flowtable
                    {
                        id = preset.flow_id,
                        name = preset.flow_name,
                        comment = preset.comment
                    };*/
                }
               // System.Diagnostics.Debug.WriteLine(PreTb);
                connection.Close();

            }
            return ParTb;
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
