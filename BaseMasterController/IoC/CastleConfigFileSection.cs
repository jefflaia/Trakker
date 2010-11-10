namespace Trakker.Core.IoC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Configuration;

    public class CastleConfigFileSection : ConfigurationSection
    {
        [ConfigurationProperty("file")]
        public FileElement File
        {
            get
            {
                return (FileElement)this["file"];
            }
            set
            { this["file"] = value; }
        }
    }

    // Define the "font" element
    // with "name" and "size" attributes.
    public class FileElement : ConfigurationElement
    {
        [ConfigurationProperty("path", DefaultValue = "empty path", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{};'\"|\\", MinLength = 1, MaxLength = 500)]
        public String Path
        {
            get
            { return (string)this["path"]; }
            set
            { this["size"] = value; }
        }
    }
}