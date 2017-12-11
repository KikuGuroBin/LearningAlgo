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
            /* DBへのコネクションを取得してくるConnection()*/
            {
                /*初期化*/
                //foreach (var items in (from x in connection.Table<FlowTable>() orderby x.flow_id select x))
                //{
                //    //connection.Delete(items.flow_id);
                //    System.Diagnostics.Debug.WriteLine("FlowTable" + " " + items.flow_id + " " + items.flow_name + " " + items.comment);
                //    var count = connection.ExecuteScalar<int>("DELETE FROM FlowTable WHERE flow_id =" + items.flow_id + ";");
                //}
                //foreach (var items in (from x in connection.Table<TypeTable>() orderby x.type_id select x))
                //{
                //    System.Diagnostics.Debug.WriteLine("TypeTable" + " " + items.type_id + " " + items.type_name + " " + items.output);
                //    var count = connection.ExecuteScalar<int>("DELETE FROM FlowTable WHERE flow_id =" + items.type_id + ";");
                //}
                //foreach (var items in (from x in connection.Table<FlowPartsTable>() orderby x.flow_id select x))
                //{
                //    System.Diagnostics.Debug.WriteLine("FlowPartsTable" + " " + items.flow_id + " " + items.identification_id + " " + items.type_id + " " + items.data + " " + items.position + " " + items.startFlag);
                //    var count = connection.ExecuteScalar<int>("DELETE FROM FlowTable WHERE flow_id =" + items.flow_id + ";");
                //}
                //foreach (var items in (from x in connection.Table<OutputTable>() orderby x.flow_id select x))
                //{
                //    System.Diagnostics.Debug.WriteLine("OutputTable" + " " + items.flow_id + " " + items.identification_id + " " + items.output_identification_id);
                //    var count = connection.ExecuteScalar<int>("DELETE FROM FlowTable WHERE flow_id =" + items.flow_id + ";");
                //}

                /*******テストデータ*********/
                /*flowデータ*/
                connection.Insert(new FlowTable { flow_id = "1", flow_name = "1", comment = "test" });

                connection.Insert(new FlowTable { flow_id = "2", flow_name = "2", comment = "quizeTest" });

                /*flowPartsデータ*/
                connection.Insert(new FlowPartsTable { flow_id = "1", identification_id = "1", type_id = "1", data = "1→i", position_X = "10", position_Y = "70", startFlag = "1" });
                connection.Insert(new FlowPartsTable { flow_id = "1", identification_id = "2", type_id = "1", data = "2→j", position_X = "10", position_Y = "140", startFlag = "0" });
                connection.Insert(new FlowPartsTable { flow_id = "1", identification_id = "3", type_id = "1", data = "j＋1→j", position_X = "10", position_Y = "210", startFlag = "0" });
                connection.Insert(new FlowPartsTable { flow_id = "1", identification_id = "4", type_id = "1", data = "i＋1→i", position_X = "10", position_Y = "280", startFlag = "0" });
                connection.Insert(new FlowPartsTable { flow_id = "1", identification_id = "5", type_id = "2", data = "i≦3", position_X = "10", position_Y = "350", startFlag = "0" });
                connection.Insert(new FlowPartsTable { flow_id = "1", identification_id = "6", type_id = "5", data = "j出力", position_X = "10", position_Y = "420", startFlag = "0" });

                connection.Insert(new FlowPartsTable { flow_id = "2", identification_id = "1", type_id = "1", data = "1→i", position_X = "10", position_Y = "70", startFlag = "1" });
                connection.Insert(new FlowPartsTable { flow_id = "2", identification_id = "2", type_id = "1", data = "null", position_X = "10", position_Y = "140", startFlag = "0" });
                connection.Insert(new FlowPartsTable { flow_id = "2", identification_id = "3", type_id = "1", data = "j＋1→j", position_X = "10", position_Y = "210", startFlag = "0" });
                connection.Insert(new FlowPartsTable { flow_id = "2", identification_id = "4", type_id = "1", data = "i＋1→i", position_X = "10", position_Y = "280", startFlag = "0" });
                connection.Insert(new FlowPartsTable { flow_id = "2", identification_id = "5", type_id = "2", data = "null", position_X = "10", position_Y = "350", startFlag = "0" });
                connection.Insert(new FlowPartsTable { flow_id = "2", identification_id = "6", type_id = "5", data = "j出力", position_X = "10", position_Y = "420", startFlag = "0" });

                /*outputデータ*/
                connection.Insert(new OutputTable { flow_id = "1", identification_id = "1", output_identification_id = "2" });
                connection.Insert(new OutputTable { flow_id = "1", identification_id = "2", output_identification_id = "3" });
                connection.Insert(new OutputTable { flow_id = "1", identification_id = "3", output_identification_id = "4" });
                connection.Insert(new OutputTable { flow_id = "1", identification_id = "4", output_identification_id = "5" });
                connection.Insert(new OutputTable { flow_id = "1", identification_id = "5", output_identification_id = "3" });
                connection.Insert(new OutputTable { flow_id = "1", identification_id = "5", output_identification_id = "6" });
                connection.Insert(new OutputTable { flow_id = "1", identification_id = "6", output_identification_id = "-1" });

                /*typeデータ*/
                connection.Insert(new TypeTable { type_id = "1", type_name = "1", output = "1" });
                connection.Insert(new TypeTable { type_id = "2", type_name = "2", output = "2" });
                connection.Insert(new TypeTable { type_id = "3", type_name = "3", output = "1" });
                connection.Insert(new TypeTable { type_id = "4", type_name = "4", output = "1" });
                connection.Insert(new TypeTable { type_id = "5", type_name = "5", output = "1" });

                /*quizeテーブルのデータ*/
                connection.Insert(new QuizTable { flow_id = "2", quiz_flow_id = "q1"});

                /*spaceFlowPartsデータ*/
                connection.Insert(new SpaceIdentificationTable { quiz_flow_id = "q1", space_identification_id = "2" });
                connection.Insert(new SpaceIdentificationTable { quiz_flow_id = "q1", space_identification_id = "5" });


                foreach (var items in (from x in connection.Table<FlowTable>() orderby x.flow_id select x))
                {
                    //items.Query<FlowTable>("DELETE FROM FlowTable WHERE id = 1;");
                    System.Diagnostics.Debug.WriteLine("FlowTable" + " " + items.flow_id + " " + items.flow_name + " " + items.comment);
                }
                foreach (var items in (from x in connection.Table<TypeTable>() orderby x.type_id select x))
                {
                    System.Diagnostics.Debug.WriteLine("TypeTable" + " " + items.type_id + " " + items.type_id + " " + items.output);
                }
                foreach (var items in (from x in connection.Table<FlowPartsTable>() orderby x.flow_id select x))
                {
                    System.Diagnostics.Debug.WriteLine("FlowPartsTable" + " " + items.flow_id + " " + items.identification_id + " " + items.type_id + " " + items.data + " " + items.position_X + " " + items.position_Y + " " + items.startFlag);
                }
                foreach (var items in (from x in connection.Table<OutputTable>() orderby x.flow_id select x))
                {
                    System.Diagnostics.Debug.WriteLine("OutputTable" + " " + items.flow_id + " " + items.identification_id + " " + items.output_identification_id);
                }
                foreach (var items in (from x in connection.Table<QuizTable>() orderby x.flow_id select x))
                {
                    System.Diagnostics.Debug.WriteLine("QuizeTable" + " " + items.flow_id + " " + items.quiz_flow_id);
                }
                foreach (var items in (from x in connection.Table<SpaceIdentificationTable>() orderby x.quiz_flow_id select x))
                {
                    System.Diagnostics.Debug.WriteLine("SpaceIdentificationTable" + " " + items.quiz_flow_id + " " + items.space_identification_id);
                }
                connection.Close();
            }
        }


        public static async Task<SQLiteConnection> CreateConnection()
        {

            const string DatabasesFileName = "DB_TestFile.db3";
            /*ルートフォルダの取得を行う*/
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            /*DBファイルの存在をチェックする*/
            var result = await rootFolder.CheckExistsAsync(DatabasesFileName);
            if (result == ExistenceCheckResult.NotFound)
            {
                /*存在しなかった場合に限り、新たにファイル作成とテーブル作成を新規に行う*/
                IFile file = await rootFolder.CreateFileAsync(DatabasesFileName, CreationCollisionOption.ReplaceExisting);
                var connection = new SQLiteConnection(file.Path);

                connection.CreateTable<FlowTable>();
                connection.CreateTable<FlowPartsTable>();
                connection.CreateTable<OutputTable>();
                connection.CreateTable<TypeTable>();
                connection.CreateTable<QuizTable>();
                connection.CreateTable<SpaceIdentificationTable>();

                return connection;
            }
            else
            {
                /*ファイルが存在する場合はそのままコネクションの作成を行う*/
                IFile file = await rootFolder.CreateFileAsync(DatabasesFileName, CreationCollisionOption.OpenIfExists);
                ///<summary>
                ///データベース接続
                /// </summary>
                var connection = new SQLiteConnection(file.Path);

                /*テーブルを1回消去する*/
                connection.DropTable<FlowTable>();
                connection.DropTable<FlowPartsTable>();
                connection.DropTable<OutputTable>();
                connection.DropTable<TypeTable>();
                connection.DropTable<QuizTable>();
                connection.DropTable<SpaceIdentificationTable>();


                /*テーブルを新たに作成する*/
                if (connection.GetTableInfo("DBtestDeta ").Count <= 0)
                {
                    connection.CreateTable<FlowTable>();
                    connection.CreateTable<FlowPartsTable>();
                    connection.CreateTable<OutputTable>();
                    connection.CreateTable<TypeTable>();
                    connection.CreateTable<QuizTable>();
                    connection.CreateTable<SpaceIdentificationTable>();

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
