using System.Collections.Generic;

[System.Serializable]
public class AAInfo
{
    public AAInfo()
    {
        filePath = string.Empty;
        md5 = string.Empty;
        depend = new string[0];
    }
    public AAInfo(string _filePath, string _md5, string[] _depend)
    {
        this.filePath = _filePath;
        this.md5 = _md5;
        this.depend = _depend;
    }
    public string filePath;
    public string md5;
    public string[] depend;
}
//assets.bytes
[System.Serializable]
public class AssetsBytes
{
    public AssetsBytes() //没有构造函数无法反序列化
    {
        this.res_version = 1;
        this.AAInfoList =  new AAInfo[0];
    }
    public AssetsBytes(int _res_version, List<AAInfo> _list)
    {
        this.res_version = _res_version;
        this.AAInfoList = _list.ToArray();
    }
    public int res_version;
    public AAInfo[] AAInfoList;
}