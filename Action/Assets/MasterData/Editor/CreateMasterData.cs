using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq; 
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

/*public class CreateMasterData : ScriptableObject
{
    private static readonly string FileNameItemMaster   = "ItemMasterData";
    private static readonly string FileNameEnumType     = "EnumType";
    private static readonly string CsvPath1             = Application.dataPath + "/MasterData/Editor/" + FileNameItemMaster + ".csv";
    private static readonly string CsvPath2             = Application.dataPath + "/MasterData/Editor/" + FileNameEnumType + ".csv";

    private static List<string> _masterDataLists = new List<string>();

    [MenuItem("ScriptableObjects/Create Master Data.")]
    private static void CreateMasterDataAsset()
    {
        _masterDataLists.Clear();
        // マスターデータの読み込み
        using (var str = new StreamReader(CsvPath1))
        {
            var itemMasterDatas:string = str.ReadToEnd().Replace(oldValue:"\r\n", newValue:"\n").Replace(oldValue:"\r", newValue:"\n");
            _masterDataLists = itemMasterDatas.Split(params separator: '\n').ToList().Where(msg :string => string.IsNullOrWhiteSpace(msg) && msg.IndexOf("//") < 0).ToList();
        }

        string[] guids = AssetDatabase.FindAssets(filter string.Format("t:{0}", FileNameItemMaster));
        if (guids.Length > 0)
        {
            //var emptyCardMasterAsset = AssetDatabase.LoadAssetAtPath<CardMasterDataModel>(AssetDatabase.GUIDToAssetPath(guids[0]));
            //MakeCardBaseMasterData(emptyCardMasterAsset.CardMasterData.CardCharaDataModels);
            //MakeCardLevelMasterData(emptyCardMasterAsset.CardMasterData.CardCharaDataModels);
            //MakeEquipMasterData(emptyCardMasterAsset.CardMasterData.CardEquipDataModels);
            //MakeItemMasterData(emptyCardMasterAsset.CardMasterData.CardItemDataModels);
            //MakeMagicMasterData(emptyCardMasterAsset.CardMasterData.CardMagicDataModels);
            //MakeClericMasterData(emptyCardMasterAsset.CardMasterData.CardClericDataModels);
        }
        else
        {
            //var emptyCardMasterAsset = CreateInstance<CardMasterDataModel>();
            //MakeCardBaseMasterData(emptyCardMasterAsset.CardMasterData.CardCharaDataModels);
            //MakeCardLevelMasterData(emptyCardMasterAsset.CardMasterData.CardCharaDataModels);
            //MakeEquipMasterData(emptyCardMasterAsset.CardMasterData.CardEquipDataModels);
            //MakeItemMasterData(emptyCardMasterAsset.CardMasterData.CardItemDataModels);
            //MakeMagicMasterData(emptyCardMasterAsset.CardMasterData.CardMagicDataModels);
            //MakeClericMasterData(emptyCardMasterAsset.CardMasterData.CardClericDataModels);
            //var assetName = $"{AssetPath}{fileName}";
            //AssetDatabase.CreateAsset(emptyCardMasterAsset, assetName);
            AssetDatabase.Refresh();
        }
    }
}*/

#endif
