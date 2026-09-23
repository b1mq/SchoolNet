using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Application.Dtos.Common
{
    public sealed record PaginationRequestDto(int Page, int PageSize);
}
