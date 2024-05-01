using Application.Features.LanguageTechonologys.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechonologys.Models
{
    public class LanguageTechonolgyListModel:BasePageableModel
    {
        public IList<LanguageTechonolgyListDto> Items { get; set; }
    }
}
