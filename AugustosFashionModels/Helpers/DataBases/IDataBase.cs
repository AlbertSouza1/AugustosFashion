using System.Data;

namespace AugustosFashionModels.Helpers.DataBases
{
    public interface IDataBase
    {
        IDbConnection ObterConexao(IDbConnection db);
    }
}
