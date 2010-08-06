
namespace Trakker.Data.Access.SqlServer
{
    using System;
    using System.Configuration;

    public partial class TrakkerDBDataContext
    {
        public TrakkerDBDataContext()
            : base(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString, mappingSource)
        {

        }
    }
}