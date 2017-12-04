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
            //テストデータ
                //flowデータ
                connection.Insert(new FlowTable { flow_id = "1", flow_name = "1", comment = "test" });

                //flowPartsデータ
                connection.Insert(new FlowPartsTable { flow_id = "1", identification_id = "1", type_id = "1", data = "1→i", position = "10,30", startFlag = "1" });
                connection.Insert(new FlowPartsTable { flow_id = "1", identification_id = "2", type_id = "2", data = "2→j", position = "10,70", startFlag = "0" });
                connection.Insert(new FlowPartsTable { flow_id = "1", identification_id = "3", type_id = "3", data = "j＋1→j", position = "10,110", startFlag = "0" });
                connection.Insert(new FlowPartsTable { flow_id = "1", identification_id = "4", type_id = "4", data = "i＋1→i", position = "10,150", startFlag = "0" });
                connection.Insert(new FlowPartsTable { flow_id = "1", identification_id = "5", type_id = "5", data = "i≦3", position = "10,190", startFlag = "0" });
                connection.Insert(new FlowPartsTable { flow_id = "1", identification_id = "6", type_id = "6", data = "j出力", position = "10,230", startFlag = "0" });

                //outputデータ
                connection.Insert(new OutputTable { flow_id = "1", identification_id = "1", output_identification_id = "2" });
                connection.Insert(new OutputTable { flow_id = "1", identification_id = "2", output_identification_id = "3" });
                connection.Insert(new OutputTable { flow_id = "1", identification_id = "3", output_identification_id = "4" });
                connection.Insert(new OutputTable { flow_id = "1", identification_id = "4", output_identification_id = "5" });
                connection.Insert(new OutputTable { flow_id = "1", identification_id = "5", output_identification_id = "3" });
                connection.Insert(new OutputTable { flow_id = "1", identification_id = "5", output_identification_id = "6" });
                connection.Insert(new OutputTable { flow_id = "1", identification_id = "6", output_identification_id = "-1" });

                //typeデータ
                connection.Insert(new TypeTable { type_id = "1", type_name = "1", output = "1" });
                connection.Insert(new TypeTable { type_id = "2", type_name = "2", output = "2" });
                connection.Insert(new TypeTable { type_id = "3", type_name = "3", output = "1" });
                connection.Insert(new TypeTable { type_id = "4", type_name = "4", output = "1" });
                connection.Insert(new TypeTable { type_id = "5", type_name = "5", output = "1" });


                foreach (var items in (from x in connection.Table<FlowTable>() orderby x.flow_id select x))
                {
                    System.Diagnostics.Debug.WriteLine("flowTable" + " " + items.flow_id + " " + items.flow_name + " " + items.comment);
                }
                foreach (var items in (from x in connection.Table<TypeTable>() orderby x.type_id select x))
                {
                    System.Diagnostics.Debug.WriteLine("flowTable" + " " + items.type_id + " " + items.type_id + " " + items.output);
                }
                foreach (var items in (from x in connection.Table<FlowPartsTable>() orderby x.flow_id select x))
                {
                    System.Diagnostics.Debug.WriteLine("flowTable" + " " + items.flow_id + " " + items.identification_id + " " + items.type_id + " " + items.data + " " + items.position + " " + items.startFlag);
                }
                foreach (var items in (from x in connection.Table<OutputTable>() orderby x.flow_id select x))
                {
                    System.Diagnostics.Debug.WriteLine("flowTable" + " " + items.flow_id + " " + items.identification_id + " " + items.output_identification_id);
                }
                connection.Close();
            }
        }


        public static async Task<SQLiteConnection> CreateConnection()
        {

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

    //public class GetConnection
    //{
    //    public void Connection()
    //    {
    //        static var connection;

    //        const string DatabasesFileName = "DB_TestFile.db3";
    //        //ルートフォルダの取得を行う
    //        IFolder rootFolder = FileSystem.Current.LocalStorage;
    //        //DBファイルの存在をチェックする
    //        var result = rootFolder.CheckExistsAsync(DatabasesFileName);
    //        if (result == ExistenceCheckResult.NotFound)
    //        {
    //            //存在しなかった場合に限り、新たにファイル作成とテーブル作成を新規に行う
    //            IFile file = rootFolder.CreateFileAsync(DatabasesFileName, CreationCollisionOption.ReplaceExisting);
    //            connection = new SQLiteConnection(file.Path);

    //            connection.CreateTable<FlowTable>();
    //            connection.CreateTable<FlowPartsTable>();
    //            connection.CreateTable<OutputTable>();
    //            connection.CreateTable<TypeTable>();

    //            return connection;
    //        }
    //        else
    //        {
    //            //ファイルが存在する場合はそのままコネクションの作成を行う
    //            IFile file = rootFolder.CreateFileAsync(DatabasesFileName, CreationCollisionOption.OpenIfExists);
    //            connection = new SQLiteConnection(file.Path);
    //            if (connection.GetTableInfo("DBtestDeta ").Count <= 0)       //テーブルが存在するか確認
    //            {
    //                connection.CreateTable<FlowTable>();
    //                connection.CreateTable<FlowPartsTable>();
    //                connection.CreateTable<OutputTable>();
    //                connection.CreateTable<TypeTable>();

    //                return connection;
    //            }
    //            else
    //            {
    //                return connection;
    //            }
    //        }

    //    }
    //}    
}
