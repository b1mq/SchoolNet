using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Application.Dtos.Common
{
    public sealed record PaginationResultDto<T>(IReadOnlyCollection<T> Items, int Page, int PageSize, int TotalCount, int TotalPages);
}
