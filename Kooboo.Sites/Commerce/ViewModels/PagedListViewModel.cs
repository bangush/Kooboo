﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kooboo.Sites.Commerce.ViewModels
{
    public class PagedListViewModel<T>
    {
        public long PageIndex { get; set; }
        public long PageCount { get; set; }
        public List<T> List { get; set; }

        public void SetPageInfo(PagingQueryViewModel paging, long count)
        {
            PageIndex = paging.Index;
            PageCount = count / paging.Size + (count % paging.Size > 0 ? 1 : 0);
            if (PageCount == 0) PageCount = 1;
            if (PageIndex > PageCount) PageIndex = PageCount;
        }

        public long GetOffset(long size)
        {
            return (PageIndex - 1) * size;
        }
    }
}