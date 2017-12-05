﻿using PCLStorage;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace LearningAlgo
{


    public class PartsLoadClass
    {
        /// <summary>
        /// パーツテーブルの格納
        /// </summary>
        public Dictionary<string, FlowPartstable> ParTb;
        /// <summary>
        /// 出力先の格納
        /// </summary>
        public Dictionary<(string, string), Outputtable> OutTb;

        public async Task<(Dictionary<string, FlowPartstable>, Dictionary<(string, string), Outputtable>)> OnAppearing(string Tb1ID)
        {
            using (var connection = await CreateConnection())
            // DBへのコネクションを取得してくるConnection())
            {
                ParTb = new Dictionary<string, FlowPartstable>();
                OutTb = new Dictionary<(string, string), Outputtable>();


                /*パーツの中身テーブル*/
                foreach (var preset in from x in connection.Table<FlowPartsTable>()
                                       where x.flow_id == Tb1ID
                                       select x)
                {
                    ParTb[preset.identification_id] = new FlowPartstable
                    {
                        flow_id = preset.flow_id,
                        identification_id = preset.identification_id,
                        type_id = preset.type_id,
                        data = preset.data,
                        position = preset.position,
                        startFlag = preset.startFlag
                    };
                    System.Diagnostics.Debug.WriteLine(ParTb[preset.identification_id].flow_id + ":" +
                        ParTb[preset.identification_id].identification_id + ":" +
                        ParTb[preset.identification_id].type_id + ":" +
                        ParTb[preset.identification_id].data + ":" +
                        ParTb[preset.identification_id].position + ":" +
                        ParTb[preset.identification_id].startFlag + ":");
                }

                var c = 0;

                var list = connection.Table<OutputTable>()
                                        .Where(x => x.flow_id == Tb1ID)
                                        .Select(x => x)
                                        .ToList();

                System.Diagnostics.Debug.WriteLine("deg : " + list.Count);

                //出力先テーブル
                foreach (var preset in list)
                {
                    OutTb[(preset.identification_id, preset.blanch_flag)] = new Outputtable
                    {
                        flow_id = preset.flow_id,
                        identification_id = preset.identification_id,
                        blanch_flag=preset.blanch_flag,
                        output_identification_id = preset.output_identification_id
                    };
                    
                    System.Diagnostics.Debug.WriteLine("deg : " + c++ + ParTb[preset.identification_id].flow_id + ":" +
                        OutTb[(preset.identification_id, preset.blanch_flag)].identification_id + ":" +
                        OutTb[(preset.identification_id, preset.blanch_flag)].output_identification_id + ":" );
                }

                connection.Close();
            }
            return (ParTb,OutTb);
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
