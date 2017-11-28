using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net;
using SQLite.Net.Attributes;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace LearningAlgo
{
    class DBadd
    {
        class DataBaseRepository
        {
            static readonly object Locker = new object();
            readonly SQLiteConnection db;
            public DataBaseRepository()
            {
                db = DependencyService.Get<ISQLite>().GetConnection();
                //SQLiteCommand command = db.CreateCommand();

                database();


            }

            public void database()
            {
                //テーブル作成
                db.CreateTable<FlowTable>();
                db.CreateTable<TypeTable>();
                db.CreateTable<OutputTable>();
                db.CreateTable<FlowPartsTable>();

                var flowtable = new FlowTable { flow_id = "f01", flow_name = "flowTest", comment = "ppp" };
                var outputtable = new OutputTable { flow_id = "f01", identification_id = 1, output_identification_id = 1, data = "i = 0" };
                var flowpartstable = new FlowPartsTable { flow_id = "f01", identification_id = 1, type_id = 1 };
                var typetable = new TypeTable { type_id = "t01", type_name = "sikaku", syuturyoku = 1 };

                db.Insert(flowtable);
                db.Insert(outputtable);
                db.Insert(flowpartstable);
                db.Insert(typetable);

                var flowTest = db.Table<FlowTable>();
                var flowpartsTest = db.Table<FlowPartsTable>();
                var typeTest = db.Table<TypeTable>();
                var outputTest = db.Table<OutputTable>();

                System.Console.WriteLine("flowtableのデータだよ～" + flowTest);
                System.Console.WriteLine("flowpartstableのデータだよ～" + flowpartsTest);
                System.Console.WriteLine("typetableのデータだよ～" + typeTest);
                System.Console.WriteLine("outputtableのデータだよ～" + outputTest);

                var stock = db.Get<FlowTable>(1);
                var stoklist = db.Table<FlowTable>();

                System.Console.WriteLine("Get" + stock);
                System.Console.WriteLine("Table" + stoklist);
            }

            private void ExecuteNonQuery(string v)
            {
                throw new NotImplementedException();
            }

            //public IEnumerable<FlowTable> GetItems()
            //{
            //    lock (Locker)
            //    {
            //        Delete == falseの一覧を取得する（削除フラグが立っているものは対象外）
            //        return _db.Table<FlowTable>().Where(m => m.Delete == false);
            //    }
            //}


            //データベースの追加・更新
            //public int SaveItem(FlowTable item)
            //{
            //    lock (Locker)
            //    {
            //        //// Idが0でない場合は、更新
            //        //if (item.flow_id != 0)
            //        //{ 
            //        //    db.Update(item);
            //        //    return item.Id;
            //        //} 
            //        //return db.Insert(item);





            //        return db.Insert(item);
            //    }
            //}

        }
    }
}
