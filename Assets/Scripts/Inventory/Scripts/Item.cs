using System;
using UnityEngine;

//this class contain single item
[Serializable]

public class Item
{
    public ItemType m_ItemType;
    public int m_ItemAmount;
    public bool isStackable;
    //public Sprite GetSprite()
    //{
    //    //switch(m_ItemType)
    //    //{
    //    //    default:

    //    //    case ItemType.Key :
    //    //        return ItemAssets.instance.Key;
    //    //    case ItemType.Hint:
    //    //        return ItemAssets.instance.Hint;
    //    //    case ItemType.Note:
    //    //        return ItemAssets.instance.Note;
    //    //    case ItemType.Coin:
    //    //        return ItemAssets.instance.Coin;
    //    //}
    //    return m_ItemSprite;
    //}
}

public enum ItemType
{
    Key,
    Hint,
    Note,
    Coin,
    Object,
    Fuse,

}