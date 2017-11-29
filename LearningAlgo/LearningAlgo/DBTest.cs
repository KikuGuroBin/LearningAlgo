using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using PCLStorage;

namespace LearningAlgo
{
    public class DBTest
    {
        public void DBtest()
        {
            OnAppearing();
        }

        protected async void OnAppearing()
        {
            using (var connection = await CreateConnection())
            // DBへのコネクションを取得してくるConnection())
            {
                var item = new FlowTable { flow_id = "f01", flow_name = "f01", comment = "test" };
                connection.Insert(item);

                foreach (var items in (from x in connection.Table<FlowTable>() orderby x.flow_id select x))
                {
                    System.Diagnostics.Debug.WriteLine(items.flow_id + items.flow_name + items.comment);
                }
            }
        }


        private async Task<SQLiteConnection> CreateConnection()
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
