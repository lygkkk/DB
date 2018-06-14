using System.Data.Common;

namespace DB
{
    public interface IDbInfo
    {
        DbConnection DbConnection { get; set; }
    }
}