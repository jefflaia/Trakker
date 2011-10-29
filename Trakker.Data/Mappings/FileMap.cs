using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Trakker.Data.Mappings
{
    public class FileMap : ClassMap<File>
    {
        public FileMap()
        {
            Id(p => p.Id).GeneratedBy.Identity();

            Map(p => p.FileName)
                .Length(50)
                .Not.Nullable();

            Map(p => p.Path)
                .Length(500)
                .Not.Nullable();

            Map(p => p.ContentType)
                .Length(20)
                .Not.Nullable();

            Map(p => p.Uploaded)
                .Not.Nullable();

            Map(p => p.ContentLength)
                .Not.Nullable();

        }
    }
}
