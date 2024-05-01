using Application.Features.Languages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Models
{
    public  class LanguageListModel
    {
        public IList<LanguageGetListDto> Items { get; set; }
    }
}
