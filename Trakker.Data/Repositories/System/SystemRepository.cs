namespace Trakker.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AutoMapper;
    using System.Data.Linq;

    using Sql = Access;

    public class SystemRepository : ISystemRepository
    {
        protected DataContext _dataContext;
        protected Table<Sql.ColorPalette> _paletteTable;

        public SystemRepository(IDataContextProvider dataContext)
        {
            _dataContext = dataContext.DataContext;
            _paletteTable = _dataContext.GetTable<Sql.ColorPalette>();
        }

        public IQueryable<ColorPalette> GetColorPalettes()
        {
            return from p in _paletteTable
                   select new ColorPalette()
                   {
                       Id = p.Id,
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

    }
}
