
namespace Trakker.Data.Access
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