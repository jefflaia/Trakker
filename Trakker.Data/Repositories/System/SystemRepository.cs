namespace Trakker.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AutoMapper;
    using System.Data.Linq;

    using Sql = Access;
    using System.Globalization;
    using System.Reflection;

    public class SystemRepository : ISystemRepository
    {
        protected DataContext _dataContext;
        protected Table<Sql.ColorPalette> _paletteTable;
        protected Table<Sql.SystemSetting> _systemSettingTable;

        internal class Setting
        {
            public String Key { get; set; }
            public String Value { get; set; }
        }

        public SystemRepository(IDataContextProvider dataContext)
        {
            _dataContext = dataContext.DataContext;
            _paletteTable = _dataContext.GetTable<Sql.ColorPalette>();
            _systemSettingTable = _dataContext.GetTable<Sql.SystemSetting>();
        }

        public IQueryable<ColorPalette> GetColorPalettes()
        {
             return from p in _paletteTable
                   select new ColorPalette()
                   {
                       Id = p.Id,
                       Name = p.Name,
                       NavBackgroundColor = p.NavBackgroundColor,
                       SubNavBackgroundColor = p.SubNavBackgroundColor,
                       HighlightColor = p.HighlightColor,
                       LinkColor = p.LinkColor,
                       NavTextColor = p.NavTextColor,
                       SubNavTextColor = p.SubNavTextColor
                   };
        }

        public void Save(ColorPalette palette)
        {
            Mapper.CreateMap<ColorPalette, Sql.ColorPalette>();
            Sql.ColorPalette p = Mapper.Map<ColorPalette, Sql.ColorPalette>(palette);

            if (palette.Id == 0)
            {
                _paletteTable.InsertOnSubmit(p);
            }
            else
            {
                _paletteTable.Attach(p);
                _paletteTable.Context.Refresh(RefreshMode.KeepCurrentValues, p);
            }
        }

        public void DeleteColorPalette(int id)
        {
            _paletteTable.DeleteAllOnSubmit(from p in _paletteTable
                                            where p.Id == id
                                            select p);
        }

        public SystemSettings GetSystemSettings()
        {
            var systemSettings = new SystemSettings();
            var settings  = (
                from s in _systemSettingTable 
                select new Setting() {
                    Key = s.Key,
                    Value = s.Value
                }).ToDictionary<Setting, string>(k => k.Key);

      

            PropertyInfo[] properties = systemSettings.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (settings.ContainsKey(property.Name))
                {
                    property.SetValue(systemSettings, settings[property.Name], null);
                }
            }

            return systemSettings;
        }

        public void Save(SystemSettings setting)
        {

            PropertyInfo[] properties = setting.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                _systemSettingTable.Attach(new Sql.SystemSetting() 
                {
                    Key = property.Name,
                    Value = property.GetValue(setting, null).ToString()
                });
            }
          
            
            //_paletteTable.Context.Refresh(RefreshMode.KeepCurrentValues, );
        }
    }
}
