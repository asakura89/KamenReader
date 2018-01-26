using System;
using System.Collections.Generic;
using System.Linq;

namespace KamenReader
{
    public static class Ext
    {
        public static IList<GridData> CleanupRawData(this FileReaderResult rawData)
        {
            return rawData.Data
                .GroupBy(prm => prm.Row)
                .Select(grp => grp.Select(item => item))
                .Where(grd => !grd.Aggregate(true, (p, n) => p && String.IsNullOrEmpty(n.CellValue)))
                .SelectMany(grd => grd)
                .ToList();
        }
    }
}