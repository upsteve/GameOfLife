﻿using GameOfLife.CellEnumeration;
using System.Text.RegularExpressions;

namespace GameOfLife.Parsers.Rle
{
    public static class RleConverter
    {
        private static readonly Regex Pattern = new(@"\d*[bo]");
        public static IEnumerable<bool> RowToCells(string row, int count) => Pattern.Matches(row).SelectMany(RleTag.ConvertMatchToCells).Pad(count, false);
    }
}